using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExceptionLoggerApp.Models;

namespace ExceptionLoggerApp.Filters
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            ExceptionDetail exceptionDetail = new ExceptionDetail()
            {
                ExceptionMessage = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                Date = DateTime.Now
            };

            using (LoggerContext db = new LoggerContext())
            {
                db.ExceptionDetails.Add(exceptionDetail);
                db.SaveChanges();
            }
        }
    }    
}
