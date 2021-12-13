namespace TestProject.Models
{
    public class AccountData
    {
        public string Email { get; }
        public string Password { get; }

        public AccountData(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}