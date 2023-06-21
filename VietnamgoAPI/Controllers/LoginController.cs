using BusinessObjects;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] Account account)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    Customer t = new Customer();
                    t.Email = account.Email;
                    t.Password = account.Password;
                    var user = CustomerRepository.Login(t);
                    if (user == null)
                    {
                        return NotFound("user not found");
                    }
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("TourGuide")]
        public ActionResult PostTourGuide([FromBody] Account account)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    TourGuide t = new TourGuide();
                    t.Email = account.Email;
                    t.Password = account.Password;
                    var user = TourGuideRepository.Login(t);
                    if (user == null)
                    {
                        return NotFound("user not found");
                    }
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
