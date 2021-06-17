using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Zajecia_PS04.Models;

namespace Zajecia_PS04.DAL
{
    public class ProductDB
    {
        private List<Product> products;

        public void Load(string jsProducts)
        { 
            if(jsProducts == null)
            {
                products = Product.GetProducts();
            }
            else
            {
                products = JsonSerializer.Deserialize<List<Product>>(jsProducts);
            }
        }

        public int GetNextID()
        {
            if (products.Count > 0)
            {
                int lastID = products[products.Count - 1].id;
                int newID = lastID + 1;
                return newID;
            }
            else
                return 1;
            
        }
        public void CreateToCart(Product p)
        {
            products.Add(p);
        }

        public void Create(Product p)
        {
            p.id = GetNextID();
            products.Add(p);
        }
        public string Save()
        {
            return JsonSerializer.Serialize(products);
        }

        public List<Product> List()
        {
            return products;
        }

        public void Remove(int p)
        {
            foreach(Product x in products.ToList())
            {
                if(p==x.id)
                {
                    products.Remove(x);
                }
            }
        }
        public void Edit(Product inx)
        {
            foreach(Product x in List())
            {
                if(x.id==inx.id)
                {
                    x.name = inx.name;
                    x.price = inx.price;
                    break;
                }
            }
        }




    }

    

}
