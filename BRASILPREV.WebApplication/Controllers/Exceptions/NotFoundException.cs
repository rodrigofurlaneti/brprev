using System;
namespace BRASILPREV.WebApplication.Controllers
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
