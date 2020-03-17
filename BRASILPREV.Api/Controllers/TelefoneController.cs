using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BRASILPREV.Models;
using BRASILPREV.Api.Service;
namespace Vendas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TelefoneController : Controller
    {
        private readonly TelefoneService _TelefoneService;
        public TelefoneController(TelefoneService TelefoneService)
        {
            _TelefoneService = TelefoneService;
        }
        [HttpGet]
        public JsonResult Get()
        {
            var Telefone = _TelefoneService.FindAll();
            string json = JsonConvert.SerializeObject(Telefone);
            return Json(json);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var Telefone = _TelefoneService.FindById(id);
            string json = JsonConvert.SerializeObject(Telefone);
            return Json(json);
        }
        [HttpPost]
        public ActionResult<Telefone> Post(Telefone Telefone)
        {
            _TelefoneService.InsertAsync(Telefone);
            return CreatedAtAction(nameof(Get), new { id = Telefone.Id }, Telefone);
        }
        [HttpDelete("{id}")]
        public ActionResult<Telefone> Delete(int id)
        {
            _TelefoneService.Remove(id);
            return CreatedAtAction(nameof(Get), new { id = id });

        }
    }
}