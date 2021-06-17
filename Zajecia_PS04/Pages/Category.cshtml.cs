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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Zajecia_PS04.Pages
{
    public class CategoryModel : PageModel
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger<IndexModel> _logger;

        public List<Category> CategoryList = new List<Category>();

        public Category NewCategory = new Category();
        IproductDB ProductDB;
        public bool IsAuthorizedUser = false;

        public CategoryModel(IConfiguration configuartion, ILogger<IndexModel> logger,IproductDB _IProductDB)
        {
            _logger = logger;
            _configuration = configuartion;
            ProductDB = _IProductDB;
            CategoryList = ProductDB.CatList();
        }
        public void OnGet()
        {
            if (HttpContext.User != null)
            {
                IsAuthorizedUser = HttpContext.User.Identity.IsAuthenticated;
            }
        }

    }
}
