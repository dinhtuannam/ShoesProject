using ShoesProject.DAO;
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
        DTO_Bill dtobill;
        DTO_Employee employee;
        UC_Bills billmanage;
        public Edit(DTO_Bill dtobill,DTO_Employee employee,UC_Bills billmanage)
        {
            InitializeComponent();
            this.dtobill= dtobill;
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
            string idcustomer = dtobill.ID_Cus;
            string idhoadon = dtobill.ID ;
            string strdate = dtobill.Date;
            cbboxtrangthai.SelectedIndex = 1;
            string[] arr = strdate.Split('/');
            int date = int.Parse(arr[0]);
            int month = int.Parse(arr[1]);
            int year = int.Parse(arr[2].Substring(0,4));

            string[] arr1 = arr[2].Substring(5).Split(':');
            int hour = int.Parse(arr1[0]);
            int minute = int.Parse(arr1[1]);
            int second = int.Parse(arr1[2].Substring(0, 2));

            string total = dtobill.Total ;

           
            DataTable newtable = new DataTable();
            newtable.Columns.Add("ID Sản Phẩm");
            newtable.Columns.Add("Tên Sản Phẩm");
            newtable.Columns.Add("Đơn Giá");
            newtable.Columns.Add("Số Lượng");
            newtable.Columns.Add("Tổng Tiền");
            int n = dtobill.CTHD.IDSP.Length;
            for(int i =0;i < n; i++)
            {
                string idsp = dtobill.CTHD.IDSP[i];
                string namesp = dtobill.CTHD.NAMESP[i];
                string soluong = dtobill.CTHD.SOLUONG[i];
                string tongtien = dtobill.CTHD.TOTAL[i];
                string dongia = (float.Parse(tongtien) / float.Parse(soluong)).ToString() ;
                newtable.Rows.Add(idsp,namesp,dongia,soluong,float.Parse(tongtien));
            }
            table = newtable;
            dataGridView1.DataSource = table;
            txtid.Text = idhoadon;
            txtidcustomer.Text = idcustomer;
            txttotal.Text = float.Parse(total).ToString();
            dtpicker.Value = new DateTime(year,month,date,hour,minute,second);
        }

        private void btnaddsanpham_Click(object sender, EventArgs e)
        {
            if (txtidsanpham.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui lòng nhập ID sản phẩm";
                return;
            }
            if (txtamount.Text.Trim().Equals(""))
            {
                lbtrangthai.Text = "Vui lòng chọn số lượng";
                return;
            }
            int result;
            if (!int.TryParse(txtamount.Text, out result))
            {
                lbtrangthai.Text = "Vui lòng nhập số lượng hợp lệ";
                return;
            }
            if (int.Parse(txtamount.Text) <= 0)
            {
                lbtrangthai.Text = "Không nhập số lượng dưới 1";
                return;
            }

            object temp = DAO_Bill.Instance.getPriceByID(txtidsanpham.Text.Trim());
            if (temp == null)
            {
                lbtrangthai.Text = "Không tìm thấy ID sản phẩm";
                return;
            }
            if (!DAO_Bill.Instance.isProductActive(txtidsanpham.Text.Trim()))
            {
                lbtrangthai.Text = "Sản phẩm unactive";
                return;
            }
            float dongia = float.Parse(temp.ToString());
            float tongtien = 0; int amount = 0;
            
            int n = table.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (table.Rows[i][0].ToString().Equals(txtidsanpham.Text.Trim().ToUpper()))
                {
                    amount = int.Parse(table.Rows[i][3].ToString()) + int.Parse(txtamount.Text);
                    if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(), txtid.Text, amount))
                    {
                        lbtrangthai.Text = "Không đủ số lượng";
                        return;
                    }
                    tongtien = dongia * amount;
                    table.Rows[i].SetField("Số Lượng", amount);
                    table.Rows[i].SetField("Tổng Tiền", tongtien);
                    goto A;
                }
            }
            if (!DAO_Bill.Instance.IsEnough(txtidsanpham.Text.Trim(), txtid.Text, int.Parse(txtamount.Text)))
            {
                lbtrangthai.Text = "Không đủ số lượng";
                return;
            }
            string namesp = (DAO_Bill.Instance.getNameProduct(txtidsanpham.Text.Trim())).ToString().Trim();
            tongtien = dongia * float.Parse(txtamount.Text);
            table.Rows.Add(txtidsanpham.Text.Trim(),namesp, dongia, txtamount.Text.Trim(), tongtien);
        A:
            txttotal.Text = CaculateTotal().ToString();
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
        }
        private float CaculateTotal()
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bảng dữ liệu trống rỗng";
                return 0;
            }
            int n = table.Rows.Count;
            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += float.Parse(table.Rows[i][4].ToString());

            }
            return sum;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.Rows.Count;
            if (row == 0)
            {
                lbtrangthai.Text = "Vui lòng chọn ít nhất 1 sản phẩm";
                return;
            }
            if (!DAO_Bill.Instance.isBillIDExist(txtid.Text.Trim()))
            {
                lbtrangthai.Text = "Không tồn tại ID hóa đơn";
                return;
            }
            if (!DAO_Bill.Instance.isCustomerIDExist(txtidcustomer.Text.Trim()))
            {
                lbtrangthai.Text = "Không tồn tại ID khách hàng";
                return;
            }
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bảng dữ liệu trống rỗng";
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
                    lbtrangthai.Text = String.Format("ID sản phẩm {0} không còn tồn tại nữa", idsp[i]);
                    return;//kiem tra con so luong nua
                }
                if (!DAO_Bill.Instance.isProductActive(idsp[i]))
                {
                    lbtrangthai.Text = String.Format("ID sản phẩm {0} unactive", idsp[i]);
                    return;
                }
                soluong[i] = table.Rows[i][3].ToString();
                totalsp[i] = table.Rows[i][4].ToString();
                if (!DAO_Bill.Instance.IsEnough(idsp[i], txtid.Text.Trim(), int.Parse(soluong[i])))
                {
                    lbtrangthai.Text = "Không đủ số lượng";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
