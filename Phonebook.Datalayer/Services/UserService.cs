using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Datalayer.DTOs;
using PhoneBook.Datalayer.Entities.User;
using PhoneBook.Datalayer.Repository;
using Phonebook.Datalayer.Model;
using Microsoft.EntityFrameworkCore;
using Phonebook.Datalayer.DTOs;

namespace Phonebook.Datalayer.Services
{
    public class UserService : IUser
    {
        public bool Authorization(string UserName)
        {
            MyDbContext DB = new MyDbContext();
            int RoleId = DB.Users.FirstOrDefault(x => x.UserName == UserName).RoleId;
            if(RoleId != 2)
            {
                return true;
            }
            return false;
        }

        public bool ChangedPass(string userName, string oldPassword, string newPassword)
        {
            using var db = new MyDbContext();

            var user = db.Users.FirstOrDefault(x => x.UserName == userName && x.Password == oldPassword);
            if (user != null)
            {
                user.Password = newPassword; 
                return true;
            }
            return false;
        }

        public bool VerifyPassword(string userName, string password)
        {

            MyDbContext DB = new MyDbContext();

            var user = DB.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            return user != null;
        }


        bool PassMatch(string newPassword, string repeatPassword)
        {
            return newPassword == repeatPassword;
        }

        public User SelectUserByPassword(string UserName, string password)
        {
            MyDbContext DB = new MyDbContext();
            User userViewModel = new User();

            User user = DB.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == password);
            if (user != null)
            {
                userViewModel.UserName = user.UserName;
                userViewModel.FullFamily = user.FullFamily;
                return userViewModel;
            }
            return null;
        }

        UserViewModel IUser.SelectUserByPassword(string UserName, string password)
        {
            throw new NotImplementedException();
        }

        bool IUser.Insert(User entity)
        {
            MyDbContext DB = new MyDbContext();

            DB.Users.Add(entity);
            DB.SaveChanges();
            return true;
        }
    } 
}
