using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore2.Models;

namespace bookstore2.MyBookModelBinders
{
    public class BookModelBinder : IModelBinder
    {
        object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;

            ValueProviderResult vprId = valueProvider.GetValue("Id");

            string name = (string)valueProvider.GetValue("Name").ConvertTo(typeof(string));
            string author = (string)valueProvider.GetValue("Author").ConvertTo(typeof(string));
            int year = (int)valueProvider.GetValue("Year").ConvertTo(typeof(int));            
            Book book = new Models.Book() { Name = name + "(new)", Author = author, Year = year };
            
            if(vprId != null)
            {
                book.Name = name;
                book.Id = (int)vprId.ConvertTo(typeof(int));
            }

            return book;
        }
    }
}