using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DAO
{
    public class DataProvider
    {
       string strCnn = "Data source= ADMIN\\SQLEXPRESS ;database= QLShopGiay ;Integrated Security = True";
       public DataTable ExecuteQuery(string query)
       {    
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(strCnn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            
            return data;
       }

        public int ExecuteNonQuery(string query)
        {
            int data = 0; 
            using (SqlConnection connection = new SqlConnection(strCnn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                data = command.ExecuteNonQuery();   
                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(strCnn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                data = command.ExecuteScalar();
                connection.Close();
            }

            return data;
        }
    }
    
}
