using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
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
            TourGuideApiUrl = "http://localhost:5000/api/Login";
        }
        [BindProperty]
        public TourGuide Account { get; set; } = default!;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var dir = Directory.GetCurrentDirectory();
                var config = new ConfigurationBuilder()
                    .SetBasePath(dir)
                                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                            .Build();
                var admin = config.GetSection("Admin");
                if (admin["Email"].Equals(Account.Email) && admin["Password"].Equals(Account.Password))
                {
                    HttpContext.Session.SetString("Email", admin["Email"]);
                    return RedirectToPage("./Index");
                }
                if (Account != null)
                {
                    var myContent = JsonConvert.SerializeObject(Account);
                    var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(myContent));
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await client.PostAsync(TourGuideApiUrl, byteContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var customerString = await response.Content.ReadAsStringAsync();
                        TourGuide customer = new TourGuide();
                        var c = JsonConvert.DeserializeObject<TourGuide>(customerString);
                        if (c != null)
                        {
                            customer = c;
                        }
                        if (customer.Email != null)
                        {
                            HttpContext.Session.SetInt32("ID", customer.Id);

                            return RedirectToPage("./Index");
                        }
                    }
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
