using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Events.Bus;
using Abp.Events.Bus.Exceptions;
using Abp.Extensions;
using Abp.Logging;
using Abp.Runtime.Session;
using Abp.Runtime.Validation;
using Abp.Web.Configuration;
using Abp.Web.Models;
using Abp.WebApi.Configuration;
using Abp.WebApi.Controllers;
using Castle.Core.Logging;

namespace Abp.WebApi.ExceptionHandling
{
    /// <summary>
    /// Used to handle exceptions on web api controllers.
    /// </summary>
    public class AbpApiExceptionFilterAttribute : ExceptionFilterAttribute, ITransientDependency
    {
        /// <summary>
        /// Reference to the <see cref="ILogger"/>.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Reference to the <see cref="IEventBus"/>.
        /// </summary>
        public IEventBus EventBus { get; set; }

        public IAbpSession AbpSession { get; set; }

        protected IAbpWebApiConfiguration Configuration { get; }

        protected IAbpWebCommonModuleConfiguration AbpWebCommonModuleConfiguration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbpApiExceptionFilterAttribute"/> class.
        /// </summary>
        public AbpApiExceptionFilterAttribute(
            IAbpWebApiConfiguration configuration,
            IAbpWebCommonModuleConfiguration abpWebCommonModuleConfiguration)
        {
            this.AbpWebCommonModuleConfiguration = abpWebCommonModuleConfiguration;
            Configuration = configuration;
            Logger = NullLogger.Instance;
            EventBus = NullEventBus.Instance;
            AbpSession = NullAbpSession.Instance;
        }

        /// <summary>
        /// Raises the exception event.
        /// </summary>
        /// <param name="context">The context for the action.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            void HandleError()
            {
                if (context.Exception is HttpException)
                {
                    var httpException = context.Exception as HttpException;
                    var httpStatusCode = (HttpStatusCode) httpException.GetHttpCode();

                    context.Response = context.Request.CreateResponse(
                        httpStatusCode,
                        new AjaxResponse(
                            new ErrorInfo(httpException.Message),
                            httpStatusCode == HttpStatusCode.Unauthorized || httpStatusCode == HttpStatusCode.Forbidden
                        )
                    );
                }
                else
                {
                    context.Response = context.Request.CreateResponse(
                        GetStatusCode(context, true),
                        new AjaxResponse(
                            SingletonDependency<IErrorInfoBuilder>.Instance.BuildForException(context.Exception),
                            context.Exception is Abp.Authorization.AbpAuthorizationException)
                    );
                }

                EventBus.Trigger(this, new AbpHandledExceptionData(context.Exception));
            }

            var displayUrl = context.Request.RequestUri.AbsolutePath;
            if (AbpWebCommonModuleConfiguration.WrapResultFilters.HasFilterForWrapOnError(displayUrl,
                out var wrapOnError))
            {
                if (!wrapOnError)
                {
                    context.Response.StatusCode = GetStatusCode(context, false);
                    return;
                }

                HandleError();
                return;
            }

            var wrapResultAttribute = HttpActionDescriptorHelper.GetWrapResultAttributeOrNull(context.ActionContext.ActionDescriptor) ??
                Configuration.DefaultWrapResultAttribute;

            if (wrapResultAttribute.LogError)
            {
                LogHelper.LogException(Logger, context.Exception);
            }

            if (!wrapResultAttribute.WrapOnError)
            {
                context.Response.StatusCode = GetStatusCode(context, wrapResultAttribute.WrapOnError);
                return;
            }

            if (IsIgnoredUrl(context.Request.RequestUri))
            {
                return;
            }

            HandleError();
        }

        protected virtual HttpStatusCode GetStatusCode(HttpActionExecutedContext context, bool wrapOnError)
        {
            if (context.Exception is Abp.Authorization.AbpAuthorizationException)
            {
                return AbpSession.UserId.HasValue
                    ? HttpStatusCode.Forbidden
                    : HttpStatusCode.Unauthorized;
            }

            if (context.Exception is AbpValidationException)
            {
                return HttpStatusCode.BadRequest;
            }

            if (context.Exception is EntityNotFoundException)
            {
                return HttpStatusCode.NotFound;
            }

            if (wrapOnError)
            {
                return HttpStatusCode.InternalServerError;
            }

            return context.Response.StatusCode;
        }

        protected virtual bool IsIgnoredUrl(Uri uri)
        {
            if (uri == null || uri.AbsolutePath.IsNullOrEmpty())
            {
                return false;
            }

            return Configuration.ResultWrappingIgnoreUrls.Any(url => uri.AbsolutePath.StartsWith(url));
        }
    }
}
