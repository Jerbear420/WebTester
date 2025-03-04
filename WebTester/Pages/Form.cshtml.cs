using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace WebTester.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public string? HeaderTitle { get; set; }
        public void OnGet()
        {
            HeaderTitle = "Title here";
        } 

    }
}
