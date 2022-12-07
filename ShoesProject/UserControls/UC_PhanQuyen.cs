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
    public partial class UC_PhanQuyen : UserControl
    {
        string IDQuyenSelected = "AD";
        string IDCNSelected = "CN1";
        string QuyenFilterSelected = "ALL";
        string CNFilterSelected = "ALL";


        string loadAllQuyenAction = "loadAllQuyenAction ";
        string filterQuyenAction = "filterQuyenAction";
        
        public UC_PhanQuyen()
        {
            InitializeComponent();
        }
        private void UC_PhanQuyen_Load(object sender, EventArgs e)
        {
            loadTable(loadAllQuyenAction);
            loadCombobox();
            QuyenTable.Columns[3].Width = 254;
        }

        private void loadTable(string action)
        {
            DataTable dt = new DataTable();
            if(action == loadAllQuyenAction)
                dt = DAO_PhanQuyen.Instance.getPhanQuyenTable();
            if (action == filterQuyenAction)
                dt = DAO_PhanQuyen.Instance.filterQuyen(QuyenFilterSelected, CNFilterSelected);
            QuyenTable.DataSource = dt;
            QuyenTable.Columns[3].Width = 254;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelect = QuyenTable.CurrentRow.Index;
            int i = indexSelect;
            txtIDQuyen.Text = QuyenTable.Rows[i].Cells[0].Value.ToString();
            txtIDCN.Text = QuyenTable.Rows[i].Cells[1].Value.ToString();
            txtTenQuyen.Text = QuyenTable.Rows[i].Cells[2].Value.ToString();
            txtTenCN.Text = QuyenTable.Rows[i].Cells[3].Value.ToString();
            
        }

        private void loadCombobox()
        {
            DataTable dt = DAO_ChucNang.Instance.getChucNang();
            List<string> IDCN = new List<string>();
            List<string> TENCN = new List<string>();
            TENCN.Add("ALL");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IDCN.Add(dt.Rows[i][0].ToString());
                TENCN.Add(dt.Rows[i][1].ToString());
            }
            CNFilter.DataSource = TENCN;
            CNCbox.DataSource = IDCN;


            DataTable dt2 = DAO_Quyen.Instance.getAllQuyen();
            List<string> IDQUYEN = new List<string>();
            List<string> TENQUYEN = new List<string>();
            TENQUYEN.Add("ALL");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                IDQUYEN.Add(dt2.Rows[i][0].ToString());
                TENQUYEN.Add(dt2.Rows[i][1].ToString());
            }
            QuyenFilter.DataSource = TENQUYEN;
            QuyenCbox.DataSource = IDQUYEN;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (DAO_PhanQuyen.Instance.isExist(IDQuyenSelected, IDCNSelected))
                MessageBox.Show("Quyền này đã tồn tại không thể thêm");
            else
            {
                if (DAO_PhanQuyen.Instance.insertQuyen(IDQuyenSelected, IDCNSelected))
                {
                    MessageBox.Show("Thêm quyền thành công");
                    setNull();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
            }
        }

        private void QuyenCbox_SelectedValueChanged(object sender, EventArgs e)
        {
            IDQuyenSelected = QuyenCbox.SelectedItem.ToString();
        }

        private void CNCbox_SelectedValueChanged(object sender, EventArgs e)
        {
            IDCNSelected = CNCbox.SelectedItem.ToString();
        }

        private void deleterBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa quyền này", "Xóa quyền", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (DAO_PhanQuyen.Instance.deleteQuyen(txtIDQuyen.Text, txtIDCN.Text))
                {
                    MessageBox.Show("Xóa quyền thành công");
                    setNull();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại");
            }
            
        }

        private void QuyenFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            QuyenFilterSelected = QuyenFilter.SelectedItem.ToString();
        }

        private void CNFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            CNFilterSelected = CNFilter.SelectedItem.ToString();    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadTable(filterQuyenAction);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            setNull();

        }

        private void setNull()
        {
            txtIDCN.Text = "";
            txtIDQuyen.Text = "";
            txtTenCN.Text = "";
            txtTenQuyen.Text = "";
            loadTable(loadAllQuyenAction);
        }
    }
}
