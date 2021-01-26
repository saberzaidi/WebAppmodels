using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppmodels.models.viewmodels
{
    public class CreatePersonViewModel
    {
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