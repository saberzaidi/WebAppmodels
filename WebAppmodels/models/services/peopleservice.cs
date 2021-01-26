using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo pr;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            pr = peopleRepo;
        }

        public Person Add(CreatePersonViewModel modelData)
        {
            Person personAdded = pr.Create(modelData.FirstName, modelData.LastName, modelData.PhoneNumber, modelData.Address);
            return personAdded;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.AllPeople = pr.Read();
            return peopleViewModel;
        }
        public PeopleViewModel FindBy(PeopleViewModel pvm)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            List<Person> searchedPeople = new List<Person>();
            peopleViewModel.AllPeople = pr.Read();

            foreach (Person person in peopleViewModel.AllPeople)
            {
                if ((person.FirstName).Contains(pvm.Search, StringComparison.OrdinalIgnoreCase) ||
                     (person.LastName).Contains(pvm.Search, StringComparison.OrdinalIgnoreCase) ||
                      (person.Address).Contains(pvm.Search, StringComparison.OrdinalIgnoreCase))
                {
                    searchedPeople.Add(person);
                }
            }

            peopleViewModel.AllPeople = searchedPeople;

            return peopleViewModel;
        }
        public Person FindBy(int findID)
        {

            List<Person> allPeople = new List<Person>();
            allPeople = pr.Read();

            Person searchedPerson = new Person();

            foreach (Person person in allPeople)
            {
                if (person.PersonID == findID)
                {
                    searchedPerson = person;
                }
            }

            return searchedPerson;
        }
        public Person Edit(int id, Person editPerson)
        {
            Person person = FindBy(id);

            person.FirstName = editPerson.FirstName;
            person.LastName = editPerson.LastName;
            person.PhoneNumber = editPerson.PhoneNumber;
            person.Address = editPerson.Address;
            pr.Update(person);
            return person;
        }
        public bool Remove(int findID)
        {
            bool result = false;

            Person removePerson = pr.Read(findID);
            result = pr.Delete(removePerson);
            return result;
        }
    }
}