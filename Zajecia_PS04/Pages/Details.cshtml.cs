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
using Zajecia_PS04.DAL;

namespace Zajecia_PS04.Pages
{
    public class DetailsModel : MyPageModel
    {
        public List<Product> ProductList = new List<Product>();
        public Product DetailProduct { get; set; }
        //public IConfiguration _configuration { get; }
        IproductDB ProductDB;

        public DetailsModel(/*IConfiguration configuartion,*/IproductDB _IProductDB)
        {
            //_configuration = configuartion;
            ProductDB = _IProductDB;
        }

        public void OnGet(int id)
        {
            DetailProduct = ProductDB.Get(id);
        }

        public IActionResult OnPost(Product DetailProduct)
        {
            LoadCart();
            ShopingCart.CreateToCart(DetailProduct);
            SaveCart();

            return RedirectToPage("Cart");
        }

        
    }
}
