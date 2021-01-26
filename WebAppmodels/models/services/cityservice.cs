using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;
        private readonly IPeopleRepo _peopleRepo;
        

        public CityService(ICityRepo cityRepo, IPeopleRepo peopleRepo)
        {
            _cityRepo = cityRepo;
            _peopleRepo = peopleRepo;
        }

        public City Add(CreateCityViewModel createCityViewModel)
        {
           

            List<Person> personInCity = new List<Person>();

            foreach (int personID in createCityViewModel.PeopleID)
            {
                Person person = _peopleRepo.Read(personID);
                personInCity.Add(person);
            }

            
            City city = _cityRepo.Create(personInCity, createCityViewModel.States, createCityViewModel.CityName);
            return city;
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public City Edit(int id, CreateCityViewModel edit)
        {
            City editedCity = new City() { Id = id, PersonInCity = edit.PersonInCity, States = edit.States, CityName = edit.CityName };

            return _cityRepo.Update(editedCity);
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public List<Person> FindAllPerson(int id)
        {
            return _cityRepo.ReadAllPersonInCity(id);
        }


        public bool Remove(int id)
        {
            return _cityRepo.Delete(FindBy(id));
        }
    }
}