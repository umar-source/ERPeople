using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Exceptions
{
    public class DomainBadRequestException : DomainException
    {
        public DomainBadRequestException(string message) : base(message)
        {
        }
    }
}
