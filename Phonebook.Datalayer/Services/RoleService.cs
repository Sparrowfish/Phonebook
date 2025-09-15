using PhoneBook.Datalayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Datalayer.Model;

namespace Phonebook.Datalayer.Services
{
    class RoleService : IRole
    {
        private readonly MyDbContext _context;

        public RoleService()
        {
            _context = new MyDbContext();
        }

        public List<string> GetRoles()
        {
            return _context.Roles
                           .Where(role => !role.IsDelete) // assuming you want to exclude deleted roles
                           .Select(role => role.RoleTitle)
                           .ToList();
        }
    }
}
