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
        UC_Bills billmanage;
        public AddBill(DTO_Employee employee, UC_Bills billmanage)
        {
            InitializeComponent();
            this.employee = employee;
            this.billmanage = billmanage;
        }
        private void AddBill_Load(object sender, EventArgs e)
        {
            lbtrangthai.Text = "";
            table = new DataTable();
            table.Columns.Add("ID Sản Phẩm");
            table.Columns.Add("Tên Sản Phẩm");
            table.Columns.Add("Đơn Giá");
            table.Columns.Add("Số Lượng");
            table.Columns.Add("Tổng Tiền");
            dataGridView1.DataSource = table;
        }
        private void btnaddsanpham_Click(object sender, EventArgs e)
        {
            if (txtidsanpham.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui lòng nhập id sản phẩm";
                return;
            }
            if (txtamount.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui lòng chọn số lượng";
                return;
            }
            int result;
            if (!int.TryParse(txtamount.Text,out result))
            {
                lbtrangthai.Text = "Vui lòng nhập số lượng hợp lệ";
                return;
            }
            if (int.Parse(txtamount.Text)<=0)
            {
                lbtrangthai.Text = "Không nhập số lượng dưới 1";
                return;
            }
            object temp = DAO_Bill.Instance.getPriceByID(txtidsanpham.Text.Trim());
            if(temp == null)
            {
                lbtrangthai.Text = "Không tìm thấy ID sản phẩm";
                return;
            }
            if (!DAO_Bill.Instance.isProductActive(txtidsanpham.Text.Trim())) {
                lbtrangthai.Text = "Sản phẩm unactive";
                return;
            }
            float dongia = float.Parse(temp.ToString());
            float tongtien=0;int amount=0;
            int n = table.Rows.Count;
            for(int i = 0;i < n; i++)
            {
                string s;
               
                if (table.Rows[i][0].ToString().Equals(txtidsanpham.Text.Trim().ToUpper()))
                {
                    amount = int.Parse(table.Rows[i][3].ToString())+int.Parse(txtamount.Text);
                    if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(),"", amount))
                    {
                        lbtrangthai.Text = "Không đủ số lượng";
                        return;
                    }//phai kiem tra het so luong trong bang chu k op phai kiem tr aso luong o txtamount
                    tongtien = dongia * amount;
                    table.Rows[i].SetField("Số Lượng", amount);
                    table.Rows[i].SetField("Tổng Tiền",tongtien);
                    goto A;
                }
            }
            if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(),"", int.Parse(txtamount.Text)))
            {
                lbtrangthai.Text = "Không đủ số lượng";
                return;
            }//phai kiem tra het so luong trong bang chu k op phai kiem tr aso luong o txtamount
            string namesp = (DAO_Bill.Instance.getNameProduct(txtidsanpham.Text.Trim())).ToString().Trim();
            tongtien = dongia * float.Parse(txtamount.Text);
            table.Rows.Add(txtidsanpham.Text.Trim(), namesp,dongia,txtamount.Text.Trim(),tongtien);
            A:
            txttotal.Text = CaculateTotal().ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui lòng nhập ID hóa đơn";
                return;
            }
            if (txtidcustomer.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui lòng nhập ID khách hàng";
                return;
            }
            if (cbboxtrangthai.SelectedIndex == -1)
            {
                lbtrangthai.Text = "Vui lòng chọn trạng thái";
                return;
            }
            int n = table.Rows.Count;
            if (n == 0)
            {
                lbtrangthai.Text = "Vui lòng chọn ít nhất 1 sản phẩm";
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
                    lbtrangthai.Text = String.Format("ID sản phẩm {0} không còn tồn tại nữa", idsp[i]);
                    return;
                }
                if (!DAO_Bill.Instance.isProductActive(idsp[i]))
                {
                    lbtrangthai.Text = String.Format("ID sản phẩm {0} unactive", idsp[i]);
                    return;
                }
                soluong[i] = table.Rows[i][3].ToString();
                totalsp[i] = table.Rows[i][4].ToString();
                if (!DAO_Bill.Instance.IsEnough(idsp[i],"" ,int.Parse(soluong[i])))
                {
                    lbtrangthai.Text = "Không đủ số lượng cho idsp =" + idsp[i];
                    return;
                }//phai kiem tra loai bỏ cai chinh minhko neuminh la edit va dang trong edit
            }
            if (DAO_Bill.Instance.isBillIDExist(txtid.Text.Trim()))
            {
                lbtrangthai.Text = "Đã tồn tại ID hóa đơn";
                return;
            }
            if (!DAO_Bill.Instance.isCustomerIDExist(txtidcustomer.Text.Trim()))
            {
                lbtrangthai.Text = "Không tồn tại ID khách hàng";
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
                lbtrangthai.Text = "Bảng dữ liệu trống rỗng";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui lòng chọn 1 sản phẩm để xóa";
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
                lbtrangthai.Text = "Bảng dữ liệu trống rỗng";
                return 0;
            }
            int n = table.Rows.Count;
            float sum = 0;
            for(int i =0;i < n; i++)
            {
                sum += float.Parse(table.Rows[i][4].ToString());
            }
            return sum;
        }
        private void txtid_TextChanged(object sender, EventArgs e)
        {   
            if (DAO_Bill.Instance.isBillIDExist(txtid.Text.Trim()))
            {
                lbthongbaoid.Text ="Đã tồn tại ID hóa đơn";
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
                lbthongbaoidkh.Text = "Không tồn tại ID khách hàng";
                lbthongbaoidkh.Visible = true;
            }
            else
            {
                lbthongbaoidkh.Visible = false;
            }
        }

        private void txtidsanpham_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
