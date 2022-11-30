﻿using ShoesProject.UserControls;
using ShoesProject.UserControls.Bills;
using ShoesProject.UserControls.TKKD;
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
            BillsManagement bills = new BillsManagement();
            addUserControl(bills);
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
    }
}
