using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TesteSimonides2.Models;

namespace TesteSimonides2.Repositories
{
    public class LoginRepository
    {
        public static User Get(string nome, string password)
        {
            var users = new List<User>
            {
                new() { Id = 1, Email = "batman@gmail.com", Password = "batman"},
                new() { Id = 2, Email = "robin@gmail.com", Password = "robin"}
            };
            return users.FirstOrDefault(x => string.Equals(x.Email, nome, System.StringComparison.CurrentCultureIgnoreCase) && x.Password == password);
        }
    }
}
