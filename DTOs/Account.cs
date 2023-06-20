using BusinessObjects;

namespace DTOs
{
    public class Account
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static Account? ToAccount(TourGuide? t)
        {
            if (t == null)
            {
                return null;
            }
            Account res = new Account();
            res.Email = t.Email;
            res.ID = t.Id;
            res.Password = t.Password;
            return res;
        }
    }
}
