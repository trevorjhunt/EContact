using contacts.econtactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contacts
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }
        ContactClass c = new ContactClass();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get value from the input field
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNumber.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = comboBoxGender.Text;

            // inserting into the DB using the add method
            bool success = c.Insert(c);
            if (success)
            {
                MessageBox.Show("New contact added to the database");
                Clear();
            }
            else
            {
                MessageBox.Show("New contact was not added to the database. Try Again");
            }

            // Load the data into the data grid view
            DataTable dt = c.Select();
            dataGridViewContactList.DataSource = dt;

        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            // Load the data into the data grid view
            DataTable dt = c.Select();
            dataGridViewContactList.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //method to clear the fields
        public void Clear()
        {
            textBoxFirstName.Text = ""; 
            textBoxLastName.Text = "";
            textBoxContactNumber.Text ="";
            textBoxAddress.Text = "";
            comboBoxGender.Text = "";
            textBoxContactId.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Load data from the text boxes
            // convert string to int
            c.ContactID = int.Parse(textBoxContactId.Text);
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxFirstName.Text;
            c.ContactNo = textBoxContactNumber.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = comboBoxGender.Text;

            // update the data in the DB
            bool success = c.Update(c);
            if (success)
            {
                MessageBox.Show("Contact details updated successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to update contact. Try Again");
            }

            // Load the data into the data grid view
            DataTable dt = c.Select();
            dataGridViewContactList.DataSource = dt;

        }

        private void dataGridViewContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the data from the grid view into the text boxes 
            // identify the row on which the mouse was clicked
            int rowIndex = e.RowIndex;
            textBoxContactId.Text = dataGridViewContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridViewContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxContactNumber.Text = dataGridViewContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxAddress.Text = dataGridViewContactList.Rows[rowIndex].Cells[4].Value.ToString();
            comboBoxGender.Text = dataGridViewContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(textBoxContactId.Text);
            bool success = c.Delete(c);

            if(success)
            {
                MessageBox.Show("Contact details deleted");

                // refresh the data grid view
                DataTable dt = c.Select();
                dataGridViewContactList.DataSource = dt;

                // the text boxes
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to delete contact. Try Again");
            }
        }
    }
}
