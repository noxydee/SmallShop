using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Zajecia_PS04.Utils
{
    public class CustomPageFilter : IPageFilter
    {
        public string CompanyName;
        public CustomPageFilter(IConfiguration _configuration)
        {
            CompanyName = _configuration["CompanyName"];
        }
        public void OnPageHandlerSelected(PageHandlerSelectedContext pageContext)
        {
            int x = 0;
        }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext pageContext)
        {
            int x = 0;
        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext pageContext)
        {
            var result = pageContext.Result;
           
            if (result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["filterMessage"] = CompanyName;
            }
        }


    }
}
