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
using PhoneBook.Datalayer.DTOs;
using PhoneBook.Datalayer.Repository;

namespace Phonebook
{
    public partial class MainForm : Form
    {
        private IPeople People;
        private IUser User;
        
        public MainForm()
        {
            People = new PeopleService();
            User = new UserService();
            InitializeComponent();
            txtWelcome.Text = CurrentUser.FullFamily + " " + "خوش آمدید" + " " + DateTime.Now.ToShamsi();

            if (User.Authorization(CurrentUser.UserName))
            {
                toolStripLabel2.Visible = false;
                btnDelete.Enabled = false;
            }
        }

        private void افزودنشخصجدیدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addNewPerson newPerson = new addNewPerson();
            newPerson.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dataGridView1.DataSource = People.GetAll();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            addNewPerson newPerson = new addNewPerson();
            newPerson.ShowDialog();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            passChange passChangefrm = new passChange();
            passChangefrm.ShowDialog();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string parameter = textBoxSearch.Text.Trim();

            List<PeopleViewModel> searchResults = People.Search(parameter);

            dataGridView1.DataSource = searchResults;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = (int)dataGridView1.SelectedRows[0].Cells["UserId"].Value;
                var person = People.GetAll().FirstOrDefault(p => p.UserId == userId);

                if (person != null)
                {
                    // Assuming EditPersonForm constructor accepts PeopleViewModel and IPeople service
                    EditPerson editPersonFrm = new EditPerson(person, People);
                    var result = editPersonFrm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        BindGrid(); // Refresh the DataGridView after successful edit
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = (int)dataGridView1.SelectedRows[0].Cells["UserId"].Value;

          
                var confirmResult = MessageBox.Show("از حذف مطمئنید؟", "حذف اطلاعات", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    People.Delete(userId);
                    BindGrid(); // Refresh the DataGridView after deletion
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را برای حذف انتخاب کنید");
            }
        }
    }
}
