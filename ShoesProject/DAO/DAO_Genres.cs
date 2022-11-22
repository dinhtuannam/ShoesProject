using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DAO
{
    public class DAO_Genres
    {
        private static DAO_Genres instance;

        public static DAO_Genres Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_Genres();
                return instance;
            }
            private set { instance = value; }
        }

        private DAO_Genres() { }

        public DataTable getAllGenres()
        {
            string query = "Select * from theloai";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
