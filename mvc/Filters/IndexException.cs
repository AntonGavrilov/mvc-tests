using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Filters
{
    public class IndexException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(!filterContext.ExceptionHandled 
                && filterContext.Exception is IndexOutOfRangeException)
            {
                filterContext.Result = new RedirectResult("/Content/CommonException.html");
                filterContext.ExceptionHandled = true;
            } 
        }
    }
}