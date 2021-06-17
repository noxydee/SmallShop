using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zajecia_PS04.Models
{
    public class SiteUser
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Display(Name ="Hasło")]
        public string password { get; set; }





    }
}
