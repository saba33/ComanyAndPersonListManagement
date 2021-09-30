using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class PersonToCompanyModel
    {
        Company company = new Company();
        Person person = new Person();


        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string RelatedPersonName { get; set; }
        public PersonToCompanyModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }


        // CompanyName | RelatedPersonName |  PersonName | RealtedCompanyName
        // EPAM        | Saba              |             |
    }
}
