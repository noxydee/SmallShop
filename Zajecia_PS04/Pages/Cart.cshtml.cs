using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Zajecia_PS04.Models;

namespace Zajecia_PS04.Pages
{
    public class CartModel : MyPageModel
    {
        public List<Product> Cart;
        public decimal summary = 0;
        public int Quantity = 0;


        public void OnGet()
        {
            LoadCart();
            Cart = ShopingCart.List();
            SaveCart();

            foreach (Product p in Cart)
            {
                summary += p.price;
            }
            Quantity = Cart.Count();

        }
    }
}
