using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.database
{
        public class DatabaseCityRepo : ICityRepo
        {
            private readonly PeopleDbContext _peopleDbContext;

            public DatabaseCityRepo(PeopleDbContext peopleDbContext)
            {
                _peopleDbContext = peopleDbContext;
            }


            public City Create(List<Person> personInCity, string States, string CityName)
            {
                City addingCity = new City() { States = States, CityName = CityName };

                addingCity.PersonInCity = personInCity;

                _peopleDbContext.Add(addingCity);
                _peopleDbContext.SaveChanges();

                foreach (Person person in addingCity.PersonInCity)
                {
                    _peopleDbContext.Update(person);
                    _peopleDbContext.SaveChanges();
                }

                return addingCity;
            }

            public bool Delete(City city)
            {
                bool delete = true;

                if (delete == true)
                {
                    _peopleDbContext.GetCitiesList.Remove(city);
                    _peopleDbContext.SaveChanges();
                }

                return delete;
            }

            public List<City> Read()
            {
                return _peopleDbContext.GetCitiesList.ToList();
            }

            public List<Person> ReadAllPersonInCity(int id)
            {
                return _peopleDbContext.GetPeopleList.Where(c => c.City.Id == id).ToList();
            }


            public City Read(int id)
            {
                return _peopleDbContext.GetCitiesList.Find(id);
            }

            public City Update(City city)
            {
                _peopleDbContext.Update(city);
                _peopleDbContext.SaveChanges();
                return (city);
            }
        }
    }
