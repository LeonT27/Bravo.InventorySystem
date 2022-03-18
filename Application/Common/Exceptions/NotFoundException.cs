using System;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, int id) : base($"{name}, Id: {id} no fue encontrado.") { }
    }
}
