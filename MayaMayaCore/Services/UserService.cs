using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayaMayaCore.Data;
using MayaMayaCore.Models;

namespace MayaMayaCore.Services
{
    public class UserService
    {
        public bool CheckCredentials(string username,string password,out int id)
        {
            using (DatabaseEntities context  = new DatabaseEntities())
            {
                id = (from user in context.Users
                    where user.Username == username && user.Password == password
                    select user.Id).SingleOrDefault();
                if (id == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public UserModel GetUser(int id)
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
                UserModel user = (from u in context.Users
                            where u.Id == id
                            select new UserModel()
                            {
                                Username = u.Username,
                                Firstname = u.Firstname,
                                LastLogin = u.LastLogin.Value,
                                Lastname = u.Lastname,
                                Roles = (from ur in context.UserHasRole
                                         join r in context.Roles on ur.Role equals r.Id
                                         where ur.UserId == id
                                         select r.Name).ToList()
                            }).SingleOrDefault();
                return user;
            }
           
        }
    }
}
