using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Company
    {
        public string  Id { get; set; }
        public string CompanyName { get; set; }
        public string Activities { get; set; }
        public string Address { get; set; }
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
