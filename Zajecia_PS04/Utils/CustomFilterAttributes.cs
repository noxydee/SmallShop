using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia_PS04.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Zajecia_PS04.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result;

            if (result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["filterMessage1"] = "Atrybut z Customfilter attribute";
            }
        }

    }
}
