using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core;

namespace MyShop.DataAccess.InMemory
{
    public class PersonRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Person> persons;
        public PersonRepository()
        {
            persons = cache["persons"] as List<Person>;
            if (persons == null)
            {
                persons = new List<Person>();
            }
        }
        public void Commit()
        {
            cache["persons"] = persons;
        }

        public void Insert(Person p)
        {
            persons.Add(p);
        }
        public void Update(Person person)
        {
            Person PersonToUpdate = persons.Find(p => p.Id == person.Id);
            if (PersonToUpdate != null)
                PersonToUpdate = person;
            else
                throw new Exception("person No Found");
        }
        public Person Find(string id)
        {

            Person person = persons.Find(p => p.Id == id);
            if (person != null)
                return person;
            else
                throw new Exception("Product No Found");
        }

        public IQueryable<Person> Collection()
        {
            return persons.AsQueryable();
        }

        public void Delete(string ID)
        {
            Person PersonToUpdate = persons.Find(p => p.Id == ID);
            if (PersonToUpdate != null)
                persons.Remove(PersonToUpdate);
            else
                throw new Exception("Person No Found");
        }


    }
}
