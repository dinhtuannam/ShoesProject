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
using ShoesProject.DAO;

namespace ShoesProject.UserControls
{
    public partial class UC_Genres : UserControl
    {
        public UC_Genres()
        {
            InitializeComponent();
        }

        private void UC_Genres_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dataGridView1.DataSource = DAO_Genres.Instance.getAllGenres();
          
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim().Equals("") && txtid.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không có id để chỉnh sửa");
                return;
            }
                if (!DAO_Genres.Instance.isGenresIDExist(txtid.Text))
            {
                MessageBox.Show("Không có id để chỉnh sửa");
                return;
            }
            DAO_Genres.Instance.updateQLTL(txtid.Text, txtname.Text, txttrangthai.Text);
            refreshtable();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim().Equals("") && txtid.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập tên hàng và id");
                return;
            }
            if (DAO_Genres.Instance.isGenresIDExist(txtid.Text))
            {
                MessageBox.Show("ID đã tồn tại, không được trùng id");
                return;
            }
            DAO_Genres.Instance.addQLTL(txtid.Text, txtname.Text, txttrangthai.Text);
            refreshtable();
        }
        public void refreshtable()
        {
            loadData();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            txtid.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            txttrangthai.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim().Equals("") && txtid.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không có id để xóa");
                return;
            }
                if (!DAO_Genres.Instance.isGenresIDExist(txtid.Text))
            {
                MessageBox.Show("ID không hợp lệ");
                return;
            }
            DAO_Genres.Instance.removeQLTL(txtid.Text);
            refreshtable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshtable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập id để tìm kiếm");
                return;
            }
            dataGridView1.DataSource = DAO_Genres.Instance.GetQLTLById(txttimkiem.Text);
           
        }
    }
}
