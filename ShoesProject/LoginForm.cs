using ShoesProject.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

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
            if(validate() && login())
            {
                this.Hide();
                Home home = new Home(txtName.Text);
                home.ShowDialog();
                this.Close();
            }
        }

        private Boolean login()
        {
            string name = txtName.Text;
            string pass = txtPass.Text;
            DataTable dt = DAO_Employee.Instance.Login(name, pass);
            if (dt.Rows.Count <= 0)
            {
                txtError.Text = "Username or Password not correct";
                return false;
            }
            else
            {
                string text = Convert.ToString( dt.Rows[0][4] );
                string[] subs = text.Split(' ');
                string permission = subs[0];
                if (String.Equals(permission, "AD") || String.Equals(permission, "NV"))
                    return true;
                else
                {
                    MessageBox.Show("You dont have permission to login here");
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm rf = new RegisterForm();
            rf.ShowDialog();
            this.Close();
        }

  

       

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Username")
                txtName.Text = "";
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if(txtName.Text == "")
                txtName.Text = "Username";
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
                txtPass.Text = "";
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
                txtPass.Text = "Password";
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if(txtPass.Text != "Password")
            {
                txtPass.PasswordChar = '*';
            }
            else
            {
                txtPass.PasswordChar = '\0';
            }
            
        }

        private void LoginForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (validate() && login())
                {
                    this.Hide();
                    Home home = new Home(txtName.Text);
                    home.ShowDialog();
                    this.Close();
                }
            }
        }

        private void txtPass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (validate() && login())
                {
                    this.Hide();
                    Home home = new Home(txtName.Text);
                    home.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
