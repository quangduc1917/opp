using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class ThucUong
    {

        public string ID { get; set; }
        public string TenThucUong { get; set; }
        public string LoaiThuocUong { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public List<HoaDon> HoaDons { get; set; }
        public ThucUong()
        {

        }
        public ThucUong(string iD, string tenThucUong, string loaiThuocUong, int soLuong, int gia)
        {
            ID = iD;
            TenThucUong = tenThucUong;
            LoaiThuocUong = loaiThuocUong;
            SoLuong = soLuong;
            Gia = gia;
            HoaDons = new List<HoaDon>();
        }
        public static ThucUong Find(string iD, Database database)
        {
            return database.ThucUongs.Where(tu => tu.ID == iD).FirstOrDefault();
        }
        public static void Add(ThucUong thucUong, Database database)
        {
            database.ThucUongs.Add(thucUong);
        }
        public static void Delete(string ID, Database database)
        {
            database.ThucUongs.Remove(Find(ID, database));
        }
        public static void Update(string ID,ThucUong thucUong, Database database)
        {
            ThucUong tu = Find(ID,database);
            tu.Gia = thucUong.Gia;
            tu.LoaiThuocUong = thucUong.LoaiThuocUong;
            tu.SoLuong = thucUong.SoLuong;
            tu.Gia = thucUong.Gia;
        }
        public static void PrintTable(List<ThucUong> thucUongs)
        {
            Console.WriteLine("|{0,-10}|{1,-30}|{2,-30}|{3,-10}|{4,-20}|", "ID", "Ten", "Loai", "SoLuong", "Gia");
            thucUongs.ForEach(t => Console.WriteLine("|{0,-10}|{1,-30}|{2,-30}|{3,-10}|{4,-20}|", t.ID, t.TenThucUong, t.LoaiThuocUong, t.SoLuong, t.Gia.ToString()));
        }
    }
}
