using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class PhanCong
    {
        public PhanCong(NhanVien nhanVien, Ban ban, string ca, DateTime ngayPC)
        {
            NhanVien = nhanVien;
            Ban = ban;
            Ca = ca;
            NgayPC = ngayPC;
        }
        public PhanCong()
        {
        }
        public NhanVien NhanVien { get; set; }
        public Ban Ban { get; set; }
        public string Ca { get; set; }
        public DateTime NgayPC { get; set; }

        public static PhanCong Find(string maNV, string maBan, Database database)
        {
            return database.PhanCongs.Where(b => b.Ban.MaBan == maBan).Where(b => b.NhanVien.GetID() == maNV).FirstOrDefault();
        }

        public static void Add(PhanCong phanCong, Database database)
        {
            database.PhanCongs.Add(phanCong);
            NhanVien.Find(phanCong.NhanVien.GetID(), database).PhanCongs.Add(phanCong);
            Ban.Find(phanCong.Ban.MaBan, database).PhanCong = phanCong;
        }
        public static void Delete(string maNV, string maBan, Database database)
        {
            database.PhanCongs.Remove(Find(maNV, maBan, database));
            NhanVien.Find(maNV, database).PhanCongs.Remove(Find(maNV, maBan, database));
            Ban.Find(maBan, database).PhanCong = null;
        }
        public static void Update(string maNV, string maBan, PhanCong phanCong, Database database)
        {
            Delete(maNV, maBan, database);
            Add(phanCong, database);
        }
        public static void PrintTable(List<PhanCong> phanCongs)
        {
            Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|{3,-20}|","MaVN","MaBan","Ca","NgayPC");
            phanCongs.ForEach(pc => Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|{3,-20}|", pc.NhanVien.GetID(), pc.Ban.MaBan, pc.Ca, pc.NgayPC.Date.ToString()));
        }
    }
}
