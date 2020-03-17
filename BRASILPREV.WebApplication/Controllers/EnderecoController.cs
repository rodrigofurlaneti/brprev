using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BRASILPREV.WebApplication.Models;
using BRASILPREV.WebApplication.Service;
using BRASILPREV.WebApplication.Controllers.Exceptions;

namespace BRASILPREV.WebApplication.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoService _EnderecoService;
        public EnderecoController(EnderecoService EnderecoService)
        {
            _EnderecoService = EnderecoService;
        }

        //Index - Assincrono
        public async Task<IActionResult> Index()
        {
            return View(await _EnderecoService.FindAllAsync());
        }

        //Create - Sincrono
        public IActionResult Create()
        {
            return View();
        }

        //Create - Assincrono
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Endereco Endereco)
        {
            await _EnderecoService.InsertAsync(Endereco);
            return RedirectToAction(nameof(Index));
        }

        //Details - Assincrono
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Endereco = await _EnderecoService.FindByIdAsync(id.Value);
            if (Endereco == null)
            {
                return NotFound();
            }
            return View(Endereco);
        }

        //Delete - Assincrono
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Endereco = await _EnderecoService.FindByIdAsync(id.Value);
            if (Endereco == null)
            {
                return NotFound();
            }
            return View(Endereco);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _EnderecoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Edit - Assincrono
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Endereco = await _EnderecoService.FindByIdAsync(id.Value);
            if (Endereco == null)
            {
                return NotFound();
            }
            return View(Endereco);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Endereco Endereco)
        {
            if (id != Endereco.Id)
            {
                return BadRequest();
            }
            try
            {
                await _EnderecoService.Update(Endereco);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}