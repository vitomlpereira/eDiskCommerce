using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DiskCommerce.Service.Middleware
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }



        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result = string.Empty;


            if (exception is UnauthorizedAccessException)
            {
                result = JsonConvert.SerializeObject(new UnauthorizedAccessException());
            }
            else if (exception is Exception)
            {
                result = JsonConvert.SerializeObject(new BadRequestObjectResult(new
                {
                    sucess = false,
                    errors = string.Format($"{exception.Message} inner: {exception.InnerException?.InnerException} stack: {exception?.StackTrace} ")
                }));
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
