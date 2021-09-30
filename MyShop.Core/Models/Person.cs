using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Person
    {
        public string Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(50)]
        public string LastName  { get; set; }
        public string City { get; set; }
        public string Sex { get; set; }
        [StringLength(11)]
        public string UserID { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(13)]
        public string MobileNumber { get; set; }

        public Person()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
