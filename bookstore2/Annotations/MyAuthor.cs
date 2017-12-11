using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace bookstore2.Annotations 
{
    public class MyAuthor : ValidationAttribute
    {
        string reqAuthor;

        public MyAuthor(string _reqAuthor)
        {
            reqAuthor = _reqAuthor;

        }

        public override bool IsValid(object value)
        {
            if (reqAuthor == string.Empty || reqAuthor == value.ToString())
                return true;

            return false;
        }
    }
}