using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class HoaDon
    {
        public HoaDon(string iD, DateTime ngayLap, Ban ban, NhanVien nhanVien, List<ThucUong> thucUongs)
        {
            ID = iD;
            NgayLap = ngayLap;
            Ban = ban;
            NhanVien = nhanVien;
            ThucUongs = thucUongs;
        }
        public HoaDon()
        {

        }
        public string ID { get; set; }
        public DateTime NgayLap { get; set; }
        public Ban Ban { get; set; }
        public NhanVien NhanVien { get; set; }
        public List<ThucUong> ThucUongs { get; set; }

        public static HoaDon Find(string ID, Database database)
        {
            return database.HoaDons.Where(h => h.ID == ID).FirstOrDefault();
        }
        public static void Add(HoaDon hoaDon, Database database)
        {
            database.HoaDons.Add(hoaDon);
            Ban.Find(hoaDon.Ban.MaBan, database).HoaDons.Add(hoaDon);
            NhanVien.Find(hoaDon.NhanVien.GetID(), database).HoaDons.Add(hoaDon);
            hoaDon.ThucUongs.ForEach(t => ThucUong.Find(t.ID, database).HoaDons.Add(hoaDon));
            hoaDon.ThucUongs.ForEach(t => ThucUong.Find(t.ID, database).SoLuong--);

        }
        public static void Delete(string ID, Database database)
        {
            var hoadon = Find(ID, database);
            database.HoaDons.Remove(hoadon);
            Ban.Find(hoadon.Ban.MaBan, database).HoaDons.Remove(hoadon);
            NhanVien.Find(hoadon.NhanVien.GetID(), database).HoaDons.Remove(hoadon);
            hoadon.ThucUongs.ForEach(t => ThucUong.Find(t.ID, database).HoaDons.Remove(hoadon));
        }
        public static void Update(string ID, HoaDon hoaDon, Database database)
        {
            Delete(ID, database);
            Add(hoaDon, database);
        }
        public static int TongTien(string ID, Database database)
        {
            int t = 0;
            Find(ID, database).ThucUongs.ForEach(tu => t += tu.Gia);
            return t;
        }
        public static void PrintTable(Database database)
        {
            Console.WriteLine("|{0,-10}|{1,-30}|{2,-10}|{3,-10}|{4,-10}|", "ID", "NgayLap", "Ban", "NhanVien", "TongTien");
            database.HoaDons.ForEach(h => Console.WriteLine("|{0,-10}|{1,-30}|{2,-10}|{3,-10}|{4,-10}|", h.ID, h.NgayLap.Date.ToString(), h.Ban.MaBan, h.NhanVien.GetID(),TongTien(h.ID,database)));
        }
    }
}
