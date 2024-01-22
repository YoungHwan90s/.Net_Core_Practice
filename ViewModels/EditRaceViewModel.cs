using System.ComponentModel.DataAnnotations;
using RunNetCoreWeb.Data.Enum;
using RunNetCoreWeb.Models;

namespace RunNetCoreWeb.ViewModels
{
    public class EditRaceViewModel
    {
        [Required(ErrorMessage = "제목은 필수 항목입니다.")]
        [Display(Name = "제목")]
        public string Title { get; set; }
        [Required(ErrorMessage = "설명은 필수 항목입니다.")]
        [Display(Name = "설명")]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public RaceCategory RaceCategory { get; set; }
    }
}