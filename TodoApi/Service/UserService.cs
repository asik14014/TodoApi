using System;
using TodoApi.Models;

namespace TodoApi.Service
{
    public class UserService
    {
        public UserModel GetUserByCredentials(string email, string password)
        {
            //TODO вытащить информацию по параметрам
            //var user = UserManager.FindUser(context.UserName, context.Password);

            if (email == "test@gmail.com" && password == "test")
            {
                return new UserModel(0, "Test", "test@gmail.com", "test");
            }

            return null;
        }
    }
}