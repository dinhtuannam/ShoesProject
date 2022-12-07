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
    public partial class AddBill : Form
    {
        DataTable table;
        DTO_Employee employee;
        BillsManagement billmanage;
        public AddBill(DTO_Employee employee, BillsManagement billmanage)
        {
            InitializeComponent();
            this.employee = employee;
            this.billmanage = billmanage;

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

            object temp = DAO_Bill.Instance.getPriceByID(txtidsanpham.Text.Trim());
            if(temp == null)
            {
                lbtrangthai.Text = "Ko tim thay ID san pham";
                return;
            }
            
            float dongia = float.Parse(temp.ToString());
            float tongtien=0;int amount=0;
            int n = table.Rows.Count;
            for(int i = 0;i < n; i++)
            {
                if (table.Rows[i][0].ToString().Equals(txtidsanpham.Text.Trim()))
                {
                    amount = int.Parse(table.Rows[i][2].ToString())+int.Parse(txtamount.Text);
                    if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(),"", amount))
                    {
                        lbtrangthai.Text = "Ko du so luong";
                        return;
                    }//phai kiem tra het so luong trong bang chu k op phai kiem tr aso luong o txtamount
                    tongtien = dongia * amount;
                    table.Rows[i].SetField("So luong", amount);
                    table.Rows[i].SetField("Tong tien",tongtien);
                    goto A;
                }
            }
            if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(),"", int.Parse(txtamount.Text)))
            {
                lbtrangthai.Text = "Ko du so luong";
                return;
            }//phai kiem tra het so luong trong bang chu k op phai kiem tr aso luong o txtamount
            tongtien = dongia * float.Parse(txtamount.Text);
            table.Rows.Add(txtidsanpham.Text.Trim(), dongia,txtamount.Text.Trim(),tongtien);
            A:
            txttotal.Text = CaculateTotal().ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui long nhap ID hoa don";
                return;
            }
            if (txtidcustomer.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui long nhap ID khach hang";
                return;
            }
            if (cbboxtrangthai.SelectedIndex == -1)
            {
                lbtrangthai.Text = "Vui long chon trang thai";
                return;
            }
            int n = table.Rows.Count;
            if (n == 0)
            {
                lbtrangthai.Text = "Vui long chon it nhat 1 san pham";
                return;
            }
            string[] soluong=new string[n];
            string[] totalsp=new string[n];
            string[] idsp = new string[n];
            for( int i=0; i < n; i++)
            {
                idsp[i] = table.Rows[i][0].ToString().Trim();
                if (!DAO_Bill.Instance.isProductIDExist(idsp[i]))
                {
                    lbtrangthai.Text = String.Format("ID san pham {0} ko con ton tai nua", idsp[i]);
                    return;
                }
                
                soluong[i] = table.Rows[i][2].ToString();
                totalsp[i] = table.Rows[i][3].ToString();
                if (!DAO_Bill.Instance.IsEnough(idsp[i],"" ,int.Parse(soluong[i])))
                {
                    lbtrangthai.Text = "Ko du so luong cho idsp =" + idsp[i];
                    return;
                }//phai kiem tra loai bỏ cai chinh minhko neuminh la edit va dang trong edit
            }
            if (DAO_Bill.Instance.isBillIDExist(txtid.Text.Trim()))
            {
                lbtrangthai.Text = "Da ton tai ID hoa don";
                return;
            }
            if (!DAO_Bill.Instance.isCustomerIDExist(txtidcustomer.Text.Trim()))
            {
                lbtrangthai.Text = "Ko ton tai ID khach hang";
                return;
            }
            
            object idnhanvien =DBNull.Value;
            if (cbboxtrangthai.Items[cbboxtrangthai.SelectedIndex].ToString().Equals("confirmed"))
            {
                idnhanvien = employee.Id;
                for(int i=0;i < idsp.Length; i++)
                {                  
                    DAO_Bill.Instance.decreaseProduct(idsp[i], int.Parse(soluong[i]));
                }
            }
            DAO_Bill.Instance.addBill(txtid.Text.Trim(),idnhanvien,txtidcustomer.Text.Trim(), date.Value.ToString("yyyyMMdd hh:mm:ss tt"), txttotal.Text, cbboxtrangthai.Items[cbboxtrangthai.SelectedIndex].ToString());
            DAO_Bill.Instance.addCTHD(txtid.Text.Trim(), idsp, soluong, totalsp);
            Close();
        }

        private void AddBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            billmanage.loadTable("loadalldata");
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
        }//lo nhu ben product giam so luong
        private float CaculateTotal()
        {

            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bang du lieu trong rong";
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

        private void txtidsanpham_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            
            if (DAO_Bill.Instance.isBillIDExist(txtid.Text.Trim()))
            {
                lbthongbaoid.Text ="Da ton tai ID hoa don";
                lbthongbaoid.Visible = true;
            }
            else
            {
                lbthongbaoid.Visible = false;
            }
        }

        private void txtidcustomer_TextChanged(object sender, EventArgs e)
        {
            if (!DAO_Bill.Instance.isCustomerIDExist(txtidcustomer.Text.Trim()))
            {
                lbthongbaoidkh.Text = "Ko ton tai ID khach hang";
                lbthongbaoidkh.Visible = true;
            }
            else
            {
                lbthongbaoidkh.Visible = false;
            }
        }
    }
}
