﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject.UserControls.Bills
{
    public partial class Edit : Form
    {
        DataTable table;
        public Edit(DataTable table)
        {
            InitializeComponent();
            this.table = table;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string idcustomer = table.Rows[0][2].ToString();
            string idhoadon = table.Rows[0][0].ToString();
            string idnhanvien = table.Rows[0][1].ToString();
            string strdate = table.Rows[0][3].ToString();

            string[] arr = strdate.Split('/');
            int date = int.Parse(arr[0]);
            int month = int.Parse(arr[1]);
            int year = int.Parse(arr[2].Substring(0,4));

            string[] arr1 = arr[2].Substring(5).Split(':');
            int hour = int.Parse(arr1[0]);
            int minute = int.Parse(arr1[1]);
            int second = int.Parse(arr1[2].Substring(0, 2));
           
            string total = table.Rows[0][4].ToString();

            SQLData sqldata = new SQLData();
            table = sqldata.getData(String.Format("Select idsp ,soluong,tongtien from cthd where idhd='{0}'", idhoadon));
            DataTable newtable = new DataTable();
            newtable.Columns.Add("id sp");
            newtable.Columns.Add("don gia");
            newtable.Columns.Add("so luong");
            newtable.Columns.Add("Tong tien");
            int n = table.Rows.Count;
            for(int i =0;i < n; i++)
            {
                string idsp = table.Rows[i][0].ToString();
                string soluong = table.Rows[i][1].ToString();
                string tongtien = table.Rows[i][2].ToString();
                string dongia = (float.Parse(tongtien) / float.Parse(soluong)).ToString() ;
                newtable.Rows.Add(idsp,dongia,soluong,tongtien);
            }
            table = newtable;
            dataGridView1.DataSource = table;
            txtid.Text = idhoadon;
            txtidcustomer.Text = idcustomer;
            txtidnhanvien.Text = idnhanvien;
            txttotal.Text = total;
            dtpicker.Value = new DateTime(year,month,date,hour,minute,second);
        }

        private void btnaddsanpham_Click(object sender, EventArgs e)
        {
            SQLData sqldata = new SQLData();
            string query = String.Format("Select gia from sanpham where idsp='{0}'", txtidsanpham.Text);
            DataTable datatable = sqldata.getData(query);
            float tongtien = 0; int amount = 0;
            float dongia = float.Parse(datatable.Rows[0][0].ToString());
            int n = table.Rows.Count;
            MessageBox.Show(""+n);
            for (int i = 0; i < n; i++)
            {
                if (table.Rows[i][0].ToString().Trim().Equals(txtidsanpham.Text))
                {
                    amount = int.Parse(table.Rows[i][2].ToString()) + int.Parse(txtamount.Text);
                    tongtien = dongia * amount;
                    table.Rows[i].SetField("So luong", amount);
                    table.Rows[i].SetField("Tong tien", tongtien);
                    goto A;
                }
            }
            tongtien = dongia * float.Parse(txtamount.Text);
            table.Rows.Add(txtidsanpham.Text, dongia, txtamount.Text, tongtien);
        A:
            txttotal.Text = CaculateTotal().ToString();
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
            for (int i = 0; i < n; i++)
            {
                sum += float.Parse(table.Rows[i][3].ToString());

            }
            return sum;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SQLData sqldata = new SQLData();
            string query = String.Format("Update hoadon set idnv='{0}',idkh='{1}',ngaydat='{2}',tongtien='{3}',trangthai='{4}' where idhd='{5}'",txtidnhanvien.Text,txtidcustomer.Text, dtpicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), txttotal.Text ,null,txtid.Text);
            sqldata.Execute(query);
            query = String.Format("Delete from cthd where idhd='{0}'", txtid.Text);
            sqldata.Execute(query);
            int row = dataGridView1.Rows.Count;
            for(int i = 0; i < row; i++)
            {
                query = String.Format("insert into cthd values('{0}','{1}','{2}','{3}')", txtid.Text, table.Rows[i][0].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString());
                MessageBox.Show(query);
                sqldata.Execute(query);
            }
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
