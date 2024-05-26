using RunNetCoreWeb.Models;

namespace RunNetCoreWeb.ViewModels
{
    public class DashboardViewModel
    {
        public List<Race> Races { get; set; }
        public List<Club> Clubs { get; set; }
    }
}