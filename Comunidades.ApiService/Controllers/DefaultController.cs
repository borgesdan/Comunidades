using Comunidades.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comunidades.ApiService.Controllers
{
    public class DefaultController : Controller
    {
        /// <summary>
        /// Converte o tipo de dado recebido pelo serviço em um IActionResult válido
        /// a ser enviado como resposta do controle.
        /// </summary>        
        protected IActionResult GetActionResult(IServiceResult resultData)
        {
            if (resultData == null)
                NoContent();

            var result = new ObjectResult(resultData)
            {
                StatusCode = (int)resultData!.StatusCode()
            };

            return result;
        }
    }
}
