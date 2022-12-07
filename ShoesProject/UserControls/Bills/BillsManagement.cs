using ShoesProject.DAO;
using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ShoesProject.UserControls.Bills
{
    public partial class BillsManagement : UserControl
    {
        public static DTO_Employee employee;
        private static BillsManagement instance;
        public static BillsManagement Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BillsManagement();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        public BillsManagement()
        {
            InitializeComponent();
        }
        public void AddEmplooyee(DTO_Employee employees)
        {
             employee = employees;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bảng dữ liệu trống rỗng";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui lòng chọn 1 hóa đơn để chỉnh sửa";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            
            if (dataGridView1.Rows[row].Cells[5].Value.ToString().Trim().Equals("confirmed"))
            {
                lbtrangthai.Text = "Hóa đơn đã confirmed,không thể thay đổi hoặc xóa";
                return;
            }
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            Edit edit = new Edit(getBillDTO(id),employee,this);
            if (edit == null)
            {
                lbtrangthai.Text = "Không thể tạo form Edit";
                return;
            }
            edit.Show();
        }
        public DTO_Bill getBillDTO(string id)
        {
            DataTable tb = DAO_Bill.Instance.getBillByID(id);
            DTO_Bill dtobill = new DTO_Bill();
            dtobill.ID = tb.Rows[0][0].ToString().Trim();
            dtobill.ID_Cus = tb.Rows[0][2].ToString().Trim();
            dtobill.ID_Emp = tb.Rows[0][1].ToString().Trim();
            dtobill.Date = tb.Rows[0][3].ToString().Trim();
            dtobill.Total = tb.Rows[0][4].ToString().Trim();
            dtobill.TrangThai = tb.Rows[0][5].ToString().Trim();
            tb = DAO_Bill.Instance.getCTHD(dtobill.ID);
            int n = tb.Rows.Count;
            DTO_CTHD dtocthd = new DTO_CTHD(n);
            for(int i =0;i < n; i++)
            {
                dtocthd.IDSP[i] = tb.Rows[i][1].ToString().Trim();
                dtocthd.SOLUONG[i] = tb.Rows[i][2].ToString().Trim();
                dtocthd.TOTAL[i] = tb.Rows[i][3].ToString().Trim();
                dtocthd.NAMESP[i] = DAO_Bill.Instance.getNameProduct(dtocthd.IDSP[i]).ToString().Trim();
            }
            dtobill.CTHD = dtocthd;
            return dtobill;
        }
        public  void loadTable(string type,string id = null)
        {
            DataTable dt=null;
            if (type.Equals("search"))
            {

                dt=DAO_Bill.Instance.getBillByID(id);
            }
            else
            {
                if (type.Equals("loadalldata"))
                {
                    dt = DAO_Bill.Instance.getAllBill();
                }
                else
                {
                    lbtrangthai.Text = "Không có chức năng " + type;
                    return;
                }
            }
            dataGridView1.DataSource = dt;
        }
        private void BillsManagement_Load(object sender, EventArgs e)
        {
            loadTable("loadalldata");
            lbtrangthai.Text = "";
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadTable("loadalldata");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {          
            AddBill addbill = new AddBill(employee,this);
            if (addbill == null)
            {
                lbtrangthai.Text = "Không thể tạo form Add";
                return;
            }
            addbill.Show();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bảng dữ liệu trống rỗng";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui lòng chọn 1 hóa đơn để xóa";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            if (dataGridView1.Rows[row].Cells[5].Value.ToString().Trim().Equals("confirmed"))
            {
                lbtrangthai.Text = "Hóa đơn đã confirmed, không thể thay đổi hoặc xóa";
                return;
            }
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            DAO_Bill.Instance.deleteCTHDByID(id);
            DAO_Bill.Instance.deleteBill(id);
            loadTable("loadalldata");
        }
        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bảng dữ liệu trống rỗng";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui lòng chọn 1 hóa đơn để xem chi tiết";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            Detail detail = new Detail(getBillDTO(id));
            if (detail == null)
            {
                lbtrangthai.Text = "Không thể tạo form Detail";
                return;
            }
            detail.Show();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text.Trim().Equals(""))
            {
               loadTable("loadalldata");
                return;
            }
            loadTable("search",txtsearch.Text.Trim());
        }
    }
}
