using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRASILPREV.WebApplication.Dal;
using BRASILPREV.WebApplication.Models;
using BRASILPREV.WebApplication.Controllers;
using BRASILPREV.WebApplication.Controllers.Exceptions;

namespace BRASILPREV.WebApplication.Service
{
    public class TelefoneService
    {
        private ApplicationDbContext context;
        public TelefoneService(ApplicationDbContext _context)
        {
            context = _context;
        }
        //Sincrono - FindAll()
        public List<Telefone> FindAll()
        {
            return context.Telefone.ToList();
        }

        //Sincrono - Dispose()
        public void Dispose()
        {
            context.Dispose();
        }

        //Assincrono - FindAllAsync()
        public async Task<List<Telefone>> FindAllAsync()
        {
            return await context.Telefone.ToListAsync();
        }

        //Assincrono - InsertAsync(Telefone obj)
        public async Task InsertAsync(Telefone obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
        }

        //Sincrono - FindById(int id)
        public Telefone FindById(int id)
        {
            return context.Telefone.FirstOrDefault(o => o.Id == id);
        }

        //Assincrono
        public async Task<Telefone> FindByIdAsync(int id)
        {
            return await context.Telefone.FirstOrDefaultAsync(o => o.Id == id);
        }

        //Assincrono
        public async Task RemoveAsync(int id)
        {
            var obj = await context.Telefone.FindAsync(id);
            context.Telefone.Remove(obj);
            await context.SaveChangesAsync();
        }

        //Assincrono
        public async Task Update(Telefone obj)
        {
            bool hasAny = await context.Telefone.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                context.Update(obj);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
