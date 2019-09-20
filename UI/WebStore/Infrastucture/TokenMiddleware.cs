using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebStore
{
    internal class TokenMiddleware
    {
        public RequestDelegate Next { get; }

        public TokenMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            var token = context.Request.Query["referenseToken"];

            if (string.IsNullOrEmpty(token))
            {
                await Next.Invoke(context);
            }

            if (token == "qwerty123")
            {
                await Next.Invoke(context);
            }
            else
            {
                await context.Response.WriteAsync("Is not token");
            }
        }

    }
}