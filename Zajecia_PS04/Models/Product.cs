using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zajecia_PS04.Models
{
    
    public class Product
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Field name is required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Field name is required")]
        [Range(0,double.MaxValue,ErrorMessage ="Only positive number allowed")]
        [Display(Name = "Price")]
        public decimal price { get; set; }
        [Display(Name ="Kategoria")]
        public string Category { get; set; }
        [Display(Name ="Opis")]
        public string CategoryLongName { get; set; }

        public static List<Product> GetProducts()
        {
            Product x1 = new Product { id = 1, name = "prod1", price = 22.2M };
            Product x2 = new Product { id = 2, name = "prod2", price = 232.2M };
            Product x3 = new Product { id = 3, name = "prod3", price = 2412.2M };
            Product x4 = new Product { id = 4, name = "prod4", price = 2212.2M };
            

            return new List<Product> { x1,x2,x3,x4 };

        }

    }



}
