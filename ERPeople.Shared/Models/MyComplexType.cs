using Microsoft.AspNetCore.Mvc;

namespace ERPeople.Shared.Models
{
    public class MyComplexType
    {
        [FromQuery]
        public int Id { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string? Language { get; set; }

        [BindProperty(SupportsGet = true, Name = "test")]
        public bool? isTest { get; set; }

        public int[]? Marks { get; set; }

        public Dictionary<string, int>? Score { get; set; }
    }
}
