using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.repository
{
    public interface ICityRepo
    {
        public City Create(List<Person> PersonInCity, string States, string CityName);
        public List<City> Read();
        public City Read(int id);
        public List<Person> ReadAllPersonInCity(int id);
        public City Update(City PersonInCity);
        public bool Delete(City PersonInCity);

    }
}
