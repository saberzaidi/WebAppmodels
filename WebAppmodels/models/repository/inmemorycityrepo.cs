using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.repository
{
    public class InMemoryCityRepo : ICityRepo
    {
        private static List<City> city = new List<City>();
        private static int idCounter = 0;
        public City Create(List<Person> personInCity, string States, string CityName)
        {
            City newCity = new City();

            idCounter++;
            newCity.Id = idCounter;

            //newCity.PersonInCity = PersonInCity;

            InMemoryPeopleRepo peopleRepo = new InMemoryPeopleRepo();
            newCity.PersonInCity = personInCity;

            newCity.States = States;

            city.Add(newCity);

            return newCity;
        }
        public List<City> Read()
        {
            return city;
        }
        public City Read(int id)
        {
            City searchedCity = new City();
            List<City> allCity = new List<City>();
            allCity = Read();

            foreach (City city in allCity)
            {
                if (city.Id == id)
                {
                    searchedCity = city;
                    break;
                }
            }

            return searchedCity;
        }
        public City Update(City city)
        {

            return null;
        }
        public bool Delete(City person)
        {
            city.Remove(person);
            return true;
        }

        public List<Person> ReadAllPersonInCity(int id)
        {
            throw new NotImplementedException();

        }
    }
}