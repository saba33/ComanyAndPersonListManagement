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
    public class PersonsManagmentController : Controller
    {
        DataContext DBcontext;
        public PersonsManagmentController()
        {
            DBcontext = new DataContext();
        }
        // GET: PersonsManagment


        public ActionResult Index()
        {           

            var persons = DBcontext.persons;
            return View(persons);
        }
        [HttpPost]
        public ActionResult Index(string SearchWord, Person person)
        {
            SqlCommand command = new SqlCommand();
            
            var searchResult = DBcontext.persons.SqlQuery("Select * From People Where Name=@SearchWord  OR LastName=@SearchWord OR UserID=@SearchWord", new SqlParameter("@SearchWord", SearchWord));
            if(searchResult == null)
            {
                searchResult = DBcontext.persons.SqlQuery("SELECT * FROM People WHERE Name LIKE '@FirstLatter'");
                command.Parameters.Add("@FirstLatter", System.Data.SqlDbType.NVarChar).Value = "%" + SearchWord + "%";
                return View(searchResult);
            }
            else
                return View(searchResult);

        }


        public ActionResult Create()
        {
            Person person = new Person();
            return View(person);
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
                return View(person);
            else
            {
                DBcontext.persons.Add(person);
                DBcontext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Person person = DBcontext.persons.Find(id);
            if (person == null)
                return HttpNotFound();
            else
            {
                return View(person);
            }
        }

        [HttpPost]
        public ActionResult Edit(Person person, string Id)
        {
            Person PersonToEdit = DBcontext.persons.Find(Id);
            if (PersonToEdit == null)
                return HttpNotFound();
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(person);
                }
                
                DBcontext.Entry(person).State = EntityState.Modified;
                DBcontext.SaveChanges();
                return RedirectToAction("index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Person PersonToDelete = DBcontext.persons.Find(Id);
            if (PersonToDelete == null)
                return HttpNotFound();
            else
            {
                return View(PersonToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Person PersonToDelete = DBcontext.persons.Find(Id);
            if (PersonToDelete == null)
                return HttpNotFound();
            else
            {    
                DBcontext.Entry(PersonToDelete).State = System.Data.Entity.EntityState.Deleted;
                DBcontext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(Person person, string Id)
        {
            Person persontoshow = DBcontext.persons.Find(Id);
            return View(persontoshow);
        }


        public ActionResult ConnectPersonToCompany(Person person, string Name)
        {
            Person persontoconnect = DBcontext.persons.Find(Name);
            var companies = DBcontext.companies;
            var name = persontoconnect.Name;
            return View();
        }

    }

}
