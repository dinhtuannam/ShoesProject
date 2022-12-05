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
                lbtrangthai.Text = "Bang du lieu trong rong";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui long chon 1 hoa don de chinh sua";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            
            if (dataGridView1.Rows[row].Cells[5].Value.ToString().Trim().Equals("confirmed"))
            {
                lbtrangthai.Text = "Hoa don da confirmed,ko the thay doi hoac xoa";
                return;
            }
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            Edit edit = new Edit(DAO_Bill.Instance.getBillByID(id),employee,this);
            if (edit == null)
            {
                lbtrangthai.Text = "Cant create new Edit Form";
                return;
            }
            edit.Show();
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
                    lbtrangthai.Text = "ko co chuc nang " + type;
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
                lbtrangthai.Text = "Cant create new Add Form";
                return;
            }
            addbill.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bang du lieu trong rong";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui long chon 1 hoa don de xoa";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            if (dataGridView1.Rows[row].Cells[5].Value.ToString().Trim().Equals("confirmed"))
            {
                lbtrangthai.Text = "Hoa don da confirmed, ko the thay doi hoac xoa";
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
                lbtrangthai.Text = "Bang du lieu trong rong";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui long chon 1 hoa don de xem chi tiet";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            Detail detail = new Detail(DAO_Bill.Instance.getBillByID(id));
            if (detail == null)
            {
                lbtrangthai.Text = "Cant create new Detail Form";
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbtrangthai_Click(object sender, EventArgs e)
        {

        }
    }
}
