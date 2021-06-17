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
using Zajecia_PS04.DAL;

namespace Zajecia_PS04.Pages
{
    public class ListModel : MyPageModel
    {
        public List<Product> ProductList =  new List<Product>();
        public IConfiguration _configuration { get; }
        private readonly ILogger<IndexModel> _logger;
        IproductDB ProductDB;
        public bool IsAuthorizedUser = false;

        public ListModel(IConfiguration configuartion, ILogger<IndexModel> logger,IproductDB _iproductDB)
        {
            _logger = logger;
            _configuration = configuartion;
            ProductDB = _iproductDB;
        }

        public void OnGet()
        {
            ProductList = ProductDB.List();
            if(HttpContext.User != null)
            {
                IsAuthorizedUser = HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public IActionResult Delete(int id)
        {
            LoadDB();
            productDB.Remove(id);
            SaveDB();
            return RedirectToPage("Create");
        }


    }
}
