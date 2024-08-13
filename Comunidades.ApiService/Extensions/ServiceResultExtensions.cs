using Comunidades.ApiService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Comunidades.ApiService.Extensions
{
    /// <summary>
    /// Classe base como resposta de conversão de um IServiceResult em um IResult.
    /// </summary>
    public class ResultService : IResult
    {
        readonly IServiceResult serviceResult;

        public ResultService(IServiceResult serviceResult)
        {
            this.serviceResult = serviceResult;
        }

        public async Task ExecuteAsync(HttpContext httpContext)
        {               
            var json = JsonSerializer.Serialize(serviceResult);
            var bytes = Encoding.UTF8.GetBytes(json);
            var readOnlyMemory = new ReadOnlyMemory<byte>(bytes);
            
            await httpContext.Response.Body.WriteAsync(readOnlyMemory);

            httpContext.Response.StatusCode = (int)serviceResult.StatusCode();
            httpContext.Response.ContentType = "application/json";
        }
    }

    /// <summary>
    /// Representa extensões para a interface IServiceResult.
    /// </summary>
    public static class ServiceResultExtensions
    {
        /// <summary>
        /// Obtém um objeto IActionResult de um IServiceResult.
        /// </summary>
        public static IActionResult ToActionResult(this IServiceResult serviceResult)
        {
            var result = new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult!.StatusCode()
            };

            return result;
        }

        /// <summary>
        /// Obtém um objeto IResult de um IServiceResult.
        /// </summary>
        public static IResult ToResult(this IServiceResult serviceResult)
        {
            var result = new ResultService(serviceResult);
            return result;
        }
    }
}
