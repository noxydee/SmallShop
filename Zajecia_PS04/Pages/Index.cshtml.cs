using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;
using Zajecia_PS04.Models;
using System.Xml;
using Zajecia_PS04.DAL;
using Google.Apis;
using Google.Apis.CustomSearchAPI.v1;
using Google.Apis.Discovery;
using Google.Apis.Services;
using System.Collections;
using Zajecia_PS04.Utils;

namespace Zajecia_PS04.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;
        public IConfiguration _configuration { get; set; }
        IproductDB productDB;

        public IndexModel(IConfiguration configuartion, ILogger<IndexModel> logger,IproductDB _productDB)
        {
            _logger = logger;
            _configuration = configuartion;
            productDB = _productDB;

        }

        public List<Product> prodlist = new List<Product>();
        
        public void OnGet()
        {
            prodlist = productDB.List();

            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");

        }

    }
}


