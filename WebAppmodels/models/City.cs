using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models
{
    public class City
    {
        

        [Key]
        public int Id { get; set; }

        public List<Person> PersonInCity { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string States { get; set; }

        public Country Country { get; set; }

    }
}