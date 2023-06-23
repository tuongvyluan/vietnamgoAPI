using BusinessObjects;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.Net.Http.Headers;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient client;
        private string TourGuideApiUrl = "";
        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            TourGuideApiUrl = "https://localhost:5000/api/Login/TourGuide";
        }
        [BindProperty]
        public Account Account { get; set; } = default!;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            try
            {
                TourGuide data = new TourGuide();
                data.Email = Account.Email;
                data.Password = Account.Password;
                var found = TourGuideRepository.Login(data);
                if (found != null)
                {
                    HttpContext.Session.SetInt32("ID", found.Id);

                    return RedirectToPage("./Index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
