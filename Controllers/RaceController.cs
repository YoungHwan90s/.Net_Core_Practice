using Microsoft.AspNetCore.Mvc;
using RunNetCoreWeb.Interfaces;
using RunNetCoreWeb.Models;
using RunNetCoreWeb.ViewModels;

namespace RunNetCoreWeb.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;

        public RaceController(IRaceRepository raceRepository, IPhotoService photoService)
        {
            _raceRepository = raceRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(raceVM.Image);
                var race = new Race
                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = raceVM.Address.Street,
                        City = raceVM.Address.City,
                        State = raceVM.Address.State,
                    }
                };
                _raceRepository.Add(race);
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(raceVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);
            if (race == null)
            {
                return View("Error");
            }
            var clubVM = new EditRaceViewModel
            {
                Title = race.Title,
                Description = race.Description,
                Address = race.Address,
                URL = race.Image,
                RaceCategory = race.RaceCategory
            };
            return View(clubVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRaceViewModel raceVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", raceVM);
            }

            var userRace = await _raceRepository.GetByIdAsyncNoTracking(id);
            if (userRace == null)
            {
                return View(raceVM);
            }

            try
            {
                await _photoService.DeletePhotoAsync(userRace.Image);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Could not delete photo");
                return View(raceVM);
            }

            var photoResult = await _photoService.AddPhotoAsync(raceVM.Image);

            // TroubleShooting - This will cause creating a new Address row
            // var race = new Race
            // {
            //     Id = id,
            //     Title = raceVM.Title,
            //     Description = raceVM.Description,
            //     Image = photoResult.Url.ToString(),
            //     AddressId = raceVM.AddressId,
            //     Address = raceVM.Address,
            // };

            // Refactor - new changes should be mapped so that new Address row won't be created
            userRace.Title = raceVM.Title;
            userRace.Description = raceVM.Description;
            userRace.Image = photoResult.Url.ToString();
            userRace.Address.Street = raceVM.Address.Street;
            userRace.Address.City = raceVM.Address.City;
            userRace.Address.State = raceVM.Address.State;
            userRace.RaceCategory = raceVM.RaceCategory;

            _raceRepository.Update(userRace);

            return RedirectToAction("Index");
        }
    }
}


