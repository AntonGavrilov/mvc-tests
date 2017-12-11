using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore2.Annotations
{
    public class MyAuthorsAttribute : ValidationAttribute
    {
        private static string[] myAuthors;

        public MyAuthorsAttribute(string[] Authors)
        {
            myAuthors = Authors;
        }

        public override bool IsValid(object value)
        {
            if(value != null)
            {   
                string strval = value.ToString();

                var result = myAuthors.FirstOrDefault(author => author == strval);

                return !(result == null); 
            }

            return false;
        }

    }
}