using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Zajecia_PS04.DAL;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zajecia_PS04.Models;

namespace Zajecia_PS04
{
    //[Route("[controller]")]
    //[ApiController]
    public class ReactRouting : ControllerBase
    {
        private IConfiguration _configuration;
        private IUser _UserDB;
        public ReactRouting(IConfiguration _configuration,IUser _UserDB)
        {
            this._configuration = _configuration;
            this._UserDB = _UserDB;
        }
        [Route("Users")]
        [ResponseCache(Location = ResponseCacheLocation.None,NoStore = true)]
        public string RouteUsers()
        {
            string result = JsonSerializer.Serialize(_UserDB.List());
            return result;
        }

        [Route("Users/New")]
        [HttpPost]
        public ActionResult RouteUsersAdd(SiteUser user)
        {
            _UserDB.Add(user);
            return Content("Success :)");
        }


    }
}
