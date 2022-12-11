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
    public partial class UC_BanHang : UserControl
    {
        String SearchAction = "Name";
        String LoadAllSanPhamAction = "LoadAllSanPhamAction";
        String SearchSanPhamAction = "SearchSanPhamAction";
        public UC_BanHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadTableChart(LoadAllSanPhamAction);
        }

        private void loadTableChart(string action)
        {
            DataTable data = new DataTable();
            if (action == LoadAllSanPhamAction)
                data = DAO_BanHang.Instance.getAllSanPham();
            dataGridView1.DataSource = data;
        }

        private void UC_BanHang_Load(object sender, EventArgs e)
        {
            loadTableChart(LoadAllSanPhamAction);
        }
    }
}
