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
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.IO;

namespace Zajecia_PS04.Pages.Admin
{
    public class AdminAreaModel : MyPageModel
    {
        private IConfiguration _configuration;
        IUser _UserDB;

        public AdminAreaModel(IConfiguration _configuration, IUser _UserDB)
        {
            this._configuration = _configuration;
            this._UserDB = _UserDB;
        }

        private List<SiteUser> GetList()
        {
            return _UserDB.List();
        }

        public void OnGet()
        {
            
        }
    }
}
