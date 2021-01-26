using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.repository
{
    public interface IPeopleRepo
    {
        public Person Create(string FirstName, string LastName, string PhoneNumber, string Address);
        public List<Person> Read();
        public Person Read(int id);
        public Person Update(Person person);
        public bool Delete(Person person);
    }
}
