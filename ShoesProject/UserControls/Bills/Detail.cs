using Microsoft.VisualBasic.Logging;
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

namespace ShoesProject.UserControls.Bills
{
    public partial class Detail : Form
    {
        DataTable table;
        public Detail(DataTable table)
        {
            InitializeComponent();
            this.table = table;
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            lbtrangthai.Text = "";
            string idcustomer = table.Rows[0][2].ToString().Trim();
            string idhoadon = table.Rows[0][0].ToString().Trim();
            string trangthai = table.Rows[0][5].ToString().Trim();
            string namenhanvien;
            if (trangthai.Equals("confirmed"))
            {
                cbboxtrangthai.SelectedIndex = 0;
                string idnhanvien = table.Rows[0][1].ToString().Trim();
                txtidnhanvien.Text = idnhanvien;
                namenhanvien = DAO_Bill.Instance.getNameNVByID(idnhanvien).ToString().Trim();
                txtnhanvien.Text = namenhanvien;
            }
            else
            {
                cbboxtrangthai.SelectedIndex = 1;
               
            }
            string date = table.Rows[0][3].ToString().Trim();
            string total = table.Rows[0][4].ToString().Trim();
           
           

            string namekhachhang = DAO_Bill.Instance.getNameKHByID(idcustomer).ToString().Trim();

            table = DAO_Bill.Instance.getCTHD(idhoadon);
            int n = table.Rows.Count;
            DataTable newtable = new DataTable();
            newtable.Columns.Add("ID san pham");
            newtable.Columns.Add("Don gia");

            newtable.Columns.Add("So luong");
            newtable.Columns.Add("Tong tien");
           

            for (int i = 0; i < n; i++)
            {
                string idsp = table.Rows[i][0].ToString().Trim();
                string soluong = table.Rows[i][1].ToString().Trim();
                string tongtien = table.Rows[i][2].ToString().Trim();
                float dongia = float.Parse(tongtien) / float.Parse(soluong);
                newtable.Rows.Add(idsp,dongia.ToString(),soluong,tongtien);
            }
            dataGridView1.DataSource = newtable;
            txtid.Text = idhoadon;
            txtidcustomer.Text = idcustomer;
            
           
            txtcustomer.Text = namekhachhang;
            txttotal.Text = total;
            txtdate.Text = date;
        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
