using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            SQLData sqldata = new SQLData();
            DataTable table = new DataTable();
            string query = String.Format("Select * from hoadon where idhd='{0}'", id);
            table = sqldata.getData(query);
            Edit edit = new Edit(table);
            edit.Show();
        }
        private void loadData()
        {
            SQLData sqlData = new SQLData();
            string query = "Select * from hoadon";
             dataGridView1.DataSource =sqlData.getData(query);
        }
        private void BillsManagement_Load(object sender, EventArgs e)
        {
            loadData();
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
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            SQLData sqldata = new SQLData();
            sqldata.Execute(String.Format("Delete from cthd where idhd='{0}';Delete from hoadon where idhd='{0}'",id));
            loadData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            SQLData sqldata = new SQLData();
            DataTable table = new DataTable();
            string query = String.Format("Select * from hoadon where idhd='{0}'", id);
            table = sqldata.getData(query);
            Detail detail = new Detail(table);
            detail.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
