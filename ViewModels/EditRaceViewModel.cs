using System.ComponentModel.DataAnnotations;
using RunNetCoreWeb.Data.Enum;
using RunNetCoreWeb.Models;

namespace RunNetCoreWeb.ViewModels
{
    public class EditRaceViewModel
    {
        [Key]
        [Display(Name = "제목")]
        [Required(ErrorMessage = "제목은 필수 항목입니다.")]
        [RegularExpression("^[A-Za-z0-9가-힣]+$", ErrorMessage = "올바르지 않은 형식입니다. 알파벳 대소문자, 숫자, 한글만 허용됩니다.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "설명은 필수 항목입니다.")]
        [Display(Name = "설명")]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public Address Address { get; set; }
        public RaceCategory RaceCategory { get; set; }
    }
}