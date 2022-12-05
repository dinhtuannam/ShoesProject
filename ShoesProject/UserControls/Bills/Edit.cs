﻿using ShoesProject.DAO;
using ShoesProject.DTO;
using System;
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
        DTO_Employee employee;
        BillsManagement billmanage;
        public Edit(DataTable table,DTO_Employee employee,BillsManagement billmanage)
        {
            InitializeComponent();
            this.table = table;
            this.employee = employee;
            this.billmanage = billmanage;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            loadData();
            lbtrangthai.Text = "";
        }
        private void loadData()
        {
            string idcustomer = table.Rows[0][2].ToString().Trim();
            string idhoadon = table.Rows[0][0].ToString().Trim();
            string strdate = table.Rows[0][3].ToString().Trim();     
            cbboxtrangthai.SelectedIndex = 1;
            string[] arr = strdate.Split('/');
            int date = int.Parse(arr[0]);
            int month = int.Parse(arr[1]);
            int year = int.Parse(arr[2].Substring(0,4));

            string[] arr1 = arr[2].Substring(5).Split(':');
            int hour = int.Parse(arr1[0]);
            int minute = int.Parse(arr1[1]);
            int second = int.Parse(arr1[2].Substring(0, 2));
           
            string total = table.Rows[0][4].ToString();

            table = DAO_Bill.Instance.getCTHD(idhoadon);
            DataTable newtable = new DataTable();
            newtable.Columns.Add("id sp");
            newtable.Columns.Add("don gia");
            newtable.Columns.Add("so luong");
            newtable.Columns.Add("Tong tien");
            int n = table.Rows.Count;
            for(int i =0;i < n; i++)
            {
                string idsp = table.Rows[i][0].ToString().Trim();
                string soluong = table.Rows[i][1].ToString().Trim();
                string tongtien = table.Rows[i][2].ToString().Trim();
                string dongia = (float.Parse(tongtien) / float.Parse(soluong)).ToString() ;
                newtable.Rows.Add(idsp,dongia,soluong,tongtien);
            }
            table = newtable;
            dataGridView1.DataSource = table;
            txtid.Text = idhoadon;
            txtidcustomer.Text = idcustomer;
            txttotal.Text = total;
            dtpicker.Value = new DateTime(year,month,date,hour,minute,second);
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
            if (!int.TryParse(txtamount.Text, out result))
            {
                lbtrangthai.Text = "Vui long nhap so luong hop le";
                return;
            }
            if (int.Parse(txtamount.Text) <= 0)
            {
                lbtrangthai.Text = "Ko nhap so luong duoi 1";
                return;
            }

            object temp = DAO_Bill.Instance.getPriceByID(txtidsanpham.Text.Trim());
            if (temp == null)
            {
                lbtrangthai.Text = "Ko tim thay ID san pham";
                return;
            }
            float dongia = float.Parse(temp.ToString());
            float tongtien = 0; int amount = 0;
            int n = table.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (table.Rows[i][0].ToString().Equals(txtidsanpham.Text.Trim()))
                {
                    amount = int.Parse(table.Rows[i][2].ToString()) + int.Parse(txtamount.Text);
                    if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(), txtid.Text, amount))
                    {
                        lbtrangthai.Text = "Ko du so luong";
                        return;
                    }
                    tongtien = dongia * amount;
                    table.Rows[i].SetField("So luong", amount);
                    table.Rows[i].SetField("Tong tien", tongtien);
                    goto A;
                }
            }
            if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(), txtid.Text, int.Parse(txtamount.Text)))
            {
                lbtrangthai.Text = "Ko du so luong";
                return;
            }
            tongtien = dongia * float.Parse(txtamount.Text);
            table.Rows.Add(txtidsanpham.Text.Trim(), dongia, txtamount.Text.Trim(), tongtien);
        A:
            txttotal.Text = CaculateTotal().ToString();
        }

        private void btnremovesp_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bang du lieu trong rong";
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
                lbtrangthai.Text = "Bang du lieu trong rong";
                return 0;
            }
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



           

            

            int row = dataGridView1.Rows.Count;
            if (row == 0)
            {
                lbtrangthai.Text = "Vui long chon it nhat 1 san pham";
                return;
            }
            if (!DAO_Bill.Instance.isBillIDExist(txtid.Text.Trim()))
            {
                lbtrangthai.Text = "Ko ton tai ID hoa don";
                return;
            }
            if (!DAO_Bill.Instance.isCustomerIDExist(txtidcustomer.Text.Trim()))
            {
                lbtrangthai.Text = "Ko ton tai ID khach hang";
                return;
            }
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bang du lieu trong rong";
                return;
            }
            string[] idsp = new string[row];
            string[] soluong = new string[row];
            string[] totalsp = new string[row];
            for (int i = 0; i < row; i++)
            {
                idsp[i] = table.Rows[i][0].ToString().Trim();
                if (!DAO_Bill.Instance.isProductIDExist(idsp[i]))
                {
                    lbtrangthai.Text = String.Format("ID san pham {0} ko con ton tai nua", idsp[i]);
                    return;//kiem tra con so luong nua
                }
                
                soluong[i] = table.Rows[i][2].ToString();
                totalsp[i] = table.Rows[i][3].ToString();
                if (!DAO_Bill.Instance.IsEnough(idsp[i], txtid.Text.Trim(), int.Parse(soluong[i])))
                {
                    lbtrangthai.Text = "Ko du so luong";
                    return;
                }

            }
            object idnhanvien = DBNull.Value;
            if (cbboxtrangthai.Items[cbboxtrangthai.SelectedIndex].Equals("confirmed"))
            {
                idnhanvien = employee.Id.Trim();
                for (int i = 0; i < idsp.Length; i++)
                {
                    DAO_Bill.Instance.decreaseProduct(idsp[i], int.Parse(soluong[i]));
                }
            }
            DAO_Bill.Instance.updateBill(txtid.Text.Trim(),idnhanvien,txtidcustomer.Text.Trim(), dtpicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), txttotal.Text, cbboxtrangthai.Items[cbboxtrangthai.SelectedIndex].ToString());
           
            DAO_Bill.Instance.deleteCTHDByID(txtid.Text.Trim());


           
            
            DAO_Bill.Instance.addCTHD(txtid.Text.Trim(),idsp,soluong,totalsp);
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            billmanage.loadTable("loadalldata");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
