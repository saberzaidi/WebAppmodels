using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.services
{
    public interface ICityService
    {
        public City Add(CreateCityViewModel createCityViewModel);
        public List<City> All();
        public City FindBy(int id);
        public City Edit(int id, CreateCityViewModel edit);
        public bool Remove(int id);
        public List<Person> FindAllPerson(int id);

    }
}
