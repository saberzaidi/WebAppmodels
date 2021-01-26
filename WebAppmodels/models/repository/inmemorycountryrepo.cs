using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.repository
{
    public class InMemoryCountryRepo : ICountryRepo
    {
        private static List<Country> country = new List<Country>();
        private static int idCounter = 0;

        public Country Create(List<City> CityInCountry, string CountryName)
        {
            Country newCountry = new Country();

            idCounter++;
            newCountry.CountryId = idCounter;


            newCountry.CountryName = CountryName;


           
            newCountry.CityList = CityInCountry;


            return newCountry;
        }

        public List<Country> Read()
        {
            throw new NotImplementedException();
        }

        public Country Read(int id)
        {
            throw new NotImplementedException();
        }

        public Country Update(Country country)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Country country)
        {
            throw new NotImplementedException();
        }

        public List<City> ReadAllCity(int id)
        {
            throw new NotImplementedException();
        }

    }
}
