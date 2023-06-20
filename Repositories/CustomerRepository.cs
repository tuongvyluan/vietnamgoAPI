using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CustomerRepository
    {
        public static Customer? Login(Customer account)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var user = _context.Customers.FirstOrDefault(u => u.Email.Equals(account.Email) && u.Password.Equals(account.Password));
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveCustomer(Customer Customer)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Customers.Add(Customer);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static void UpdateCustomer(Customer Customer)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Entry<Customer>(Customer).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Customer GetCustomer(int id)
        {
            Customer Customer = new Customer();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Customers.SingleOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Customer;
        }
    }
}
