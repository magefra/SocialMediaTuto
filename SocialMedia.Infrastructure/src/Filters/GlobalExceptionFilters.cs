using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Core.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SocialMedia.Infrastructure.src.Filters
{
    public class GlobalExceptionFilters : IExceptionFilter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;

                var validation = new
                {
                    Status = "400",
                    Title = "Bad Request",
                    Detail = exception.Message
                };


                var json = new
                {
                    errors = new[] 
                    {
                        validation
                    }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;



            }
        }
    }
}
