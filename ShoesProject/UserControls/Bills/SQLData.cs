using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;

namespace ShoesProject.UserControls.Bills
{
    internal class SQLData
    {
        string strconnect = "Data source= ADMIN\\SQLEXPRESS ;database= QLShopGiay ;Integrated Security = True";
            public SQLData()
            {

            }
            public DataTable getData(string query,ref Boolean success)
           
            {
            if (query.Equals(""))
            {
                MessageBox.Show("Cau truy van trong rong");
                success = false;
                return null;
            }
            DataTable table = new DataTable();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, strconnect)){
                    adapter.Fill(table);
                    success = true;
                    return table;
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
                success = false;
                return null;
            }
            }
            public void Execute(string query,ref Boolean success)
            {
            if (query.Equals(""))
            {
                MessageBox.Show("Cau truy van trong rong");
                success = false;
                return ;
            }
            SqlConnection connect = null ;
            try
            {
                connect = new SqlConnection(strconnect);
                connect.Open();
                SqlCommand command = new SqlCommand();
                command = connect.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                success = true;
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception:" + e.Message);
                success = false;
            }
            finally
            {
                if (connect != null)
                connect.Close();
                
            }
                 
            }
            public object Scalar(string query,ref Boolean success)
            {
            if (query.Equals(""))
            {
                MessageBox.Show("Cau truy van trong rong");
                success = false;
                return null;
            }
            SqlConnection connect = null;
            try
            {
                connect = new SqlConnection(strconnect);
                connect.Open();
                SqlCommand command = new SqlCommand();
                command = connect.CreateCommand();
                command.CommandText = query;
                object temp = command.ExecuteScalar();
                success = true;
                return temp;
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception:" + e.Message);
                success = false;
                return null;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
                
            }
            }



        
    }


}
