using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.services
{
    public class CountryService : ICountryService
    {
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }

        public Country Add(CreateCountryViewModel createCountryViewModel)
        {

            List<City> cityInCountry = new List<City>();

            foreach (int cityID in createCountryViewModel.ListCityID)
            {
                City city = _cityRepo.Read(cityID);
                cityInCountry.Add(city);
            }


            Country country = _countryRepo.Create(cityInCountry, createCountryViewModel.CountryName);

            return country;
        }

        public List<Country> All()
        {
            return _countryRepo.Read();
        }

        public Country Edit(int id, CreateCountryViewModel edit)
        {
            Country editedcountry = new Country() { CountryId = id, CountryName = edit.CountryName };

            return _countryRepo.Update(editedcountry);
        }

        public Country FindBy(int id)
        {
            return _countryRepo.Read(id);
        }

        public List<City> FindAllCity(int id)
        {
            return _countryRepo.ReadAllCity(id);
        }

        public bool Remove(int id)
        {
            return _countryRepo.Delete(FindBy(id));
        }
    }
}
