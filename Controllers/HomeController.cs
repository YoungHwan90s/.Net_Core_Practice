using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RunNetCoreWeb.Helpers;
using RunNetCoreWeb.Interfaces;
using RunNetCoreWeb.Models;
using RunNetCoreWeb.ViewModels;

namespace RunNetCoreWeb.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;
    private readonly IClubRepository _clubRepository;


    public HomeController(IHttpClientFactory httpClientFactory, IConfiguration config, IClubRepository clubRepository)
    {
        _httpClientFactory = httpClientFactory;
        _config = config;
        _clubRepository = clubRepository;
    }

    public async Task<IActionResult> Index()
    {
        var homeViewModel = new HomeViewModel();
        try
        {
            string url = "https://ipinfo.io?token=" + _config.GetValue<string>("IPInfoToken");

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(url);

            var ipInfo = JsonConvert.DeserializeObject<IPInfo>(response);
            var myRI1 = new RegionInfo(ipInfo.Country);
            ipInfo.Country = myRI1.EnglishName;
            homeViewModel.City = ipInfo.City;
            homeViewModel.State = ipInfo.Region;

            if (homeViewModel.City != null)
            {
                homeViewModel.Clubs = await _clubRepository.GetClubByCity(homeViewModel.City);
            }

            return View(homeViewModel);
        }
        catch (Exception)
        {
            homeViewModel.Clubs = null;
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
