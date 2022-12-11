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
        DTO_PhanQuyen quyen;
        public Home(string username)
        {
            InitializeComponent();
            employee = getEmployee(username);
            //labelName.Text = employee.Username;
            quyen = GetPhanQuyen();
            
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
            em.Permission = dt.Rows[0][8].ToString();
            return em;
        }

        private DTO_PhanQuyen GetPhanQuyen()
        {
           
            DTO_PhanQuyen tmp = new DTO_PhanQuyen();
            DataTable dt = DAO_PhanQuyen.Instance.getPhanQuyen(employee.Permission);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                string[] words = dt.Rows[i][1].ToString().Split(' ');
               
                if (words[0] == "CN1")
                    tmp.QLSP1 = "Accept";
                if (words[0] == "CN2")
                    tmp.QLKH1 = "Accept";
                if (words[0] == "CN3")
                    tmp.QLNV1 = "Accept";
                if (words[0] == "CN4")
                    tmp.QLTL1 = "Accept";
                if (words[0] == "CN5")
                    tmp.QLHD1 = "Accept";
                if (words[0] == "CN6")
                    tmp.TKKD1 = "Accept";
                if (words[0] == "CN7")
                    tmp.TKSP1 = "Accept";
                if (words[0] == "CN8")
                    tmp.QLPQ1 = "Accept";
                if (words[0] == "CN9")
                    tmp.BanHang1 = "Accept";
               
            }
            return tmp;
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
            if(quyen.QLSP1 == "Accept")
            {
                UC_Products products = new UC_Products();
                addUserControl(products);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (quyen.QLNV1 == "Accept")
            {
                UC_Employee employee = new UC_Employee();
                addUserControl(employee);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (quyen.QLKH1 == "Accept")
            {
                UC_Customers customers = new UC_Customers();
                addUserControl(customers);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (quyen.QLHD1 == "Accept")
            {
                UC_Bills.Instance.AddEmplooyee(employee);
                addUserControl(UC_Bills.Instance);
                UC_Bills.Instance.loadTable("loadalldata");
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (quyen.TKSP1 == "Accept")
            {
                UC_TKSP tksp = new UC_TKSP();
                addUserControl(tksp);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (quyen.TKKD1 == "Accept")
            {
                UC_TKKD tkkd = new UC_TKKD();
                addUserControl(tkkd);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (quyen.TKKD1 == "Accept")
            {
                UC_Genres uc = new UC_Genres();
                addUserControl(uc);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm rf = new LoginForm();
            rf.ShowDialog();
            this.Close();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (quyen.QLPQ1 == "Accept")
            {
                UC_PhanQuyen uc = new UC_PhanQuyen();
                addUserControl(uc);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            addUserControl(UC_QLQuyen.Instance);
            UC_QLQuyen.Instance.loadTable();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (quyen.QLPQ1 == "Accept")
            {
                UC_BanHang ucbh = new UC_BanHang();
                addUserControl(ucbh);
            }
            else
            {
                MessageBox.Show("Ban không được phép truy cập vào đây");
            }
        }
    }
}
