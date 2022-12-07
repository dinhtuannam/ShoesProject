using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DAO
{
    public class DAO_Quyen
    {
        private static DAO_Quyen instance;

        public static DAO_Quyen Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_Quyen();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_Quyen(){ }

        public DataTable getAllQuyen()
        {
            string query = "Select * from Quyen";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        
    }
}
