using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
   
    public class DataContext: DbContext
    {
        public DataContext():
            base("DefaultConnection")
        {

        }
        public DbSet<Person> persons { get; set; }
        public DbSet<Company> companies { get; set; }

        public DbSet<PersonToCompanyModel> PersonRelatedToCompanies { get; set; }
    }
}
