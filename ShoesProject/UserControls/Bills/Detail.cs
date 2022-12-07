using Microsoft.VisualBasic.Logging;
using ShoesProject.DAO;
using ShoesProject.DTO;
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
        DTO_Bill dtobill;
        public Detail(DTO_Bill dtobill)
        {
            InitializeComponent();
            this.dtobill = dtobill;
        }
        private void Detail_Load(object sender, EventArgs e)
        {
            lbtrangthai.Text = "";
            string idcustomer = dtobill.ID_Cus;
            string idhoadon = dtobill.ID ;
            string trangthai = dtobill.TrangThai;
            string namenhanvien;
            if (trangthai.Equals("confirmed"))
            {
                cbboxtrangthai.SelectedIndex = 0;
                string idnhanvien = dtobill.ID_Emp;
                txtidnhanvien.Text = idnhanvien;
                namenhanvien = DAO_Bill.Instance.getNameNVByID(idnhanvien).ToString().Trim();
                txtnhanvien.Text = namenhanvien;
            }
            else
            {
                cbboxtrangthai.SelectedIndex = 1;
            }
            string date = dtobill.Date;
            string total = dtobill.Total;
            string namekhachhang = DAO_Bill.Instance.getNameKHByID(idcustomer).ToString().Trim();
            int n = dtobill.CTHD.IDSP.Length;
            DataTable newtable = new DataTable();
            newtable.Columns.Add("ID sản phẩm");
            newtable.Columns.Add("Tên sản phẩm");
            newtable.Columns.Add("Đơn giá");
            newtable.Columns.Add("Số lượng");
            newtable.Columns.Add("Tổng tiền");
            for (int i = 0; i < n; i++)
            {
                string idsp = dtobill.CTHD.IDSP[i];
                string name = dtobill.CTHD.NAMESP[i];
                string soluong = dtobill.CTHD.SOLUONG[i];
                string tongtien = dtobill.CTHD.TOTAL[i];
                float dongia = float.Parse(tongtien) / float.Parse(soluong);
                newtable.Rows.Add(idsp,name,dongia.ToString(),soluong,float.Parse(tongtien));
            }
            dataGridView1.DataSource = newtable;
            txtid.Text = idhoadon;
            txtidcustomer.Text = idcustomer;
            txtcustomer.Text = namekhachhang;
            txttotal.Text = float.Parse(total).ToString();
            txtdate.Text = date;
        }
    }
}
