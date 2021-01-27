using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class QuanLy : ConNguoi
    {
        public string MatKhau { get; set; }
        public QuanLy(string ID,string hoTen,DateTime ngaySinh,string matKhau):base(ID,hoTen,ngaySinh) 
        {
            MatKhau = matKhau;
        }

        public static void PrintTable(List<QuanLy> quanLys)
        {
            Console.WriteLine("|{0,-10}|{1,-20}|{2,-12}|", "ID", "HoTen", "Ngay Sinh");
            quanLys.ForEach(tn =>Console.WriteLine(tn.ThongTin()));
        }

        public static QuanLy Find(string ID,Database database)
        {
            return database.QuanLys.Where(tn => tn.ID == ID).FirstOrDefault();
        }
        public static void Add(QuanLy quanly, Database database)
        {
            database.QuanLys.Add(quanly);
        }
        public static void Delete(string iD,Database database)
        {
            database.QuanLys.Remove(QuanLy.Find(iD,database));
        }
        public static void Update(string oldID,QuanLy newQuanLy,Database database)
        {
            QuanLy quanLy = QuanLy.Find(oldID,database);
            quanLy.Copy(newQuanLy);
        }

        public override void Copy(object ojb)
        {
            QuanLy quanLy = ojb as QuanLy;
            ID = quanLy.ID;
            HoTen = quanLy.HoTen;
            NgaySinh = quanLy.NgaySinh;
            MatKhau = quanLy.MatKhau;
        }
    }
}
