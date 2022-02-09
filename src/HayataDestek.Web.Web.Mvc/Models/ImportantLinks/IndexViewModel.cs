using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HayataDestek.Web.Services.ImportantLinks.Dtos;

namespace HayataDestek.Web.Web.Models.ImportantLinks
{
    public class IndexViewModel
    {
        public IReadOnlyList<ImportantLinkDto> ImportantLinks { get; }

        public IndexViewModel(IReadOnlyList<ImportantLinkDto> importantLinks)
        {
            ImportantLinks = importantLinks;
        }
    }
}
