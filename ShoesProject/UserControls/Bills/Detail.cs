using Microsoft.VisualBasic.Logging;
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
            string idcustomer = table.Rows[0][2].ToString().Trim();
            string idhoadon = table.Rows[0][0].ToString().Trim();
            string idnhanvien = table.Rows[0][1].ToString().Trim();
            string date = table.Rows[0][3].ToString();
            string total = table.Rows[0][4].ToString();
            SQLData sqldata = new SQLData();
            
            string namenhanvien =sqldata.getData(String.Format("Select tennv from nhanvien where idnv='{0}'", idnhanvien)).Rows[0][0].ToString();
            
            string namekhachhang = sqldata.getData(String.Format("Select tenkhachhang from khachhang where idkh ='{0}'", idcustomer)).Rows[0][0].ToString();
       
            table = sqldata.getData(String.Format("Select idsp ,soluong,tongtien from cthd where idhd='{0}'", idhoadon));
           
            int n = table.Rows.Count;

            DataTable newtable = new DataTable();
            newtable.Columns.Add("id sp");
            newtable.Columns.Add("don gia");

            newtable.Columns.Add("so luong");
            newtable.Columns.Add("tong tien");
           

            for (int i = 0; i < n; i++)
            {
                string idsp = table.Rows[i][0].ToString();
                string soluong = table.Rows[i][1].ToString();
                string tongtien = table.Rows[i][2].ToString();
                float dongia = float.Parse(tongtien) / float.Parse(soluong);
                newtable.Rows.Add(idsp,dongia.ToString(),soluong,tongtien);
            }
            dataGridView1.DataSource = newtable;
            txtid.Text = idhoadon;
            txtidcustomer.Text = idcustomer;
            txtidnhanvien.Text = idnhanvien;
            txtnhanvien.Text = namenhanvien;
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
