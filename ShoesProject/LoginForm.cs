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
                if (String.Equals(permission, "AD"))
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

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtName.Text == "Username")
                txtName.Text = "";
        }

        private void txtPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPass.Text == "Password")
                txtPass.Text = "";
        }
    }
}
