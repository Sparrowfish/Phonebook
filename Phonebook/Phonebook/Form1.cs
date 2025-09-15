using Phonebook.Datalayer.Services;
using PhoneBook.Datalayer.Entities.User;
using PhoneBook.Datalayer.Repository;
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
    public partial class addNewUser : Form
    {
        private IUser _userService;

        public addNewUser()
        {
            InitializeComponent();
            _userService = new UserService();

            
            cmbSex.Items.Add("مرد");
            cmbSex.Items.Add("زن");

            PopulateRoles();
        }

        private void PopulateRoles()
        {
            cmbRole.Items.Add(new ComboBoxItem("ادمین", 1));
            cmbRole.Items.Add(new ComboBoxItem("مهمان", 2));

            // Optionally set DisplayMember and ValueMember if using data binding
            cmbRole.DisplayMember = "Text";
            cmbRole.ValueMember = "Value";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = textUsername.Text;
            string fullFamily = textName.Text;
            string sex = cmbSex.SelectedItem?.ToString();
            string nationalID = textId.Text;
            DateTime birthDay = DateTime.Parse(textBirthday.Text);
            string mobile = textMobile.Text;
            string email = textEmail.Text;
            string password = textPass.Text;
            int roleId = (int)cmbRole.SelectedValue;


            if (sex == null)
            {
                MessageBox.Show("لطفا جنسیت را انتخاب کنید");
                return;
            }

            User newUser = new User
            {
                UserName = userName,
                FullFamily = fullFamily,
                Sex = sex,
                NationalID = nationalID,
                BirthDay = birthDay,
                Mobile = mobile,
                Email = email,
                Password = password,
                RoleId = roleId
            };

            bool isSuccess = _userService.Insert(newUser);

            if (isSuccess)
            {
                MessageBox.Show("کاربر با موفقیت افزوده شد");
                this.Close();
            }
            else
            {
                MessageBox.Show("کاربر افزوده نشد");
            }
        }
    }
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
