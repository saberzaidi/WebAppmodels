using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.database
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(string FirstName, string LastName, string PhoneNumber, string Address)
        {
            Person addingPerson = new Person(FirstName, LastName, PhoneNumber, Address);

            _peopleDbContext.GetPeopleList.Add(addingPerson);
            _peopleDbContext.SaveChanges();
            return addingPerson;

        }

        public bool Delete(Person person)
        {
            bool delete = true;

            if (delete == true)
            {
                _peopleDbContext.GetPeopleList.Remove(person);
                _peopleDbContext.SaveChanges();
            }

            return delete;
        }

        public List<Person> Read()
        {
            return _peopleDbContext.GetPeopleList.ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.GetPeopleList.SingleOrDefault(getPeopleList => getPeopleList.PersonID == id);
        }

        public Person Update(Person person)
        {
            _peopleDbContext.Update(person);
            _peopleDbContext.SaveChanges();
            return (person);
        }
    }
}
