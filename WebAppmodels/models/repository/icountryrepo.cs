using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.repository
{
    public interface ICountryRepo
    {
        public Country Create(List<City> CityInCountry, string CountryName);
        public List<Country> Read();
        public Country Read(int id);
        public List<City> ReadAllCity(int id);
        public Country Update(Country country);
        public bool Delete(Country country);
    }
}
