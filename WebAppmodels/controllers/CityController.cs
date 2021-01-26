using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppmodels.controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IPeopleService _peopleService;

       

        public CityController(ICityService cityService, IPeopleService peopleService)
        {
            _cityService = cityService;
            _peopleService = peopleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult City()
        {
            CreateCityViewModel ctyVM = new CreateCityViewModel();
            ctyVM.CityList = _cityService.All();
            return View(ctyVM);
        }

        [HttpGet]
        public ActionResult CityDetails(int id)
        {
            CreateCityViewModel ctyVm = new CreateCityViewModel();
            City cityDetails = _cityService.FindBy(id);
            ctyVm.CityName = cityDetails.CityName;
            ctyVm.States = cityDetails.States;
            ctyVm.PersonInCity = _cityService.FindAllPerson(id);
            return View(ctyVm);
        }

        public ActionResult Create()
        {
            PeopleViewModel pplVM = _peopleService.All();
            CreateCityViewModel cityVM = new CreateCityViewModel();
            cityVM.PersonInCity = pplVM.AllPeople;
            return View(cityVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {
            City city = null;

            if (ModelState.IsValid)
            {

                city = _cityService.Add(createCity);

                if (city == null)
                {
                    ModelState.AddModelError("msg", "Database Problem");
                    return View(createCity);
                }

                return RedirectToAction(nameof(City));
            }
            else
            {
                return View(createCity);
            }

        }

        // GET: CityController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PeopleViewModel pplVM = _peopleService.All();
            CreateCityViewModel cityVM = new CreateCityViewModel();
            City editCity = _cityService.FindBy(id);

            cityVM.States = editCity.States;
            cityVM.CityName = editCity.CityName;
            cityVM.PersonInCity = pplVM.AllPeople;
            cityVM.updateCityID = id;

            return View("Edit", cityVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateCityViewModel updCity)
        {
            _cityService.Edit(updCity.updateCityID, updCity);

            return RedirectToAction(nameof(City));
        }

        public ActionResult Delete(int id)
        {
            _cityService.Remove(id);
            return RedirectToAction(nameof(City));
        }

        
    }
}
