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
    public partial class AddBill : Form
    {
        DataTable table;
        public AddBill()
        {
            InitializeComponent();
        }

        private void AddBill_Load(object sender, EventArgs e)
        {
            lbtrangthai.Text = "";
            table = new DataTable();
            table.Columns.Add("ID san pham");
            table.Columns.Add("Don gia");
            table.Columns.Add("So luong");
            table.Columns.Add("Tong tien");
            dataGridView1.DataSource = table;
        }

        private void btnaddsanpham_Click(object sender, EventArgs e)
        {
            if (txtidsanpham.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui long nhap id san pham";
                return;
            }
            if (txtamount.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui long chon so luong";
                return;
            }
            int result;
            if (!int.TryParse(txtamount.Text,out result))
            {
                lbtrangthai.Text = "Vui long nhap so luong hop le";
                return;
            }
            if (int.Parse(txtamount.Text)<=0)
            {
                lbtrangthai.Text = "Ko nhap so luong duoi 1";
                return;
            }
            SQLData sqldata = new SQLData();
            string query = String.Format("Select gia from sanpham where idsp='{0}'",txtidsanpham.Text);
            Boolean success = false;
            object test = sqldata.Scalar(query, ref success);
            if (success && test == null)
            {
                lbtrangthai.Text = "Ko tim thay id san pham=" + txtidsanpham.Text + " trong table sanpham";
                return;
            }
            if (!success)
            {
                lbtrangthai.Text = "Ko ket noi duoc table sanpham";
                return;
            }
            float dongia = float.Parse(test.ToString());
            float tongtien=0;int amount=0;
            int n = table.Rows.Count;
            for(int i = 0;i < n; i++)
            {
                if (table.Rows[i][0].ToString().Equals(txtidsanpham.Text))
                {
                    amount = int.Parse(table.Rows[i][2].ToString())+int.Parse(txtamount.Text);
                    tongtien = dongia * amount;
                    table.Rows[i].SetField("So luong", amount);
                    table.Rows[i].SetField("Tong tien",tongtien);
                    goto A;
                }
            }
            tongtien = dongia * float.Parse(txtamount.Text);
            table.Rows.Add(txtidsanpham.Text, dongia,txtamount.Text,tongtien);
            A:
            txttotal.Text = CaculateTotal().ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int n = table.Rows.Count;
            if (n == 0)
            {
                lbtrangthai.Text = "Vui long chon it nhat 1 san pham";
                return;
            }
            SQLData sqldata = new SQLData();
            string query = String.Format("insert into hoadon values ('{0}','{1}','{2}','{3}','{4}','{5}')",txtid.Text,txtidnhanvien.Text,txtidcustomer.Text,date.Value.ToString("yyyyMMdd hh:mm:ss tt"),txttotal.Text,null);
            Boolean success = false;
            sqldata.Execute(query,ref success);
            if (!success)
            {
                lbtrangthai.Text = "Them hoa don that bai";
                return;
            }
            for(int i =0;i < n; i++)
            {
                query =String.Format("insert into cthd values('{0}','{1}','{2}','{3}')", txtid.Text, table.Rows[i][0].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString());
                sqldata.Execute(query,ref success);
                if (!success)
                {
                    lbtrangthai.Text = "Them cthd that bai";
                    return;
                }
            }
            Close();
        }

        private void AddBill_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnremovesp_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bang du lieu null";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui long chon 1 san pham de xoa";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            table.Rows[row].Delete();
            txttotal.Text = CaculateTotal().ToString();
        }
        private float CaculateTotal()
        {

            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bang du lieu null";
                return 0;
            }
            int n = table.Rows.Count;
            float sum = 0;
            for(int i =0;i < n; i++)
            {
                sum += float.Parse(table.Rows[i][3].ToString());

            }
            return sum;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
