using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Datalayer.DTOs;
using PhoneBook.Datalayer.Entities.User;

namespace Phonebook.Datalayer.Model
{
    public class MyDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PeopleViewModel> People { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=UniContact_DB;Integrated Security=True");
            }
        }



    }
}
