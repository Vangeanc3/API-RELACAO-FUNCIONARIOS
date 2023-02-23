using OpenAI_API;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("gpt")]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        // [Route("teste")]
        public async Task<IActionResult>BuscarResposta(){
            var api = new OpenAIAPI("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");
            var result = await api.Completions.GetCompletion("Cite 3 paises da Europa");
            return Ok(result);
        }
    }
}