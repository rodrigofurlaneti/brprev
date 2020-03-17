using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BRASILPREV.WebApplication.Models;
using BRASILPREV.WebApplication.Service;
using BRASILPREV.WebApplication.Controllers.Exceptions;

namespace BRASILPREV.WebApplication.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaService _PessoaService;
        public PessoaController(PessoaService PessoaService)
        {
            _PessoaService = PessoaService;
        }

        //Index - Assincrono
        public async Task<IActionResult> Index()
        {
            return View(await _PessoaService.FindAllAsync());
        }

        //Create - Sincrono
        public IActionResult Create()
        {
            return View();
        }

        //Create - Assincrono
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa Pessoa)
        {
            await _PessoaService.InsertAsync(Pessoa);
            return RedirectToAction(nameof(Index));
        }

        //Details - Assincrono
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Pessoa = await _PessoaService.FindByIdAsync(id.Value);
            if (Pessoa == null)
            {
                return NotFound();
            }
            return View(Pessoa);
        }

        //Delete - Assincrono
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Pessoa = await _PessoaService.FindByIdAsync(id.Value);
            if (Pessoa == null)
            {
                return NotFound();
            }
            return View(Pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _PessoaService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Edit - Assincrono
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Pessoa = await _PessoaService.FindByIdAsync(id.Value);
            if (Pessoa == null)
            {
                return NotFound();
            }
            return View(Pessoa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pessoa Pessoa)
        {
            if (id != Pessoa.Id)
            {
                return BadRequest();
            }
            try
            {
                await _PessoaService.Update(Pessoa);
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