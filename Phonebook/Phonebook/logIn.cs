using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phonebook.Datalayer.Services;
using Phonebook.Datalayer.DTOs;
using Phonebook.Datalayer.Converter;
using Phonebook.Datalayer.Repositroy;
using PhoneBook.Datalayer.Entities.User;

namespace Phonebook
{
    public partial class logIn : Form
    {
       
        public logIn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("لطفا نام کاربری و رمزعبور را وارد کنید");
                errorProvider1.SetError(txtUsername, "*");
                errorProvider1.SetError(txtPassword, "*");
                txtUsername.Focus();
                return;
            }

            UserViewModel UserVm = new UserViewModel();

            if (UserVm != null)
            {
                this.Hide();
                CurrentUser.UserName = UserVm.UserName;
                CurrentUser.FullFamily = UserVm.FullFamily;
                MainForm frm = new MainForm();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمزعبور اشتباه است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
