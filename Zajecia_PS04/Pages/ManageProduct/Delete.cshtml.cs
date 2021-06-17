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
    public class DeleteModel : MyPageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IConfiguration _configuration { get; }
        IproductDB ProductDB;

        public DeleteModel(IConfiguration configuartion, ILogger<IndexModel> logger,IproductDB _IProductDB)
        {
            _logger = logger;
            _configuration = configuartion;
            ProductDB = _IProductDB;
        }

        public IActionResult OnGet(int id)
        {
            ProductDB.Delete(id);

            return RedirectToPage("../List");
        }
    }
}
