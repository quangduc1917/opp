using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class Ban
    {
        public Ban(string maBan, int soGhe, PhanCong phanCong, List<HoaDon> hoaDon)
        {
            MaBan = maBan;
            SoGhe = soGhe;
            PhanCong = phanCong;
            HoaDons = hoaDon;
        }
        public Ban()
        {

        }
        public string MaBan { get; set; }
        public int SoGhe { get; set; }
        public PhanCong PhanCong { get; set; }
        public List<HoaDon> HoaDons { get; set; }

        public static Ban Find(string maBan,Database database)
        {
            return database.Bans.Where(b => b.MaBan == maBan).FirstOrDefault();
        }
        public static void Add(Ban Ban,Database database)
        {
            database.Bans.Add(Ban);
        }
        public static void Delete(string MaBan,Database database)
        {
            database.Bans.Remove(Find(MaBan, database));
        }
        public static void Update(string maBan,Ban ban,Database database)
        {
            Ban banCu = Find(maBan, database);
            banCu.SoGhe = ban.SoGhe;
        }
        public static void PrintTable(List<Ban> bans)
        {
            Console.WriteLine("|{0,-10}|{1,-10}|", "MaBan", "SoGhe");
            bans.ForEach(b => Console.WriteLine("|{0,-10}|{1,-10}|", b.MaBan, b.SoGhe));
        }
    }
}
