
namespace Module7_TAM_V2.Model
{
    public class User
    {
        public readonly string email;
        public readonly string password;
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
