using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppmodels.controllers
{
    public class CountryController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CountryController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        
        public ActionResult ShowCountry()
        {
           
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            ctyVM.CountryList = _countryService.All();
            return View(ctyVM);
           
        }

       
        public ActionResult CountryDetails(int id)
        {
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            Country ctyDetails = _countryService.FindBy(id);

            ctyVM.CountryId = ctyDetails.CountryId;
            ctyVM.CountryName = ctyDetails.CountryName;
            ctyVM.CityList = _countryService.FindAllCity(id); 
            return View(ctyVM);
        }

        public ActionResult CreateCountry()
        {
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            ctyVM.CityList = _cityService.All();
            return View(ctyVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCountry(CreateCountryViewModel ctyVM)
        {
            if (ModelState.IsValid)
            {
                Country country = _countryService.Add(ctyVM);

                if (country == null)
                {
                    ModelState.AddModelError("msg", "Database Problem");
                    return View(ctyVM);
                }

                return RedirectToAction(nameof(ShowCountry));
            }
            else
            {
                return View(ctyVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            Country editCountry = _countryService.FindBy(id);
            ctyVM.CountryName = editCountry.CountryName;
            ctyVM.CountryId = editCountry.CountryId;

            List<City> allCities = _cityService.All();
            ctyVM.CityList = allCities;

            return View("Edit", ctyVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateCountryViewModel editCountry)
        {
            _countryService.Edit(editCountry.CountryId, editCountry);

            return RedirectToAction(nameof(ShowCountry));
        }

        public ActionResult Delete(int id)
        {
            _countryService.Remove(id);

            return RedirectToAction(nameof(ShowCountry));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ShowCountry));
            }
            catch
            {
                return View();
            }
        }
    }
}