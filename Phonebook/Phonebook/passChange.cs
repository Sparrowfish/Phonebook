using Phonebook.Datalayer.Services;
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
    public partial class passChange : Form
    {
        UserService userService = new UserService();
        public passChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtCurrentPass.Text;
            string oldPassword = txtNewPass.Text;
            string newPassword = txtNewPassRep.Text;

            if (userService.VerifyPassword(userName, oldPassword))
            {
                MessageBox.Show("رمزعبور اشتباه است");
                return; 
            }

         
            if (txtNewPass.Text != txtNewPassRep.Text)
            {
                MessageBox.Show("دو رمزعبور جدید مطابقت ندارند");
                return;
            }

            userService.ChangedPass(userName, oldPassword, newPassword);
            MessageBox.Show("رمزعبور تغییر یافت","تغییر رمز",MessageBoxButtons.OK);
            this.Close();



        }
    }
}
