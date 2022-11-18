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
                lbtrangthai.Text = "Bang du lieu null";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui long chon 1 hoa don de chinh sua";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            SQLData sqldata = new SQLData();
            DataTable table = new DataTable();
            string query = String.Format("Select * from hoadon where idhd='{0}'",id);
            Boolean success = false;
            object test = sqldata.Scalar(query,ref success);
            if (test == null && success)
            {
                lbtrangthai.Text = "Ko tim thay id hoa don="+id+" trong table hoadon";
                return;
            }
            if (!success)
            {
                lbtrangthai.Text = "Ko ket noi duoc bang hoadon";
                return;
            }
            table = sqldata.getData(query, ref success);
            if (!success)
            {
                lbtrangthai.Text = "Ko ket noi duoc bang hoadon";
                return;
            }
            Edit edit = new Edit(table);
            edit.Show();
        }
        private void loadData()
        {
            SQLData sqlData = new SQLData();
            string query = "Select * from hoadon";
             Boolean success=false;
             dataGridView1.DataSource =sqlData.getData(query,ref success);
            if (!success)
            {
                lbtrangthai.Text = "Ko ket noi duoc bang hoadon";
            }
        }
        private void BillsManagement_Load(object sender, EventArgs e)
        {
            loadData();
            lbtrangthai.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
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
                lbtrangthai.Text = "Bang du lieu null";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui long chon 1 hoa don de xoa";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            SQLData sqldata = new SQLData();
            Boolean success = false;
            string query = String.Format("Delete from cthd where idhd='{0}';Delete from hoadon where idhd='{0}'", id);
            
            sqldata.Execute(query,ref success);
            if (!success)
            {
                lbtrangthai.Text = "Cant connect to hoadon or cthd";
            }
            loadData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                lbtrangthai.Text = "Bang du lieu null";
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                lbtrangthai.Text = "Vui long chon 1 hoa don de xem chi tiet";
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            SQLData sqldata = new SQLData();
            DataTable table = new DataTable();
            string query = String.Format("Select * from hoadon where idhd='{0}'", id);
            Boolean success = false;
            object test = sqldata.Scalar(query,ref success);
            if(test==null && success)
            {
                lbtrangthai.Text = "Ko tim thay id hoa don=" +id+" trong table hoadon";
                return;
            }
            if (!success)
            {
                lbtrangthai.Text = "Ko ket noi duoc bang hoadon";
                return;
            }

            table = sqldata.getData(query,ref success);
            if (!success)
            {
                lbtrangthai.Text = "Ko ket noi duoc bang hoadon";
                return;
            }
            Detail detail = new Detail(table);
            detail.Show();

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text.Trim().Equals(""))
            {
                loadData();
                return;
            }
            SQLData sqldata = new SQLData();
            string query = String.Format("Select * from hoadon where idhd='{0}'",txtsearch.Text);
            Boolean success = false;
            dataGridView1.DataSource=sqldata.getData(query, ref success);
            if (!success)
            {
                lbtrangthai.Text = "Ko ket noi duoc table hoadon";
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbtrangthai_Click(object sender, EventArgs e)
        {

        }
    }
}
