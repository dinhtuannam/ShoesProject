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

namespace ShoesProject.UserControls
{
    public partial class UC_QLQuyen : UserControl
    {
        private static UC_QLQuyen instance;
        public static UC_QLQuyen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UC_QLQuyen();
                }

                return instance;

            }
            private set
            {
                instance = value;
            }
        }
        public UC_QLQuyen()
        {
            InitializeComponent();
        }
       
       public void loadTable()
        {
            dataGridView1.DataSource = DAO_Quyen.Instance.getAllQuyen();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void UC_QLQuyen_Load(object sender, EventArgs e)
        {
            loadTable();
            lbtrangthai.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text.Trim() == "")
            {
                loadTable();
            }
            else
            {
               dataGridView1.DataSource= DAO_Quyen.Instance.getQuyenByID(txtsearch.Text.Trim());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            txtid.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() == "" || txtname.Text.Trim() == "")
            {
                lbtrangthai.Text = "vui lòng nhập đày đủ thông tin";
                return;
            }
            if (DAO_Quyen.Instance.isQuyenIDExist(txtid.Text.Trim()))
            {
                lbtrangthai.Text = "ID trùng lặp";
                return;
            }
            DAO_Quyen.Instance.addQuyen(txtid.Text.Trim(), txtname.Text.Trim());

            loadTable();
            lbtrangthai.Text = "Thêm quyền thành công";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() == "" || txtname.Text.Trim() == "")
            {
                lbtrangthai.Text = "Vui lòng nhập đày đủ thông tin";
                return;
            }
            if (!DAO_Quyen.Instance.isQuyenIDExist(txtid.Text.Trim()))
            {
                lbtrangthai.Text = "ID không tồn tại";
                return;
            }
            DAO_Quyen.Instance.updateQuyen(txtid.Text.Trim(), txtname.Text.Trim());
            loadTable();
            lbtrangthai.Text = "Chỉnh sửa quyền thành công";
        }

       

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if(txtid.Text.Trim()== "")
            {
                lbtrangthai.Text = "Vui lòng nhập id để xoá";
            }
            if (!DAO_Quyen.Instance.remove(txtid.Text.Trim()))
            {
                lbtrangthai.Text = String.Format("Vui lòng xoá những thứ có ràng buộc với quyền {0}",txtid.Text.Trim());
                return;
            }
            loadTable();
            lbtrangthai.Text = "Xoá quyền thành công";
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
