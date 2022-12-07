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
        string selectRow = "select CTQ.idQuyen , CTQ.idCN , tenQuyen ,tenCN from CTQ,CHUCNANG,QUYEN ";
        string condition = "where CTQ.idCN = CHUCNANG.idCN and QUYEN.idQuyen = CTQ.idQuyen";
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

        public DataTable getPhanQuyenTable()
        {
            string query = selectRow + condition;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool isExist(string idQ, string idCN)
        {
            bool result = false;
            string query = selectRow + condition+ " and CTQ.idCN = '"+idCN+"' and CTQ.idQuyen = '"+idQ+"' ";
            DataTable dt =  DataProvider.Instance.ExecuteQuery(query);
            result = dt.Rows.Count > 0;
            return result;
        }

        public bool insertQuyen(string idQ, string idCN)
        {
            int result = 0;
            string query = "insert into CTQ(idQuyen,idCN) values( @idQuyen , @idCN )";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idQ,idCN });
            return result > 0;
        }

        public bool deleteQuyen(string idQ, string idCN)
        {
            int result = 0;
            string query = "delete from CTQ where idQuyen = @idQ and idCN = @idCN";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idQ, idCN });
            return result > 0;
        }

        public DataTable filterQuyen(string Quyen, string CN)
        {
            string query = selectRow + condition + generateQuery1(Quyen) + generateQuery2(CN);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        private string generateQuery1(string Quyen)
        {
            string query = "";
            if (Quyen == "ALL")
                query = "";
            else
                query = " and Quyen.tenQuyen like '%"+Quyen+"%' ";
            return query;
        }

        private string generateQuery2(string ChucNang)
        {
            string query = "";
            if (ChucNang == "ALL")
                query = "";
            else
                query = " and ChucNang.tenCN like '%" + ChucNang + "%' ";
            return query;
        }
    }
}
