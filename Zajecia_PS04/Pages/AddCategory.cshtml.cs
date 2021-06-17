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
    public class AddCategoryModel : PageModel
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger<IndexModel> _logger;
        IproductDB ProductDB;

        public Category NewCategory = new Category();

        public AddCategoryModel(IConfiguration configuartion, ILogger<IndexModel> logger,IproductDB _IProductDB)
        {
            _logger = logger;
            _configuration = configuartion;
            ProductDB = _IProductDB;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost(Category NewCategory)
        {
            if(ModelState.IsValid)
            {
                ProductDB.CatAdd(NewCategory);

                return RedirectToPage("Category");
            }
            return Page();
        }


    }
}
