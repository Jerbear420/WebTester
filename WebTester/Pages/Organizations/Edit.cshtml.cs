using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Pages.Organizations
{
    public class EditModel(IOrganizationRepository organizationRepository, IWebHostEnvironment webHostEnvironment) : PageModel
    {
        [BindProperty]
        public IFormFile? Photo {  get; set; }
        [BindProperty]
        public Organization? Organization { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Organization = organizationRepository.GetOrganization(id.Value);
            }
            else
            {
                Organization = new Organization() { Title = ""};
            }
            if (Organization == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Organization.Image != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", Organization.Image);
                        System.IO.File.Delete(filePath);
                    }
                    Organization.Image = ProcessUploadedFile();
                }
                if (Organization.Id > 0)
                {
                    Organization = organizationRepository.Update(Organization);
                } else
                {
                    Organization = organizationRepository.Add(Organization);
                }
                return RedirectToPage("Index");
            } 
            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
