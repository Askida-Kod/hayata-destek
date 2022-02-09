using HayataDestek.Web.Debugging;

namespace HayataDestek.Web
{
    public class WebConsts
    {
        public const string LocalizationSourceName = "Web";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f26a87a0ea2740ceb7645401c030d567";
    }
}
