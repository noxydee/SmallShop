using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zajecia_PS04.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name ="Kategoria")]
        [Required(ErrorMessage ="To pole jest wymagane")]
        public string ShortName { get; set; }
        [Display(Name ="Opis")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string LongName { get; set; }
    }
}
