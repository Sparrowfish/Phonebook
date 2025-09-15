using System;
using System.Collections.Generic;
using PhoneBook.Datalayer.DTOs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Datalayer.Repositroy
{
    public interface IPeople
    {
        bool Insert(PeopleViewModel entity);
        List<PeopleViewModel> GetAll();
        List<PeopleViewModel> Search(string parameter);
        void Delete(int Id);
        bool Edit(PeopleViewModel entity);
    }
}
