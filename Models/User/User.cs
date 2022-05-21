using Kursach.Models.Meals;
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



        [NonSerialized]
        public List<Meal> listrecipes = new List<Meal>();


        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            hash = Hasher();
        }
        public User()
        {

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

        public void AddRecipe(Meal meal)
        {
            User curuser = new ApplicationContext().Users.Where(user => user.login == currentuser.LOGIN).First();
            
            if (curuser.recipes != null) { 
                listrecipes = JsonSerializer.Deserialize<List<Meal>>(curuser.recipes?.ToString()); 
            }

            var isContain = (from i in listrecipes
                             where i.idMeal == meal.idMeal
                             select i).Count() > 0;
            if (!isContain) { 
                listrecipes.Add(meal); 
            }
            reciper();
        }

        public void RemoveRecipe(Meal meal)
        {
            var curUser = new ApplicationContext().Users.Where(user => user.login == currentuser.LOGIN).First();
            if(curUser.recipes != null)
            {
                listrecipes = JsonSerializer.Deserialize<List<Meal>>(curUser?.recipes);
            }
            listrecipes = (from i in listrecipes
                          where i.idMeal != meal.idMeal
                          select i).ToList();
            listrecipes?.Remove(meal);
            reciper();
        }


        public override string ToString()
        {
            return "Login: " + login + " Password: " + password + " Recipes: " + recipes;
        }

        private void reciper()
        {
            recipes = JsonSerializer.Serialize(listrecipes);
        }
    }
}
