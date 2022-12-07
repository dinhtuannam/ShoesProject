using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DAO
{
    class DAO_PhanQuyen
    {
        private static DAO_PhanQuyen instance;

        public static DAO_PhanQuyen Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_PhanQuyen();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_PhanQuyen() { }

        public DataTable getPhanQuyen(string data)
        {
            string query = "select idQuyen , CTQ.idCN , tenCN from CTQ,CHUCNANG where idQuyen= '"+data+"' and CTQ.idCN = CHUCNANG.idCN";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
