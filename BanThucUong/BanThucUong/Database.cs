using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    public enum DatabaseType
    {
        SQLSever,
        MySQL,
        MongoDB
    }
    class Database
    {
        public Database()
        {
            PhanCongs = new List<PhanCong>();
            NhanViens = new List<NhanVien>();
            HoaDons = new List<HoaDon>();
            Bans = new List<Ban>();
            ThucUongs = new List<ThucUong>();
            ThuNgans = new List<ThuNgan>();
            QuanLys = new List<QuanLy>();
        }
        public List<PhanCong> PhanCongs { set; get; }
        public List<NhanVien> NhanViens { set; get; }
        public List<HoaDon> HoaDons { get; set; }
        public List<Ban> Bans { get; set; }
        public List<ThucUong> ThucUongs { get; set; }
        public List<ThuNgan> ThuNgans { get; set; }
        public List<QuanLy> QuanLys { get; set; }

        public DatabaseType TypeDB { set; get; }
        public string ChuoiKetNoi { get; set; }
        public string KieuDatabase { get; set; }
        public string TenDatabase { get; set; }
    }
}
