using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using MyShop.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class CompanyManagementController : Controller
    {

        DataContext DbContext;
        public CompanyManagementController()
        {
            DbContext = new DataContext();
        }
        // GET: CompanyManagement
        public ActionResult Index()
        {
            var companies = DbContext.companies;
            return View(companies);   
        }
        [HttpPost]
        public ActionResult Index(string SearchWord, Company company)//სერჩი აერორებს ამის და sql like ა დასაბატებელი ორივე სერჩზე  და პაგინგ და ვსიო.
        {
            SqlCommand command = new SqlCommand();

            var searchResult = DbContext.companies.SqlQuery("Select * From Companies Where CompanyName=@SearchWord  OR Activities=@SearchWord OR Address=@SearchWord", new SqlParameter("@SearchWord", SearchWord));
            if (searchResult == null)
            {
                searchResult = DbContext.companies.SqlQuery("SELECT * FROM Companies WHERE Name LIKE 'FirstLatter'");
                command.Parameters.Add("@FirstLatter", System.Data.SqlDbType.NVarChar).Value = "%" + SearchWord + "%";
                return View(searchResult);
            }
            else
                return View(searchResult);
        }
        public ActionResult Create()
        {
            Company company = new Company();
            return View(company);
        }
        [HttpPost]
        public ActionResult Create(Company company)
        {
            if(!ModelState.IsValid)
                return View(company);
            else
            {

                DbContext.companies.Add(company);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Company company = DbContext.companies.Find(id);
            if (company == null)
                return HttpNotFound();
            else
            {
                return View(company);
            }
        }

         [HttpPost]
        public ActionResult Edit(Company company, string Id)
        {
            Company CompanyToEdit = DbContext.companies.Find(Id);
            if (CompanyToEdit == null)
                return HttpNotFound();
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(company);
                }
                DbContext.Entry(company).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Company CompanyToDelete = DbContext.companies.Find(Id);
            if (CompanyToDelete == null)
                return HttpNotFound();
            else
            {
                return View(CompanyToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Company CompanyToDelete = DbContext.companies.Find(Id);
            if (CompanyToDelete == null)
                return HttpNotFound();
            else
            {
                DbContext.Entry(CompanyToDelete).State = System.Data.Entity.EntityState.Deleted;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(Company company, string Id)
        {
            Company persontoshow = DbContext.companies.Find(Id);
            return View(persontoshow);
        }

        public ActionResult CompanyToPerson(Company company, string Id)
        {
            Company companytoconnect = DbContext.companies.Find(Id);
            var persons = DbContext.persons;

            return View();
        }
    }
}