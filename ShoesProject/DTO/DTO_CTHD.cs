using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DTO
{
    public class DTO_CTHD
    {
        private string[] idsp;
        private string[] namesp;
        private string[] soluong;
        private string[] total;

        public string[] IDSP
        {
            get => idsp;set => idsp = value;
        }
        public string[] NAMESP
        {
            get => namesp;set => namesp = value;
        }
        public string[] SOLUONG
        {
            get => soluong;set => soluong = value;
        }
        public string[] TOTAL
        {
            get => total;set => total = value;
        }
        public DTO_CTHD(int n)
        {
            IDSP = new string[n];
            NAMESP = new string[n];
            SOLUONG = new string[n];
            TOTAL = new string[n];
        }

    }
}
