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
    public class CreateModel : MyPageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }

        public List<Category> Categories = new List<Category>();
        IproductDB ProductDB;

        public string lblInfoText;

        public IConfiguration _configuration { get; }
        private readonly ILogger<IndexModel> _logger;

        public CreateModel(IConfiguration configuartion, ILogger<IndexModel> logger, IproductDB _IProductDB)
        {
            _logger = logger;
            _configuration = configuartion;
            ProductDB = _IProductDB;
        }

        public void OnGet()
        {
            Categories=ProductDB.CatList();
        }

        public IActionResult OnPost(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                ProductDB.Add(newProduct);

                return RedirectToPage("List");
            }
            return Page();
           
        }

    }
}
