using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BRASILPREV.Models;
using BRASILPREV.Api.Service;
namespace Vendas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PessoaController : Controller
    {
        private readonly PessoaService _PessoaService;
        public PessoaController(PessoaService PessoaService)
        {
            _PessoaService = PessoaService;
        }
        [HttpGet]
        public JsonResult Get()
        {
            var Pessoa = _PessoaService.FindAll();
            string json = JsonConvert.SerializeObject(Pessoa);
            return Json(json);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var Pessoa = _PessoaService.FindById(id);
            string json = JsonConvert.SerializeObject(Pessoa);
            return Json(json);
        }
        [HttpPost]
        public ActionResult<Pessoa> Post(Pessoa Pessoa)
        {
            _PessoaService.InsertAsync(Pessoa);
            return CreatedAtAction(nameof(Get), new { id = Pessoa.Id }, Pessoa);
        }
        [HttpDelete("{id}")]
        public ActionResult<Pessoa> Delete(int id)
        {
            _PessoaService.Remove(id);
            return CreatedAtAction(nameof(Get), new { id = id });

        }
    }
}