using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    delegate void Update(object sender);
    class NhanVien : ConNguoi
    {
        public List<PhanCong> PhanCongs;
        public List<HoaDon> HoaDons { get; set; }

        public NhanVien(string iD, string hoTen, DateTime ngaySinh, List<PhanCong> phanCongs, List<HoaDon> hoaDons) : base(iD, hoTen, ngaySinh)
        {
            PhanCongs = phanCongs;
            HoaDons = hoaDons;
        }
        public NhanVien(string iD, string hoTen, DateTime ngaySinh) : base(iD, hoTen, ngaySinh)
        {
            PhanCongs = new List<PhanCong>();
            HoaDons = new List<HoaDon>();
        }
        public static void PrintTable(List<NhanVien> nhanViens)
        {
            Console.WriteLine("|{0,-10}|{1,-20}|{2,-12}|", "ID", "HoTen", "Ngay Sinh");
            nhanViens.ForEach(tn => Console.WriteLine(tn.ThongTin()));
        }

        public static NhanVien Find(string ID, Database database)
        {
            return database.NhanViens.Where(tn => tn.ID == ID).FirstOrDefault();
        }
        public static void Add(NhanVien nhanVien, Database database)
        {
            database.NhanViens.Add(nhanVien);
        }
        public static void Delete(string iD, Database database)
        {
            database.NhanViens.Remove(NhanVien.Find(iD, database));
        }
        public static void Update(string oldID, NhanVien newNhanVien, Database database)
        {
            NhanVien nhanVien = NhanVien.Find(oldID, database);
            nhanVien.Copy(newNhanVien);
        }
        public override void Copy(object ojb)
        {
            NhanVien nhanVien = ojb as NhanVien;
            ID = nhanVien.ID;
            HoTen = nhanVien.HoTen;
            NgaySinh = nhanVien.NgaySinh;
        }
    }
}
