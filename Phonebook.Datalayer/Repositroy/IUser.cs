using System;
using System.Collections.Generic;
using PhoneBook.Datalayer.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Datalayer.DTOs;
using PhoneBook.Datalayer.Entities.User;

namespace PhoneBook.Datalayer.Repository
{
    public interface IUser
    {
        UserViewModel SelectUserByPassword(string UserName, string password);

        bool ChangedPass(string UserName, string Oldpassword, string Newpassword);

        bool Authorization(string UserName);
        bool Insert(User entity);


    }
}
