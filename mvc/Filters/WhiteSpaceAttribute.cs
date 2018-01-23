using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace mvc.Filters
{
    public class WhiteSpaceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var resp = filterContext.HttpContext.Response;

            if(filterContext.HttpContext.Request.RawUrl == "/sitemap.xml")
                return;


            if (resp.ContentType != "text/html" || resp.Filter == null)
                return;

            resp.Filter = new SpaceCleaner(resp.Filter);
        }

        private class SpaceCleaner : Stream
        {
            private readonly Stream outputStream;
            StringBuilder s = new StringBuilder();

            public SpaceCleaner(Stream filterStream)
            {
                if (filterStream == null)
                    throw new ArgumentNullException("filterStream is not determined");
                outputStream = filterStream;
            }


            public override bool CanRead
            {
                get
                {
                    return false;
                }
            }

            public override bool CanSeek
            {
                get
                {
                    return false;
                }
            }

            public override bool CanWrite
            {
                get
                {
                    return true;
                }
            }

            public override long Length
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public override long Position
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public override void Flush()
            {
                outputStream.Flush();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotImplementedException();
            }

            public override void SetLength(long value)
            {
                throw new NotImplementedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                var html = Encoding.UTF8.GetString(buffer, offset, count);
                var reg = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
                html = reg.Replace(html, String.Empty);
                buffer = Encoding.UTF8.GetBytes(html);
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}