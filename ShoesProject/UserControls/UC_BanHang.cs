using ShoesProject.DAO;
using ShoesProject.DTO;
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

        List<DTO_BanHang> BuyList = new List<DTO_BanHang>();
        DTO_BanHang itemSelected = new DTO_BanHang();
        string itemDeleteSelected;
        string IDEmp = "";
        long total = 0;
        public UC_BanHang(string id)
        {
            InitializeComponent();
            IDEmp = id;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = dataGridView1.CurrentRow.Index;
            int i = indexSelected;

            string[] price = dataGridView1.Rows[i].Cells[3].Value.ToString().Split('.');
            
            itemSelected.ID1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
            itemSelected.Name1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
            itemSelected.Genres1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
            itemSelected.Price1 = long.Parse( price[0].ToString() );
            itemSelected.Quantity1 = 1;

            txtItemSelected.Text = "Item: "+itemSelected.ID1;


        }

        private void loadTableChart(string action)
        {
            DataTable data = new DataTable();
            if (action == LoadAllSanPhamAction)
                data = DAO_BanHang.Instance.getAllSanPham();
            if (action == SearchSanPhamAction)
                data = DAO_BanHang.Instance.searchSanPham(txtSearchBH.Text, SearchAction);
            dataGridView1.DataSource = data;
            resizeTable();
        }

        private void resizeTable()
        {
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 50;
        }

        private void resizeTable2()
        {
            dataGridView2.Columns[0].Width = 60;
            dataGridView2.Columns[1].Width = 140;
            dataGridView2.Columns[2].Width = 60;
            dataGridView2.Columns[3].Width = 60;
            dataGridView2.Columns[4].Width = 50;

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Tên";
            dataGridView2.Columns[2].HeaderText = "Thể loại";
            dataGridView2.Columns[3].HeaderText = "Số lượng";
            dataGridView2.Columns[4].HeaderText = "Tổng tiền";
        }

        private void UC_BanHang_Load(object sender, EventArgs e)
        {
            loadTableChart(LoadAllSanPhamAction);
        }

        private void btnSearchBH_Click(object sender, EventArgs e)
        {
            loadTableChart(SearchSanPhamAction);
        }

        private void loadTableStorage()
        {
            List<DTO_BanHang> tmp = new List<DTO_BanHang>();
            total = 0;
            for (int i = 0; i < BuyList.Count; i++)
            {
                tmp.Add(BuyList[i]);
                total = total + BuyList[i].Price1;
            }
            txtTotal.Text = "Total :"+total.ToString();
            dataGridView2.DataSource = tmp;
            resizeTable2();
        }

        private void btnAddBH_Click(object sender, EventArgs e)
        {
            if (itemSelected.ID1 == "")
                MessageBox.Show("Vui lòng chọn sản phẩm");
            else
            {
                bool result = false;
                for (int i = 0; i < BuyList.Count; i++)
                {
                    if (BuyList[i].ID1 == itemSelected.ID1)
                    {
                        BuyList[i].Quantity1++;
                        BuyList[i].Price1 = itemSelected.Price1 * BuyList[i].Quantity1;
                        result = true;
                    }
                }

                if (!result)
                {
                    DTO_BanHang bh = new DTO_BanHang();
                    bh.ID1 = itemSelected.ID1;
                    bh.Name1 = itemSelected.Name1;
                    bh.Genres1 = itemSelected.Genres1;
                    bh.Quantity1 = itemSelected.Quantity1;
                    bh.Price1 = itemSelected.Price1 * bh.Quantity1;
                    BuyList.Add(bh);
                }

                loadTableStorage();
            }
        }

        private void btnEditBH_Click(object sender, EventArgs e)
        {
            if (itemDeleteSelected == "")
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa");
            else
            {
                BuyList.RemoveAll(r => r.ID1 == itemDeleteSelected);
                loadTableStorage();
            }
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            if (BuyList.Count == 0)
                MessageBox.Show("Vui lòng chọn sản phẩm cần mua");
            else
            {
                if (DAO_BanHang.Instance.Buy(BuyList, IDEmp, total))
                {
                    MessageBox.Show("Mua hàng thành công");
                    BuyList.Clear();
                    loadTableStorage();
                }                   
                else
                    MessageBox.Show("Vui lòng thử lại");

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = dataGridView2.CurrentRow.Index;
            int i = indexSelected;
            itemDeleteSelected = dataGridView2.Rows[i].Cells[0].Value.ToString();
            txtItemSelected.Text = "Item: " + itemDeleteSelected;
        }
    }
}
