using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zajecia_PS04.Models;
using Zajecia_PS04.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Zajecia_PS04.Pages
{
    public class DetailCategoryModel : PageModel
    {
        public Category DetailCategory = new Category();

        public List<Product> ProductList = new List<Product>();
        public List<Product> ProductListx = new List<Product>();
        public IConfiguration _configuration { get; }
        IproductDB ProductDB;

        public DetailCategoryModel(IConfiguration configuartion,IproductDB _IProductDB)
        {
            _configuration = configuartion;
            ProductDB = _IProductDB;
        }

        public void OnGet(int id)
        {
            ProductList = ProductDB.List();
            DetailCategory = ProductDB.CatGet(id);

            foreach (Product x in ProductList)
            {
                if (x.Category == DetailCategory.ShortName)
                {
                    ProductListx.Add(x);
                }
            }
            ProductList.RemoveRange(0, ProductList.Count);
            ProductList = ProductListx;

        }
    }
}
