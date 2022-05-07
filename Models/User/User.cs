using System.Security.Cryptography;
using System.Text;

namespace Kursach.Models.User
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }

        private string Password { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            Id = Hasher();
        }

        private string Hasher()
        {
            using (MD5 md5 = MD5.Create())
            {
                string hash = "";
                byte[] logbytes = Encoding.UTF8.GetBytes(Login);
                byte[] passbytes = Encoding.UTF8.GetBytes(Password);

                byte[] computelogin = md5.ComputeHash(logbytes);
                byte[] computepassword = md5.ComputeHash(passbytes);


                foreach (var item in computelogin)
                {
                    hash += item.ToString();
                }
                foreach (var item in computepassword)
                {
                    hash += item.ToString();
                }

                return hash;
            }
        }
    }
}
