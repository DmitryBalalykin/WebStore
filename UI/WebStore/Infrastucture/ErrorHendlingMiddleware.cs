using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastucture
{
    public class ErrorHendlingMiddleware
    {
        private readonly ILogger<ErrorHendlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ErrorHendlingMiddleware(RequestDelegate next, ILogger<ErrorHendlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception error)
            {
                await HendleExceptionAsync(context, error);
                throw;
            }
        } 

        private Task HendleExceptionAsync(HttpContext context, Exception error)
        {
            _logger.LogError(error, "Ошибка при обработке запроса {0}", context.Request.Path);
            return Task.CompletedTask;
        }
    }
}
