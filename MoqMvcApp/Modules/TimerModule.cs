using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Threading;

namespace MoqMvcApp.Modules
{
    public class TimerModule : IHttpModule
    {
        private Stopwatch timer;

        public event EventHandler<RequestTimerEventArgs> RequestTimed;

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleBeginRequest;
            context.EndRequest += HandleEndRequest;
        }

        private void HandleBeginRequest(object src, EventArgs args)
        {
            timer = Stopwatch.StartNew();
        }

        private void HandleEndRequest(object src, EventArgs args)
        {
            HttpContext context = HttpContext.Current;

            var duration = ((float)timer.ElapsedTicks) / Stopwatch.Frequency;
            context.Response.Write(string.Format("<div style='color:red;'>Время обработки запроса: {0:F5} секунд</div>"
                , duration));

            RequestTimed(this, new RequestTimerEventArgs { Duration = duration });
        }

    }

    public class RequestTimerEventArgs : EventArgs
    {
        public float Duration { get; set; }
    }

}