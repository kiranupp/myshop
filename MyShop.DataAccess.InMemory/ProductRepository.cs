using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;


namespace MyShop.DataAccess.InMemory
{
    public  class ProductRepository
      {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;
        public ProductRepository()
        {
            products = cache["Products"] as List<Product>;
            if(products==null)
            {
                products = new List<Product>();
            }
          

        }
        public void Commit()
        {
            cache["Products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update (Product product)
        {
            Product productupdate = products.Find(p => p.Id == product.Id);
            if(productupdate!=null)
            {
                productupdate = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product Find(string Id)
        {
            Product product= products.Find(p => p.Id == Id);
            if (product != null)
            {
               return product;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productdelete = products.Find(p => p.Id ==Id);
            if (productdelete != null)
            {
                products.Remove(productdelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
