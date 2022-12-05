using ShoesProject.DAO;
using ShoesProject.DTO;
using ShoesProject.UserControls;
using ShoesProject.UserControls.Bills;

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
    public partial class Home : Form
    {
        DTO_Employee employee;
        public Home(string username)
        {
            InitializeComponent();
            employee = getEmployee(username);
            labelName.Text = employee.Username;
            

        }

        private DTO_Employee getEmployee(string name)
        {
            DataTable dt = DAO_Employee.Instance.getEmployeeByName(name);
            DTO_Employee em = new DTO_Employee();
            em.Id = dt.Rows[0][0].ToString();
            em.Username = dt.Rows[0][1].ToString();
            em.Password = dt.Rows[0][2].ToString();
            em.Fullname = dt.Rows[0][3].ToString();
            em.Phone = dt.Rows[0][4].ToString();
            em.Address = dt.Rows[0][5].ToString();
            em.Email = dt.Rows[0][6].ToString();
            em.Status = dt.Rows[0][7].ToString();
            return em;
        }

        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Products products = new UC_Products();
            addUserControl(products);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Employee employee = new UC_Employee(); 
            addUserControl(employee); 
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UC_Customers customers = new UC_Customers();
            addUserControl(customers);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BillsManagement.Instance.AddEmplooyee(employee);
            addUserControl(BillsManagement.Instance);
            BillsManagement.Instance.loadTable("loadalldata");
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UC_TKSP tksp = new UC_TKSP();
            addUserControl(tksp);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UC_TKKD tkkd = new UC_TKKD();
            addUserControl(tkkd);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_Genres uc = new UC_Genres();
            addUserControl(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm rf = new LoginForm();
            rf.ShowDialog();
            this.Close();
        }
    }
}
