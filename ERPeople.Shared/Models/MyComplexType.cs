using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ERPeople.Shared.Models
{
    public class MyComplexType
    {
        [FromQuery]
        public int Id { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string Language { get; set; }

        [BindProperty(SupportsGet = true, Name = "test")]
        public bool isTest { get; set; }

        public int[] Marks { get; set; }

        public Dictionary<string, int> Score { get; set; }
    }
}
