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
            table = new DataTable();
            table.Columns.Add("ID san pham");
            table.Columns.Add("Don gia");
            table.Columns.Add("So luong");
            table.Columns.Add("Tong tien");
            dataGridView1.DataSource = table;
        }

        private void btnaddsanpham_Click(object sender, EventArgs e)
        {
            
            SQLData sqldata = new SQLData();
            string query = String.Format("Select gia from sanpham where idsp='{0}'",txtidsanpham.Text);
            DataTable datatable = sqldata.getData(query);
            float tongtien=0;int amount=0;
            float dongia = float.Parse(datatable.Rows[0][0].ToString());
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
            SQLData sqldata = new SQLData();
            string query = String.Format("insert into hoadon values ('{0}','{1}','{2}','{3}','{4}','{5}')",txtid.Text,txtidnhanvien.Text,txtidcustomer.Text,date.Value.ToString("yyyyMMdd hh:mm:ss tt"),txttotal.Text,null);
            sqldata.Execute(query);
            int n = table.Rows.Count;
            for(int i =0;i < n; i++)
            {
                query = String.Format("insert into cthd values('{0}','{1}','{2}','{3}')", txtid.Text, table.Rows[i][0].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString());
                sqldata.Execute(query);
            }
            Close();
        }

        private void AddBill_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnremovesp_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            table.Rows[row].Delete();
            txttotal.Text = CaculateTotal().ToString();
        }
        private float CaculateTotal()
        {
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
