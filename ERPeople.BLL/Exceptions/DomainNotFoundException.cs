using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Exceptions
{
    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message) : base(message)
        {
        }
    }
}
