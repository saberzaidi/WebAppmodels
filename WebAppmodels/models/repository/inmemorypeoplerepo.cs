using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.repository
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> people = new List<Person>();
        private static int idCounter = 0;
        public Person Create(string FirstName, string LastName, string PhoneNumber, string Address)
        {
            Person person = new Person();

            idCounter++;
            person.PersonID = idCounter;

            person.FirstName = FirstName;
            person.LastName = LastName;
            person.PhoneNumber = PhoneNumber;
            person.Address = Address;

            people.Add(person);

            return person;
        }
        public List<Person> Read()
        {
            return people;
        }
        public Person Read(int id)
        {
            Person searchedPerson = new Person();
            List<Person> allPeople = new List<Person>();
            allPeople = Read();

            foreach (Person person in allPeople)
            {
                if (person.PersonID == id)
                {
                    searchedPerson = person;
                    break;
                }
            }

            return searchedPerson;
        }
        public Person Update(Person person)
        {

            return null;
        }
        public bool Delete(Person person)
        {
            people.Remove(person);
            return true;
        }

    }
}