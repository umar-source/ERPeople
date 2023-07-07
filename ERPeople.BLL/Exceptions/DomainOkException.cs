using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Exceptions
{
    public class DomainOkException : DomainException
    {
        public DomainOkException(string message) : base(message)
        {
        }
    }
}
