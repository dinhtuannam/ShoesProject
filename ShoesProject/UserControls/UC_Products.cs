using ShoesProject.DAO;
using ShoesProject.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject.UserControls
{
    public partial class UC_Products : UserControl
    {
        String GenresSelected;
        String SearchAction = "Name";
        String LoadAllProductAction = "LoadAllProductAction";
        String SearchProductAction = "SearchProductAction";
        public UC_Products()
        {
            InitializeComponent();
        }

        

        private void UC_Products_Load(object sender, EventArgs e)
        {
            ProductTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            loadProductTable(LoadAllProductAction);
            loadGenresCombobox();
            loadSearchCombobox();
        }

        private void loadProductTable(String action)
        {
            DataTable data = new DataTable();
            if (action == LoadAllProductAction)
                data = DAO_Product.Instance.getAllProduct();
            if (action == SearchProductAction)
                data = DAO_Product.Instance.searchProduct(txtSearch.Text,SearchAction);
            ProductTable.DataSource = data;
        }

        private void loadGenresCombobox()
        {
            List<string> genresArray = new List<string>();
            DataTable listGenres = DAO_Genres.Instance.getAllGenres();
            genresArray.Add("");
            for (int i = 0; i < listGenres.Rows.Count; i++)
            {
                genresArray.Add(listGenres.Rows[i][0].ToString());
            }
            txtGenres.DataSource = genresArray;
        }
        private void loadSearchCombobox()
        {
            List<string> searchList = new List<string>();
            searchList.Add("Name");
            searchList.Add("ID");
            cbSearch.DataSource = searchList;
        }

        private void ProductTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = ProductTable.CurrentRow.Index;
            int i = indexSelected;
            txtID.Text = ProductTable.Rows[i].Cells[0].Value.ToString();
            txtName.Text = ProductTable.Rows[i].Cells[1].Value.ToString();  
            txtImg.Text = ProductTable.Rows[i].Cells[2].Value.ToString();
            txtPrice.Text = ProductTable.Rows[i].Cells[3].Value.ToString();
            txtDes.Text = ProductTable.Rows[i].Cells[4].Value.ToString();
            txtGenres.SelectedIndex = txtGenres.FindString(ProductTable.Rows[i].Cells[5].Value.ToString());
            txtQuantity.Text = ProductTable.Rows[i].Cells[7].Value.ToString();

            string path = Path.Combine(ProductTable.Rows[i].Cells[2].Value.ToString());
            ProductPic.Image = Image.FromFile(path);
        }

        private void GenresSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchAction = cbSearch.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadProductTable(SearchProductAction);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadProductTable(LoadAllProductAction);
            setNull();
        }

        private void setNull()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtImg.Text = "";
            txtDes.Text = "";
            txtQuantity.Text = "";
            txtGenres.SelectedIndex = txtGenres.FindString("");
            txtSearch.Text = "";
        }

        private DTO_Product getData()
        {
            string path = "C:\\Users\\Administrator\\Desktop\\ShoesProject\\Shoes-img\\product-img";
            bool check = txtImg.Text.Contains(path);
            DTO_Product product = new DTO_Product();
            product.Id = txtID.Text;
            product.Name = txtName.Text;
            product.Img = txtImg.Text;
            product.Price = long.Parse( getPrice() );
            product.Des = txtDes.Text;
            product.Genres = GenresSelected;
            product.Status = "active";
            product.Quantity = int.Parse( txtQuantity.Text );

            if(check)
                product.Img = txtImg.Text;
            else
                product.Img = path+"\\"+txtImg.Text+".png";
            
            return product;
        }

        private String getPrice()
        {
            string[] item = txtPrice.Text.Split('.');
            return item[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DAO_Product.Instance.insertProduct(getData()))
            {
                MessageBox.Show("Thêm sản phẩm thành công ");
                string location = "C:\\Users\\Administrator\\Desktop\\ShoesProject\\Shoes-img\\product-img";
                string path = Path.Combine(location, txtImg.Text + ".png");
                Image a = ProductPic.Image;
                a.Save(path);
                setNull();
                loadProductTable(LoadAllProductAction);
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại . Vui lòng thử lại ");
            }

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGenres_SelectedValueChanged(object sender, EventArgs e)
        {
            GenresSelected = txtGenres.SelectedItem.ToString(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DAO_Product.Instance.updateProduct(getData()))
            {
                MessageBox.Show("Cập nhật sản phẩm thành công ");
                setNull();
                loadProductTable(LoadAllProductAction);
            }
            else
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại . Vui lòng thử lại ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DAO_Product.Instance.deleteProduct(txtID.Text))
            {
                MessageBox.Show("Xóa sản phẩm thành công ");
                setNull();
                loadProductTable(LoadAllProductAction);
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại . Vui lòng thử lại ");
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtDes.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if(p != null)
            {
                open.Filter = "(*.jpg;*.jpeg;*.png) | *.jpg;*.jpeg;*.png ";
                if(open.ShowDialog()== DialogResult.OK)
                {
                    p.Image = Image.FromFile(open.FileName);
                }
            }
        }
    }
}
