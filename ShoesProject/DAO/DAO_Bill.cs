using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoesProject.DAO
{
    public class DAO_Bill
    {
        private static DAO_Bill instance;
        public static DAO_Bill Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_Bill();

                }
                return instance;
            }
            private set
            {
                instance = value;
            }

        }
        public bool IsEnough(string id,string id2,int amount)
        {
            string query = "select sanpham.soluong -sl.soluongchokhach from sanpham,(select coalesce(sum(soluong),0)  as soluongchokhach from hoadon hd ,cthd where hd.idhd = cthd.idhd and hd.trangthai = 'unconfirmed' and cthd.idsp = @id and hd.idhd <> @id2 ) as sl where sanpham.idsp = @id3 ";
            object temp = DataProvider.Instance.ExecuteScalar(query, new object[] { id, id2, id });
            int valid =int.Parse(temp.ToString());
            if (amount <= valid)
            {
                return true;
            }
            return false;
        }
        public int decreaseProduct(string id ,int amount)
        {
            string query = "Update sanpham set soluong = soluong - @soluong where idsp= @id ";
            return DataProvider.Instance.ExecuteNonQuery(query,new object[] {amount,id});
        }
        public bool isBillIDExist(string id)
        {
            string query = "Select idhd from hoadon where idhd = @id ";
            object temp =DataProvider.Instance.ExecuteScalar(query,new object[] {id});
            if (temp == null)
            {
                return false;
            }
            return true;
        }
        public bool isCustomerIDExist(string id)
        {
            string query = "Select idkh from khachhang where idkh = @id ";
            object temp =DataProvider.Instance.ExecuteScalar(query,new object[] {id});
            if (temp == null)
            {
                return false;
            }
            return true;
        }
    
        public bool isEmployeeIDExist(string id)
        {
            string query = "Select idnv from nhanvien where idnv = @id ";
            object temp = DataProvider.Instance.ExecuteScalar(query, new object[] { id });
            if (temp == null)
            {
                return false;
            }
            return true;
        }
        public DataTable getAllBill()
        {
            string query = "select * from hoadon";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getBillByID(string id)
        {
            string query = "Select * from hoadon where idhd = @id ";
            return DataProvider.Instance.ExecuteQuery(query, new object[] {id});
        }
        public int deleteBill(string id)
        {
            string query;
            query = "Delete from hoadon where idhd= @id ";
            return  DataProvider.Instance.ExecuteNonQuery(query, new object[] {id});
        }
        public int deleteCTHDByID(string id)
        {
            string query = "Delete from cthd where idhd = @id ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }
        public int deleteAllBill()
        {
            string query ="Delete from hoadon" ;
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int addBill(string id, object employee_id, string customer_id, string date, string total, string trangthai)
        {
            int n;
            string query = "insert into hoadon values ( @id , @employee_id , @customer_id , @date , @total , @trangthai )";
            if (employee_id != DBNull.Value)
            {
                string idemployee;
                idemployee = employee_id.ToString();
                n = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, idemployee, customer_id, date, total, trangthai });

            }
            else
            {
                n = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, employee_id, customer_id, date, total, trangthai });

            }
            return n;
        }
        public int addCTHD(string id, string[] idsp, string[] soluong, string[] totalsp)
        {
            string query;
            int n = 0;
            for (int i = 0; i < idsp.Length; i++)
            {
                query = "insert into cthd values ( @id , @idsp , @soluong , @total )";
         
                n += DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, idsp[i], soluong[i], totalsp[i] });
            }
            return n;
        }
        public object getPriceByID(string id)
        {
            string query = "select gia from sanpham where idsp = @id ";
            return DataProvider.Instance.ExecuteScalar(query,new object[]{id});
        }
    
        public object getNameNVByID(string id)
        {
            string query = "select tennv from nhanvien where idnv= @id ";
            return DataProvider.Instance.ExecuteScalar(query,new object[] {id});
        }
        public object getNameKHByID(string id)
        {
            string query = "select tenkhachhang from khachhang where idkh = @id ";
            return DataProvider.Instance.ExecuteScalar(query,new object[] {id});
        }
        public DataTable getCTHD(string id)
        {
            string query = "select idsp ,soluong,tongtien from cthd where idhd = @id ";
            return DataProvider.Instance.ExecuteQuery(query,new object[] {id}); 
        }
        public int updateBill(string idhd,object idnv ,string idkh,string date,string total,string trangthai)
        {
            string query = "Update hoadon set idnv = @idnv , idkh = @idkh , ngaydat = @date , tongtien = @total , trangthai = @trangthai where idhd = @idhd ";
            int n;
            if (idnv != DBNull.Value)
            {
                string idnhanvien = idnv.ToString();
                n=DataProvider.Instance.ExecuteNonQuery(query, new object[] { idnhanvien, idkh, date, total, trangthai, idhd });
            }
            else
            {

                n = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idnv, idkh, date, total, trangthai, idhd });
            }
               return n;
        }
        public bool isProductIDExist(string id)
        {
            string query = "select * from sanpham where idsp = @id";
            object temp = DataProvider.Instance.ExecuteScalar(query,new object[] {id});
            if (temp == null)
            {
                return false;
            }
            return true;
        }
    }

}
