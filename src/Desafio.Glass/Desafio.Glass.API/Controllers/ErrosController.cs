using Desafio.Glass.Application.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Desafio.Glass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrosController : ControllerBase
    {
        public IActionResult Index()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return StatusCode(Response.StatusCode, new ErroModel(exception));
        }
    }
}
