using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;
using WebTester.Services.Organizations.Repositories;

namespace WebTester.Pages.Employees
{
    public class EditModel(IOrganizationRepository organizationRepository, IEmployeeRepository employeeRepository) : PageModel
    {
        [BindProperty]
        public Employee? Employee { get; set; }

        public List<SelectListItem>? OrgList { get; set; }
        [BindProperty]
        public Organization organization { get; set; }
        public IActionResult OnGet(int? id)
        {
            BuildListItems();

            if (id.HasValue)
            {
                Employee = employeeRepository.Get(id.Value); 
            }
            else
            {
                Employee = new Employee
                {
                    FirstName = "",
                    LastName = "",
                    PrimaryEmail = "",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                    
                };
            }

            return Page();
        }

        private void BuildListItems()
        {
            OrgList = organizationRepository.GetAllOrganizations()
                .Select(org => new SelectListItem(value: org.Id.ToString(), text: org.Title))
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
             
                if (Employee.Id > 0)
                {
                    employeeRepository.Update(Employee);
                }
                else
                {
                    employeeRepository.Add(Employee);
                }

                return RedirectToPage("Index");
            }

            BuildListItems(); // Ensure dropdown is repopulated if validation fails
            return Page();
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using WebTester.Models.Organizations;
//using WebTester.Services.Organizations.Interfaces;

//namespace WebTester.Pages.Employees
//{
//    public class EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment) : PageModel
//    {
//        [BindProperty]
//        public IFormFile? Photo {  get; set; }
//        [BindProperty]
//        public Employee? Employee { get; set; }

//        public IActionResult OnGet(int? id)
//        {
//            if (id.HasValue)
//            {
//                Employee = employeeRepository.Get(id.Value);
//            }
//            else
//            {
//                Employee = new Employee() { FirstName = "", LastName = "", PrimaryEmail = ""};
//            }
//            if (Employee == null)
//            {
//                return RedirectToPage("/NotFound");
//            }

//            return Page();

//        }

//        public IActionResult OnPost()
//        {
//            if (ModelState.IsValid)
//            {
//                if (Photo != null)
//                {
//                    if (Employee.Image != null)
//                    {
//                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", Employee.Image);
//                        System.IO.File.Delete(filePath);
//                    }
//                    Employee.Image = ProcessUploadedFile();
//                }
//                if (Employee.Id > 0)
//                {
//                    Employee = employeeRepository.Update(Employee);
//                } else
//                {
//                    Employee = employeeRepository.Add(Employee);
//                }
//                return RedirectToPage("Index");
//            }
//            return Page();
//        }

//        private string ProcessUploadedFile()
//        {
//            string uniqueFileName = null;
//            if (Photo != null)
//            {
//                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
//                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
//                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    Photo.CopyTo(fileStream);
//                }
//            }
//            return uniqueFileName;
//        }
//    }
//}
