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
        public DataTable getAllQuyen()
        {
            string query = "Select * from quyen";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getQuyenById(string id)
        {
            string query = "Select * from quyen where idquyen= @id ";
            return DataProvider.Instance.ExecuteQuery(query,new object[] { id});
        }
       
    }
}
