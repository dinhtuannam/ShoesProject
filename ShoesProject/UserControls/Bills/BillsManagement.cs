using ShoesProject.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject.UserControls.Bills
{
    public partial class BillsManagement : UserControl
    {
        public BillsManagement()
        {
            InitializeComponent();
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
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            DataTable table = new DataTable();
            table=DAO_Bill.Instance.getBillByID(id);
         

            Edit edit = new Edit(table);
            edit.Show();
        }
        private void loadTable(string type,string id = null)
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
            AddBill addbill = new AddBill();
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
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
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
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            Detail detail = new Detail(DAO_Bill.Instance.getBillByID(id));
            detail.Show();

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text.Trim().Equals(""))
            {
                loadTable("loadalldata");
                return;
            }
            dataGridView1.DataSource = DAO_Bill.Instance.getBillByID(txtsearch.Text);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbtrangthai_Click(object sender, EventArgs e)
        {

        }
    }
}
