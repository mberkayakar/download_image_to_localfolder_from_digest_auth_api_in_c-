using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PIXSELECT_StudyCase.WebUI.Entities.ErrorModel;
using System;
using System.Net;

namespace PIXSELECT_StudyCase.WebUI.Extentions.ErrorHandler
{
    
    public static class ErrorHandlerExtentions 
    {
        public static void ConfigureExceptionandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextfeature!=null)
                    {
                        string message;

                        if (contextfeature.Error is NotFoundError)
                        {
                            context.Response.StatusCode = 400;
                            
                        }
                        else  
                        {
                            context.Response.StatusCode = 500;
                        }
                            
                        await context.Response.WriteAsync(new ErrorDetails 
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextfeature.Error.Message
                        }.ToString());
                    }
                });
            });

        }

    }
}
