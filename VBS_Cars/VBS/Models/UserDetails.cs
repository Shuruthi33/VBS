namespace VBS.Models
{
    public class UserDetails
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public int RoleId { get; set; }
        public string? ImagePath { get; set; }
    }

    public class UserCredential
    {
        public string? CustomerName { get; set; }
        public string? Password { get; set; }
    }

    public class ReturnSession {

        public UserDetails? resultData { get; set; }
    }
}
