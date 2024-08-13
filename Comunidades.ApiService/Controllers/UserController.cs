using Comunidades.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comunidades.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : DefaultController
    {
        readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }        

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserCreateRequest request)
        {
            var result = await userService.Create(request);
            return GetActionResult(result);
        }
    }
}
