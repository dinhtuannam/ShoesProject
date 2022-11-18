using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.UserControls.Bills
{
    internal class SQLData
    {
            string strconnect = "Data Source=ADMIN-PC\\HACO;Initial Catalog=QLShopGiay;Integrated Security=True";
            public SQLData()
            {

            }
            public DataTable getData(string query)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, strconnect);
                
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            public void Execute(string query)
            {
                SqlConnection connect = new SqlConnection(strconnect);
                connect.Open();
                SqlCommand command = new SqlCommand();
                command = connect.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                 connect.Close();
            }



        
    }


}
