using RunNetCoreWeb.Data.Enum;
using RunNetCoreWeb.Models;

namespace RunNetCoreWeb.ViewModels
{
    public class EditClubViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public Address Address { get; set; }
        public ClubCategory ClubCategory { get; set; }
    }
}