using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        public Boolean validate()
        {
            string name = txtName.Text;
            string pass = txtPass.Text;
            if(name == "")
            {
                txtError.Text = "Username cannot be required";
                return false;
            }
            if(pass == "")
            {
                txtError.Text = "Password cannot be required";
                return false;
            }
            txtError.Text = "";
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean result = validate();
            
        }
    }
}
