using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phonebook.Datalayer.Repositroy;
using Phonebook.Datalayer.Services;
using Phonebook.Datalayer.DTOs;
using PhoneBook.Datalayer.DTOs;

namespace Phonebook
{
    public partial class addNewPerson : Form
    {
        private IPeople _peopleService;

        public addNewPerson()
        {
            InitializeComponent();
            _peopleService = new PeopleService();

            cmbSex.Items.Add("مرد");
            cmbSex.Items.Add("زن");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitNewPerson_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveNewPerson_Click(object sender, EventArgs e)
        {
            
            string name = txtName.Text;
            string family = txtFamily.Text;
            string sex = cmbSex.SelectedItem?.ToString();
            string birthDay = txtBirthDay.Text;
            string mobile = txtMobile.Text;
            string email = txtEmail.Text;

            
            PeopleViewModel newPerson = new PeopleViewModel
            {
                Name = name,
                Family = family,
                Sex = sex,
                BirthDay = birthDay,
                Mobile = mobile,
                Email = email
            };

            bool isSuccess = _peopleService.Insert(newPerson);

            if (isSuccess)
            {
                MessageBox.Show("شخص جدید با موفقیت افزوده شد");
                this.Close(); 
            }
            else
            {
                MessageBox.Show("افزودن شخص جدید انجام نشد");
            }
        }
    }
}
