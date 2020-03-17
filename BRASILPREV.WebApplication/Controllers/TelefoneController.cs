using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BRASILPREV.WebApplication.Models;
using BRASILPREV.WebApplication.Service;
using BRASILPREV.WebApplication.Controllers.Exceptions;

namespace BRASILPREV.WebApplication.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly TelefoneService _TelefoneService;
        public TelefoneController(TelefoneService TelefoneService)
        {
            _TelefoneService = TelefoneService;
        }

        //Index - Assincrono
        public async Task<IActionResult> Index()
        {
            return View(await _TelefoneService.FindAllAsync());
        }

        //Create - Sincrono
        public IActionResult Create()
        {
            return View();
        }

        //Create - Assincrono
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Telefone Telefone)
        {
            await _TelefoneService.InsertAsync(Telefone);
            return RedirectToAction(nameof(Index));
        }

        //Details - Assincrono
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Telefone = await _TelefoneService.FindByIdAsync(id.Value);
            if (Telefone == null)
            {
                return NotFound();
            }
            return View(Telefone);
        }

        //Delete - Assincrono
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Telefone = await _TelefoneService.FindByIdAsync(id.Value);
            if (Telefone == null)
            {
                return NotFound();
            }
            return View(Telefone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _TelefoneService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Edit - Assincrono
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Telefone = await _TelefoneService.FindByIdAsync(id.Value);
            if (Telefone == null)
            {
                return NotFound();
            }
            return View(Telefone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Telefone Telefone)
        {
            if (id != Telefone.Id)
            {
                return BadRequest();
            }
            try
            {
                await _TelefoneService.Update(Telefone);
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