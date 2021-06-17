using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zajecia_PS04.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Web;
using Zajecia_PS04.DAL;

namespace Zajecia_PS04.Pages
{
    public class EditModel : MyPageModel
    {
        //public List<Product> ProductList;
        public IConfiguration _configuration { get; }
        private readonly ILogger<IndexModel> _logger;
        IproductDB ProductDB;
        public Product EditProduct { get; set; }
        public int idx;

        public List<Category> Categories = new List<Category>();

        public EditModel(IConfiguration configuartion, ILogger<IndexModel> logger,IproductDB _IProductDB)
        {
            _logger = logger;
            _configuration = configuartion;
            ProductDB = _IProductDB;
        }

        public void OnGet(int id)
        {
            Categories = ProductDB.CatList();
            EditProduct = ProductDB.Get(id);
        }

        public IActionResult OnPost(Product EditProduct)
        {
            if(ModelState.IsValid)
            {
                ProductDB.Update(EditProduct);

                return RedirectToPage("../List");
            }
            return Page();
        }

       

    }
}
