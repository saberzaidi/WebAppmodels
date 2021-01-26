using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppmodels.controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService ps;
        public PeopleController(IPeopleService peopleService)
        {
            ps = peopleService;
        }

        private PeopleViewModel peopleViewModel;
       

        public IActionResult Index()
        {
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

        [HttpGet]
        public IActionResult Add_View_People()
        {

            if (peopleViewModel == null)
            {
                peopleViewModel = ps.All();
            }

            return View(peopleViewModel);
        }


        [HttpPost]
        public IActionResult Add_View_People(PeopleViewModel objModel)
        {
            CreatePersonViewModel createPersonModelView = new CreatePersonViewModel();
            if (objModel.AddPerson != null)
            {
                if (ModelState.IsValid)
                {
                    createPersonModelView = objModel.AddPerson;
                    peopleViewModel = null;
                    ps.Add(createPersonModelView);
                }
                else
                {
                    peopleViewModel.ModelErr = "Required fields are missing";
                }
            }

            if (objModel.Search != null)
            {
                peopleViewModel = ps.FindBy(objModel);
            }

            return RedirectToAction(nameof(Add_View_People));
        }

        public IActionResult DeletePeople(int id)
        {
            ps.Remove(id);
            peopleViewModel = ps.All();
            return RedirectToAction(nameof(Add_View_People));
        }
        public IActionResult EditPeople(int id)
        {
            Person person = new Person();

            person.FirstName = "EditFName";
            person.LastName = "EditLName";
            person.PhoneNumber = "123456789";
            person.Address = "EditAddress";

            ps.Edit(id, person);
            peopleViewModel = ps.All();
            return RedirectToAction(nameof(Add_View_People));
        }

        [HttpGet]
        public IActionResult AddPerson()
        {
            return PartialView("_AddPerson");
        }

        [HttpPost]
        public IActionResult AddPerson(CreatePersonViewModel person)
        {
            Person newPerson = null;
            if (ModelState.IsValid)
            {
                newPerson = ps.Add(person);
                return PartialView("_PersonPV", newPerson);
            }
            Response.StatusCode = 400;
            return PartialView("_AddPerson", person);
        }

        [HttpGet]
        public IActionResult EditPerson(int id)
        {
            Person editPerson = ps.FindBy(id);


            return PartialView("_EditPerson", editPerson);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            Person editedPerson = null;
            if (ModelState.IsValid)
            {
                editedPerson = ps.Edit(person.PersonID, person);
                return PartialView("_PersonPV", editedPerson);
            }

            Response.StatusCode = 400;
            return PartialView("_EditPerson", person);
        }

        public IActionResult RemovePerson(int id)
        {
            Person removedPerson = null;
            if (ps.Remove(id))
            {
                removedPerson = null;
            }

            return PartialView("_PersonPV", removedPerson);
        }

        [HttpPost]
        public IActionResult SearchPeople(PeopleViewModel objModel)
        {
            if (objModel.Search != null)
            {
                peopleViewModel = ps.FindBy(objModel);
            }
            else
            {
                peopleViewModel = ps.All();
            }

            return PartialView("_SearchPeople", peopleViewModel);
        }

    }
}