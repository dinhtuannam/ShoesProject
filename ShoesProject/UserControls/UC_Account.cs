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
    public partial class UC_Account : UserControl
    {
        public UC_Account()
        {
            InitializeComponent();
            LoadAccountList();
        }

        private void LoadAccountList()
        {
            string query = "Select * from TAIKHOAN";
            DataProvider provider = new DataProvider();
            dtgvAccount.DataSource = provider.ExecuteQuery(query); 
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
