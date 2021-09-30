using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product ProductToUpdate = products.Find(p => p.Id == product.Id);
            if (ProductToUpdate != null)
                ProductToUpdate = product;
            else
                throw new Exception("Product No Found");
        }
        public Product Find(string id)
        {

            Product product = products.Find(p => p.Id == id);
            if (product != null)
                return product;
            else
                throw new Exception("Product No Found");
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string ID)
        {
            Product ProductToDelete = products.Find(p => p.Id == ID);
            if (ProductToDelete != null)
                products.Remove(ProductToDelete);
            else
                throw new Exception("Product No Found");
        }
            
            

    }

}
