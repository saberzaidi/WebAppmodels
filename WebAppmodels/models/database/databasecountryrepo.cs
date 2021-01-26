using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.database
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabaseCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(List<City> CityInCountry, string CountryName)
        {
            Country addingCountry = new Country() { CountryName = CountryName };

           
            addingCountry.CityList = CityInCountry;

            _peopleDbContext.Add(addingCountry);
            _peopleDbContext.SaveChanges();

            foreach (City city in addingCountry.CityList)
            {
                city.Country = addingCountry;
                _peopleDbContext.Update(city);
                _peopleDbContext.SaveChanges();
            }

            return addingCountry;
        }

        public bool Delete(Country country)
        {
            bool delete = true;

            if (delete == true)
            {
                _peopleDbContext.GetCountriesList.Remove(country);
                _peopleDbContext.SaveChanges();
            }

            return delete;
        }

        public List<Country> Read()
        {
            return _peopleDbContext.GetCountriesList.ToList();
        }

        public Country Read(int id)
        {
            return _peopleDbContext.GetCountriesList.Find(id);
        }

        public List<City> ReadAllCity(int id)
        {
            return _peopleDbContext.GetCitiesList.Where(s => s.Country.CountryId == id).ToList();
        }

        public Country Update(Country country)
        {
            _peopleDbContext.Update(country);
            _peopleDbContext.SaveChanges();
            return (country);
        }
    }
}