using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ShoesProject.DTO
{
    public class DTO_Bill
    {
        private string id;
        private string id_cus;
        private string id_emp;
        private string date;
        private DTO_CTHD cthd;
        private string total;
        private string trangthai;
        public string ID
        {
            get => id;set => id = value;
        }
        public string ID_Cus
        {
            get => id_cus;set => id_cus=value;
        }
        public string ID_Emp
        {
            get => id_emp;set => id_emp = value;
        }
        public string Date
        {
            get => date;set => date = value;
        }
        public string TrangThai
        {
            get => trangthai;set=> trangthai = value;
        }
        public string Total
        {
            get => total;set => total = value;
        }
        public DTO_CTHD CTHD
        {
            get => cthd;set => cthd = value;
        }

    }
}