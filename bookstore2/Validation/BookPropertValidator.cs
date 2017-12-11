using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore2.Models;

namespace bookstore2.Validation
{
    public class BookPropertValidator : ModelValidator
    {
        public BookPropertValidator(ModelMetadata metadata, ControllerContext controllerContext) 
            : base(metadata, controllerContext)
        {   }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Book curBook = container as Book;

            if(curBook != null)
            {
                switch (Metadata.PropertyName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(curBook.Name))
                        {
                            return new ModelValidationResult[]
                            {
                                new ModelValidationResult {MemberName="Name", Message="Введите название книги" }
                            };
                        }
                        break;

                    case "Author":
                        if (string.IsNullOrEmpty(curBook.Author))
                            return new ModelValidationResult[]
                            {
                                new ModelValidationResult {MemberName = "Author", Message="Введите автора книги" }
                            };

                        break;

                    case "Year":
                        if (curBook.Year < 1700 || curBook.Year > 2000)
                            return new ModelValidationResult[]
                            {
                                new ModelValidationResult {MemberName = "Year", Message="Недопустимый год" }

                            };
                        break;
                }
            }

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}