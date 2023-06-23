using BusinessObjects;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace VietnamgoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class RegisterController : Controller
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
                    t.Email = account.Email.ToLower();
                    if (CustomerRepository.CheckExistEmail(t.Email))
                    {
                        return BadRequest("This email has already been used.");
                    }
                    t.Password = account.Password;
                    if (account.FirstName == null)
                    {
                        return BadRequest("User first name is required!");
                    }
                    t.FirstName = account.FirstName;
                    t.MiddleName = account.MiddleName;
                    t.LastName = account.LastName;
                    CustomerRepository.SaveCustomer(t);
                    return Ok();
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
                    t.Email = account.Email.ToLower();
                    if (TourGuideRepository.CheckExistEmail(t.Email))
                    {
                        return BadRequest("This email has already been used.");
                    }
                    t.Password = account.Password;
                    if (account.FirstName == null)
                    {
                        return BadRequest("Tour guide first name is required!");
                    }
                    t.FirstName = account.FirstName;
                    t.MiddleName = account.MiddleName;
                    t.LastName = account.LastName;
                    TourGuideRepository.Create(t);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
