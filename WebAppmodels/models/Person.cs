using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string firstName, string lastName, string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        [Key]
        public int PersonID { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 9)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string Address { get; set; }

        public City City { get; set; }

    }
}
