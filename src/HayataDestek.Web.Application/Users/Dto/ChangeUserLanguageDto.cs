using System.ComponentModel.DataAnnotations;

namespace HayataDestek.Web.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}