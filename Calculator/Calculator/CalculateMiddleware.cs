using System;
using System.Threading.Tasks;
using CLibraryC;
using Microsoft.AspNetCore.Http;

namespace Calculator
{
    public class CalculateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string variable_name;

        public CalculateMiddleware(RequestDelegate next, string variableName)
        {
            _next = next;
            variable_name = variableName;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var a = CalculatorC.Calculate(context.Request.Query[variable_name]);
                _next.Invoke(context);

            }
            catch
            {
                context.Response.StatusCode = 400;
            }
        }

    }
}