namespace RunNetCoreWeb.ViewModels;

public class UserDetailViewModel
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public int? Pace { get; set; }
    public int? Mileage { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string ProfileImageUrl { get; set; } = null!;

    public string Location => (City, State) switch
    {
        (string city, string state) => $"{city}, {state}",
        (string city, null) => city,
        (null, string state) => state,
        (null, null) => "",
    };
}