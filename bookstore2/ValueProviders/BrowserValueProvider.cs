using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace bookstore2.ValueProviders
{
    public class BrowserValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("browser", prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            return ContainsPrefix(key) ? new ValueProviderResult("Выш браузер" + 
                            HttpContext.Current.Request.Browser.Browser, null, culture: CultureInfo.InvariantCulture) : null;
        }
    }
}