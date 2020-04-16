using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cw6.Services;

namespace cw6.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IStudentDbService service)
        {
            httpContext.Request.EnableBuffering();
            httpContext.Request.EnableBuffering();

            if (httpContext.Request != null)
            {
                string sciezka = httpContext.Request.Path; // api/students
                string querystring = httpContext.Request?.QueryString.ToString();
                string metoda = httpContext.Request.Method;
                string body = "";

                using (StreamReader reader
                 = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    body = await reader.ReadToEndAsync();
                    httpContext.Request.Body.Position = 0;
                }

                string query = httpContext.Request?.QueryString.ToString();
                using (StreamWriter writer = new StreamWriter(Path.Combine("requestLog.txt"), true))
                {
                    writer.WriteLine($"{metoda} | {sciezka} | {body} | {query}");
                }
            }

            await _next(httpContext);
        }


    }
}
