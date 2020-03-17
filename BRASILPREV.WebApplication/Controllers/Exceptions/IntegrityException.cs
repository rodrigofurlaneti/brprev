using System;
namespace BRASILPREV.WebApplication.Controllers.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }
}
