using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore2.Models;

namespace bookstore2.Validation
{
    public class MyValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if(metadata.ContainerType == typeof(Book))
            {
                return new ModelValidator[] { new BookPropertValidator(metadata, context) };

            }

            if(metadata.ModelType == typeof(Book))
            {
                return new ModelValidator[] { new BookValidator(metadata, context) };
            }

            return Enumerable.Empty<ModelValidator>();
        }
    }
}