using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Data;
using Zajecia_PS04.DAL;

namespace Zajecia_PS04.Models
{
    public class MyPageModel : PageModel
    {
        public ProductDB productDB;
        public ProductDB ShopingCart;

        CookieOptions option = new CookieOptions();

        public string jsonProductDB { get; set; }

        public string jsonLogsDB { get; set; }
        public string Cookie { get; set; }

        public MyPageModel()
        {
            productDB = new ProductDB();
            ShopingCart = new ProductDB();
        }

        public void LoadDB()
        {
            jsonProductDB = HttpContext.Session.GetString("jsonProductDB");
            productDB.Load(jsonProductDB);
        }

        public void SaveDB()
        {
            jsonProductDB = productDB.Save();
            HttpContext.Session.SetString("jsonProductDB", jsonProductDB);
        }

        public void LoadCart()
        {
            
            Cookie = Request.Cookies["Cookie"];
            ShopingCart.Load(Cookie);

            var cookie = Request.Cookies["Cookie"];

        }
        public void SaveCart()
        {
            Cookie = ShopingCart.Save();
            HttpContext.Session.SetString("Cookie", Cookie);
            option.Expires = DateTime.Now.AddDays(3);

            if (Cookie == null)
            {
                Cookie = Guid.NewGuid().ToString();
            }
            Response.Cookies.Append("Cookie", Cookie, option);

            
        }


    }
}
