using ShoesProject.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShoesProject.UserControls
{
    public partial class UC_Customers : UserControl
    {
        string LoadAllCustomerAction = "LoadAllCustomerAction";
        public UC_Customers()
        {
            InitializeComponent();
        }

        private void UC_Customers_Load(object sender, EventArgs e)
        {
            CustomerTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            loadTable(LoadAllCustomerAction);
            resizeTable();
        }

        private void loadTable(string action)
        {
            DataTable dt = new DataTable();
            if (action == LoadAllCustomerAction)
                dt = DAO_Customer.Instance.getAllCustomer();
            CustomerTable.DataSource = dt;
        }

        private void resizeTable()
        {
            CustomerTable.Columns[0].Width = 60;
            CustomerTable.Columns[1].Width = 90;
            CustomerTable.Columns[2].Width = 80;
            CustomerTable.Columns[4].Width = 70;
        }

        private void dgvTableCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = CustomerTable.CurrentRow.Index;
            int i = indexSelected;
            txtID.Text = CustomerTable.Rows[i].Cells[0].Value.ToString();
            txtUsername.Text = CustomerTable.Rows[i].Cells[1].Value.ToString();
            txtPass.Text = CustomerTable.Rows[i].Cells[2].Value.ToString();
            txtFullname.Text = CustomerTable.Rows[i].Cells[3].Value.ToString();
            txtPhone.Text = CustomerTable.Rows[i].Cells[4].Value.ToString();
            txtAddress.Text = CustomerTable.Rows[i].Cells[5].Value.ToString();
            txtEmail.Text = CustomerTable.Rows[i].Cells[6].Value.ToString();
            txtStatus.Text = CustomerTable.Rows[i].Cells[7].Value.ToString();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setNull();
        }

        private void setNull()
        {
            txtID.Text = "";
            txtUsername.Text = "";
            txtPass.Text = "";
            txtFullname.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Vui lòng chọn tài khoản muốn khóa");
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn khóa tài khoản này", "Khóa tài khoản", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (DAO_Customer.Instance.banAccount(txtID.Text))
                    {
                        MessageBox.Show("Khóa tài khoản thành công");
                        loadTable(LoadAllCustomerAction);
                        setNull();
                    }
                    else
                    MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Vui lòng chọn tài khoản muốn xóa");
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này", "Xóa tài khoản", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (DAO_Customer.Instance.deleteAccount(txtID.Text))
                    {
                        MessageBox.Show("Xóa tài khoản thành công");
                        loadTable(LoadAllCustomerAction);
                        setNull();
                    }
                    else
                        MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
                }
            }
        }
    }
}
