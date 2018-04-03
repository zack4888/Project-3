using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_3_New
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void LoginSubmitButton_Click(object sender, EventArgs e)
        {
            string UserName = "home";
            string Password = "1234";
            if (UserNameTextBox.Text == UserName)
            {
                if (PasswordTextBox.Text == Password)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("That Password was incorrect.");
                }
            }
            else
            {
                MessageBox.Show("That Username was not found.");
            }
            
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
