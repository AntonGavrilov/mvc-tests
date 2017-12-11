using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore2.Models;


namespace bookstore2.Validation
{
    public class BookValidator : ModelValidator
    {
        public BookValidator(ModelMetadata metadata, ControllerContext controllerContext)
            : base( metadata,  controllerContext)
        {  }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Book curBook = (Book)Metadata.Model;

            List<ModelValidationResult> errors = new List<ModelValidationResult>();

            if (curBook.Name == "Преступление и наказание" && curBook.Author == "Ф. Достоевкий" && curBook.Year == 1866)
            {
                errors.Add(new ModelValidationResult { MemberName = "", Message = "Недопустимая книга" });
            }

            return errors;
        }
    }
}