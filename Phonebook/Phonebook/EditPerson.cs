using Phonebook.Datalayer.Repositroy;
using Phonebook.Datalayer.Services;
using PhoneBook.Datalayer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class EditPerson : Form
    {
        private readonly IPeople _peopleService;
        private readonly PeopleViewModel _person;
        public EditPerson(PeopleViewModel person, IPeople peopleService)
        {
            InitializeComponent();
            _peopleService = peopleService;
            _person = person;
            cmbSex.Items.Add("مرد");
            cmbSex.Items.Add("زن");
            LoadPersonDetails();
        }

        private void LoadPersonDetails()
        {
            txtName.Text = _person.Name;
            txtFamily.Text = _person.Family;
            cmbSex.SelectedItem = _person.Sex;
            txtBirthDay.Text = _person.BirthDay;
            txtMobile.Text = _person.Mobile;
            txtEmail.Text = _person.Email;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _person.Name = txtName.Text;
            _person.Family = txtFamily.Text;
            _person.Sex = cmbSex.SelectedItem.ToString();
            _person.BirthDay = txtBirthDay.Text;
            _person.Mobile = txtMobile.Text;
            _person.Email = txtEmail.Text;

            if (_peopleService.Edit(_person))
            {
                MessageBox.Show("Person updated successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
