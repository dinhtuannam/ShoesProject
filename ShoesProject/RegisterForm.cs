using ShoesProject.DAO;
using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ShoesProject
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                string username = txtName.Text;
                string password = txtPassword.Text;
                string fullname = txtFullname.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;
                DTO_Employee em = new DTO_Employee("",username,password,"","",fullname,phone,address,email);
                bool data = DAO_Employee.Instance.Register(em);
                if (data)
                {
                    MessageBox.Show("Register Success");
                }
                else
                {
                    MessageBox.Show("Something wrong please try again");
                }
            }
        }

        private Boolean validate()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtEmail.Text);
            if (txtName.Text == "")
            {
                txtError.Text = "Username cannot be required";
                return false;
            }
            if (txtPassword.Text == "")
            {
                txtError.Text = "Password cannot be required";
                return false;
            }
            /*if (txtPassword.Text.Length < 6)
            {
                txtError.Text = "Password ";
                return false;
            }*/
            if (txtPassword.Text != txtRePassword.Text)
            {
                txtError.Text = "Password not match";
                return false;
            }
            if (txtFullname.Text == "")
            {
                txtError.Text = "Fullname cannot be required";
                return false;
            }
            if (txtPhone.Text == "")
            {
                txtError.Text = "Phone number cannot not be required";
                return false;
            }
            if (!match.Success)
            {
                txtError.Text = "Email is not correct";
                return false;
            }
            if (txtAddress.Text == "")
            {
                txtError.Text = "Address cannot not be required";
                return false;
            }
            if (DAO_Employee.Instance.isUserNameExist(txtName.Text))
            {
                txtError.Text = "Username already used";
                return false;
            }
            txtError.Text = "";
            return true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "Username")
                txtName.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
                txtPassword.Text = "";
        }

        private void txtFullname_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "Fullname")
                txtFullname.Text = "";
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Phone number")
                txtPhone.Text = "";
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
                txtEmail.Text = "";
        }

        private void txtAddress_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "Address")
                txtAddress.Text = "";
        }

        private void txtRePassword_Click(object sender, EventArgs e)
        {
            if (txtRePassword.Text == "Re-password")
                txtRePassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm rf = new LoginForm();
            rf.ShowDialog();
            this.Close();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if(txtName.Text == "Username")
            {
                txtName.Text = "";
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text != "Password")
            {
                txtPassword.PasswordChar = '*';
            }
            else
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtRePassword_Enter(object sender, EventArgs e)
        {
            if(txtRePassword.Text == "Re-password")
            {
                txtRePassword.Text = "";
            }
        }

        private void txtRePassword_Leave(object sender, EventArgs e)
        {
            if(txtRePassword.Text == "")
            {
                txtRePassword.Text = "Re-password";
            }
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if(txtRePassword.Text != "Re-password")
            {
                txtRePassword.PasswordChar = '*';
            }
            else
            {
                txtRePassword.PasswordChar = '\0';
            }
        }

        private void txtFullname_Enter(object sender, EventArgs e)
        {
            if(txtFullname.Text == "Fullname")
            {
                txtFullname.Text = "";
            }
        }

        private void txtFullname_Leave(object sender, EventArgs e)
        {
            if(txtFullname.Text == "")
            {
                txtFullname.Text = "Fullname";
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if(txtPhone.Text == "Phone number")
            {
                txtPhone.Text = "";
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if(txtPhone.Text == "")
            {
                txtPhone.Text = "Phone number";
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if(txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if(txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if(txtAddress.Text == "Address")
            {
                txtAddress.Text = "";
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if(txtAddress.Text == "") {
                txtAddress.Text = "Address";
            }
        }
    }
}
