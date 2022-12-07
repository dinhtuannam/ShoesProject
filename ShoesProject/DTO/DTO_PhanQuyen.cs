using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesProject.DTO
{
    public class DTO_PhanQuyen
    {
        string QLSP;
        string QLNV;
        string QLKH;
        string QLTL;
        string QLHD;
        string TKKD;
        string TKSP;
        string QLPQ;
        string BanHang;

        public DTO_PhanQuyen(string qLSP, string qLNV, string qLKH, string qLTL, string qLHD, string tKKD, string tKSP, string qLPQ, string banHang)
        {
            QLSP = qLSP;
            QLNV = qLNV;
            QLKH = qLKH;
            QLTL = qLTL;
            QLHD = qLHD;
            TKKD = tKKD;
            TKSP = tKSP;
            QLPQ = qLPQ;
            BanHang = banHang;
            
        }   

        public DTO_PhanQuyen() {
            QLSP = "";
            QLNV = "";
            QLKH = "";
            QLTL = "";
            QLHD = "";
            TKKD = "";
            TKSP = "";
            QLPQ = "";
            BanHang = "";
        }

        public string QLSP1 { get => QLSP; set => QLSP = value; }
        public string QLNV1 { get => QLNV; set => QLNV = value; }
        public string QLKH1 { get => QLKH; set => QLKH = value; }
        public string QLTL1 { get => QLTL; set => QLTL = value; }
        public string QLHD1 { get => QLHD; set => QLHD = value; }
        public string TKKD1 { get => TKKD; set => TKKD = value; }
        public string TKSP1 { get => TKSP; set => TKSP = value; }
        public string QLPQ1 { get => QLPQ; set => QLPQ = value; }
        public string BanHang1 { get => BanHang; set => BanHang = value; }
    }
}
