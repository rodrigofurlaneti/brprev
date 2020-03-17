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
    public class EnderecoService
    {
        private ApplicationDbContext context;
        public EnderecoService(ApplicationDbContext _context)
        {
            context = _context;
        }
        //Sincrono - FindAll()
        public List<Endereco> FindAll()
        {
            return context.Endereco.ToList();
        }

        //Sincrono - Dispose()
        public void Dispose()
        {
            context.Dispose();
        }

        //Assincrono - FindAllAsync()
        public async Task<List<Endereco>> FindAllAsync()
        {
            return await context.Endereco.ToListAsync();
        }

        //Assincrono - InsertAsync(Endereco obj)
        public async Task InsertAsync(Endereco obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
        }

        //Sincrono - FindById(int id)
        public Endereco FindById(int id)
        {
            return context.Endereco.FirstOrDefault(o => o.Id == id);
        }

        //Assincrono
        public async Task<Endereco> FindByIdAsync(int id)
        {
            return await context.Endereco.FirstOrDefaultAsync(o => o.Id == id);
        }

        //Assincrono
        public async Task RemoveAsync(int id)
        {
            var obj = await context.Endereco.FindAsync(id);
            context.Endereco.Remove(obj);
            await context.SaveChangesAsync();
        }

        //Assincrono
        public async Task Update(Endereco obj)
        {
            bool hasAny = await context.Endereco.AnyAsync(x => x.Id == obj.Id);
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
