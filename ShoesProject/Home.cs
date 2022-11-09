using ShoesProject.UserControls;
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
        public Home()
        {
            InitializeComponent();
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

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Account account = new UC_Account(); 
            addUserControl(account); 
        }

        private void Home_Load(object sender, EventArgs e)
        {

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
    }
}
