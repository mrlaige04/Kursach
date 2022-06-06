
using Kursach.Models.Spoonacular;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
namespace Kursach.Models.User
{
    public class User
    {
        [Key]
        public string hash { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public string recipes { get; set; }


        private ApplicationContext db;

        
        public List<MealFull> listrecipes = new List<MealFull>();


        public User(string login, string password, ApplicationContext db) : this(db)
        {
            this.login = login;
            this.password = password;
            hash = Hasher();
            
        }
        public User(ApplicationContext db)
        {
            this.db = db;
            reciper();
        }


        private string Hasher()
        {
            using (MD5 md5 = MD5.Create())
            {
                string hash = "";
                byte[] logbytes = Encoding.UTF8.GetBytes(login);
                byte[] passbytes = Encoding.UTF8.GetBytes(password);

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

        public void AddRecipe(MealFull meal, string login)
        {
            User curuser = db.Users.Where(user => user.login == login).First();

            if (curuser.recipes != null)
            {
                listrecipes = JsonSerializer.Deserialize<List<MealFull>>(curuser.recipes);
            }

            var isContain = (from i in listrecipes
                             where i.id == meal.id
                             select i).Count() > 0;
            if (!isContain)
            {
                listrecipes.Add(meal);
            }
            reciper();
            db.SaveChanges();
        }

        public void RemoveRecipe(string id, string login)
        {
            var curUser = db.Users.Where(user => user.login == login).First();
            if (curUser.recipes != null)
            {
                listrecipes = JsonSerializer.Deserialize<List<MealFull>>(curUser?.recipes);
            }
            listrecipes = (from i in listrecipes
                           where i.id.ToString() != id
                           select i).ToList();
            reciper();
            db.SaveChanges();
        }


        public override string ToString()
        {
            return "Login: " + login + " Password: " + password + " Recipes: " + recipes;
        }

        private void reciper()
        {
            if (listrecipes == null) listrecipes = new();
            recipes = JsonSerializer.Serialize(listrecipes.ToArray());
        }
    }
}
