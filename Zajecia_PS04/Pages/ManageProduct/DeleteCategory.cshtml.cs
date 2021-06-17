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
    public class DeleteCategoryModel : PageModel
    {
        private IConfiguration _configuration { get; }
        private ILogger<IndexModel> logger;
        IproductDB ProductDB;

        public DeleteCategoryModel(IConfiguration _configuration, ILogger<IndexModel> logger, IproductDB _IProductDB)
        {
            this._configuration = _configuration;
            this.logger = logger;
            ProductDB = _IProductDB;
        }


        public IActionResult OnGet(int id)
        {
            ProductDB.CatDelete(id);

            return RedirectToPage("../Category");
        }
    }
}
