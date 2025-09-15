using Phonebook.Datalayer.Repositroy;
using PhoneBook.Datalayer.DTOs;
using PhoneBook.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Datalayer.Model;

namespace Phonebook.Datalayer.Services
{
    public class PeopleService : IPeople
    {
        private readonly MyDbContext _context;

        public PeopleService()
        {
            _context = new MyDbContext();
        }

        public bool Insert(PeopleViewModel entity)
        {
            try
            {
                _context.People.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PeopleViewModel> GetAll()
        {
            return _context.People.ToList();
        }

        public List<PeopleViewModel> Search(string parameter)
        {
            return _context.People
                           .Where(p => p.Name.Contains(parameter) ||
                                       p.Family.Contains(parameter) ||
                                       p.Mobile.Contains(parameter) ||
                                       p.Email.Contains(parameter))
                           .ToList();
        }

        public void Delete(int Id)
        {
            var person = _context.People.Find(Id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
        }

        public bool Edit(PeopleViewModel entity)
        {
            var person = _context.People.Find(entity.UserId);
            if (person != null)
            {
                person.Name = entity.Name;
                person.Family = entity.Family;
                person.Sex = entity.Sex;
                person.BirthDay = entity.BirthDay;
                person.Mobile = entity.Mobile;
                person.Email = entity.Email;

                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
