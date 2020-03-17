using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BRASILPREV.Models;
using BRASILPREV.Api.Service;
namespace Vendas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EnderecoController : Controller
    {
        private readonly EnderecoService _EnderecoService;
        public EnderecoController(EnderecoService EnderecoService)
        {
            _EnderecoService = EnderecoService;
        }
        [HttpGet]
        public JsonResult Get()
        {
            var Endereco = _EnderecoService.FindAll();
            string json = JsonConvert.SerializeObject(Endereco);
            return Json(json);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var Endereco = _EnderecoService.FindById(id);
            string json = JsonConvert.SerializeObject(Endereco);
            return Json(json);
        }
        [HttpPost]
        public ActionResult<Endereco> Post(Endereco Endereco)
        {
            _EnderecoService.InsertAsync(Endereco);
            return CreatedAtAction(nameof(Get), new { id = Endereco.Id }, Endereco);
        }
        [HttpDelete("{id}")]
        public ActionResult<Endereco> Delete(int id)
        {
            _EnderecoService.Remove(id);
            return CreatedAtAction(nameof(Get), new { id = id });

        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, Endereco Endereco)
        //{
        //    if (id != Endereco.Id)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        await _EnderecoService.Update(Endereco);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        var cs = _EnderecoService.FindById(id);
        //        if (cs.Id == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return CreatedAtAction(nameof(Get), new { id = id });
        //}

    }
}