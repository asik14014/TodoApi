using System;

namespace TodoApi.Models
{
    public class UserModel
    {
        public UserModel()
        { }

        public UserModel(int id, string name, string email, string password)
        { 
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public int Id;

        public string Name;

        public string Email;

        public string Password;

    }
}