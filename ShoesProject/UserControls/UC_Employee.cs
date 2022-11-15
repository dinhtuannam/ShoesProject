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
    public partial class UC_Employee : UserControl
    {
        public UC_Employee()
        {
            InitializeComponent();
            LoadAccountList();
        }

        private void LoadAccountList()
        {
            string query = "Select * from TAIKHOAN";
            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query); 
<<<<<<< HEAD
=======
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {

>>>>>>> a278921957f272b261c5975e3fd51f736fe559c0
        }
    
    }
}
