using ShoesProject.DAO;
using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject.UserControls
{
    public partial class UC_Employee : UserControl
    {
        string LoadAllEmployeeAction = "LoadAllEmployeeAction";
        string SearchEmployeeAction = "SearchEmployeeAction";
        string searchSelected = "Name";
        public UC_Employee()
        {
            InitializeComponent();
            LoadAccountList();
        }

        private void LoadAccountList()
        {
           
        }

        private void UC_Employee_Load_1(object sender, EventArgs e)
        {
            EmployeeTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            loadTable(LoadAllEmployeeAction);
            loadComboboxSearch();
            resizeTable();
        }

        private void loadComboboxSearch()
        {
            List<string> searchList = new List<string>();
            searchList.Add("Name");
            searchList.Add("ID");
            cbSearchE.DataSource = searchList;
        }

        private void cbSearchE_SelectedValueChanged(object sender, EventArgs e)
        {
            searchSelected = cbSearchE.SelectedItem.ToString();
        }


        private void loadTable(string action)
        {
            DataTable dt = new DataTable();
            if (action == LoadAllEmployeeAction)
                dt = DAO_Employee.Instance.getAllEmployee();
            if (action == SearchEmployeeAction)
                dt = DAO_Employee.Instance.searchAccount(txtSearchE.Text, searchSelected);
            EmployeeTable.DataSource = dt;
        }

        private void resizeTable()
        {
            EmployeeTable.Columns[0].Width = 60;
            EmployeeTable.Columns[1].Width = 90;
            EmployeeTable.Columns[2].Width = 80;
            EmployeeTable.Columns[4].Width = 70;
        }

        private void setNull()
        {
            txtIDE.Text = "";
            txtUsernameE.Text = "";
            txtPassE.Text = "";
            txtFullnameE.Text = "";
            txtPhoneE.Text = "";
            txtAddressE.Text = "";
            txtEmailE.Text = "";
            txtStatusE.Text = "";
            txtSearchE.Text = "";
        }

        private DTO_Employee getData()
        {
            DTO_Employee emp = new DTO_Employee();
            emp.Id = txtIDE.Text;
            emp.Username = txtUsernameE.Text;
            emp.Password = txtPassE.Text;
            emp.Status = "active";
            emp.Permission = "AD";
            emp.Fullname = txtFullnameE.Text;
            emp.Phone = txtPhoneE.Text;
            emp.Address = txtAddressE.Text;
            emp.Email = txtEmailE.Text;
            return emp;
        }

        private bool validate()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtEmailE.Text);
            if (txtFullnameE.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
                return false;
            }
            if (txtPassE.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return false;
            }
            if (txtUsernameE.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản");
                return false;
            }
            if (txtEmailE.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email khách hàng");
                return false;
            }
            if (!match.Success)
            {
                MessageBox.Show("Email không hợp lệ");
                return false;
            }
            if (txtPhoneE.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng");
                return false;
            }
            if (txtAddressE.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng");
                return false;
            }
            return true;

        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (txtIDE.Text == "")
                MessageBox.Show("Vui lòng chọn tài khoản muốn xoá");
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này", "Xóa tài khoản", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (DAO_Customer.Instance.deleteAccount(txtIDE.Text))
                    {
                        MessageBox.Show("Xóa tài khoản thành công");
                        loadTable(LoadAllEmployeeAction);
                        setNull();
                    }
                    else
                        MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
                }
            }
        }

        private void btnSearchE_Click(object sender, EventArgs e)
        {
            if (txtSearchE.Text == "")
                MessageBox.Show("Vui lòng nhập dữ liệu cần tìm kiếm");
            else
                loadTable(SearchEmployeeAction);
        }

        private void btnDestroyE_Click(object sender, EventArgs e)
        {
            setNull();
            loadTable(LoadAllEmployeeAction);
        }

        

        private void EmployeeTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelect = EmployeeTable.CurrentRow.Index;
            int i = indexSelect;
            txtIDE.Text = EmployeeTable.Rows[i].Cells[0].Value.ToString();
            txtUsernameE.Text = EmployeeTable.Rows[i].Cells[1].Value.ToString();
            txtPassE.Text = EmployeeTable.Rows[i].Cells[2].Value.ToString();
            txtFullnameE.Text = EmployeeTable.Rows[i].Cells[3].Value.ToString();
            txtPhoneE.Text = EmployeeTable.Rows[i].Cells[4].Value.ToString();
            txtAddressE.Text = EmployeeTable.Rows[i].Cells[5].Value.ToString();
            txtEmailE.Text = EmployeeTable.Rows[i].Cells[6].Value.ToString();
            txtStatusE.Text = EmployeeTable.Rows[i].Cells[7].Value.ToString();
        }

        private void btnAddEmployee_Click_1(object sender, EventArgs e)
        {
            if (validate())
            {
                if (DAO_Employee.Instance.insertAccount(getData()))
                {
                   MessageBox.Show("Thêm tài khoản thành công");
                   loadTable(LoadAllEmployeeAction);
                   setNull();
                }
                else
                {
                   MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
                }
            }
            
        }

        private void btnEditEmployee_Click_1(object sender, EventArgs e)
        {
            if (validate())
            {
                if (DAO_Employee.Instance.updateAccount(getData()))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công");
                    loadTable(LoadAllEmployeeAction);
                    setNull();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
                }
            }
        }

        private void btnPrimaryEmployee_Click(object sender, EventArgs e)
        {

        }

    }
}
