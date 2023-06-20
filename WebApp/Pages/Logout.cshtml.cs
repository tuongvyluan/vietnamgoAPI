using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LogoutModel : PageModel
    {
        public ActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("./Login");
        }
    }
}
