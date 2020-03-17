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
    public class PessoaService
    {
        private ApplicationDbContext context;
        public PessoaService(ApplicationDbContext _context)
        {
            context = _context;
        }
        //Sincrono - FindAll()
        public List<Pessoa> FindAll()
        {
            return context.Pessoa.ToList();
        }

        //Sincrono - Dispose()
        public void Dispose()
        {
            context.Dispose();
        }

        //Assincrono - FindAllAsync()
        public async Task<List<Pessoa>> FindAllAsync()
        {
            return await context.Pessoa.OrderBy(x => x.Nome).ToListAsync();
        }

        //Assincrono - InsertAsync(Pessoa obj)
        public async Task InsertAsync(Pessoa obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
        }

        //Sincrono - FindById(int id)
        public Pessoa FindById(int id)
        {
            return context.Pessoa.FirstOrDefault(o => o.Id == id);
        }

        //Assincrono
        public async Task<Pessoa> FindByIdAsync(int id)
        {
            return await context.Pessoa.FirstOrDefaultAsync(o => o.Id == id);
        }

        //Assincrono
        public async Task RemoveAsync(int id)
        {
            var obj = await context.Pessoa.FindAsync(id);
            context.Pessoa.Remove(obj);
            await context.SaveChangesAsync();
        }

        //Assincrono
        public async Task Update(Pessoa obj)
        {
            bool hasAny = await context.Pessoa.AnyAsync(x => x.Id == obj.Id);
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
