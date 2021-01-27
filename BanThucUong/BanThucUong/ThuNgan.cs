using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class ThuNgan:ConNguoi
    {
        public string MatKhau { get; set; }
        public ThuNgan(string iD, string hoTen,DateTime ngaySinh, string matKhau) : base(iD, hoTen, ngaySinh)
        {
            MatKhau = matKhau;
        }
        public static void PrintTable(List<ThuNgan> thuNgans)
        {
            Console.WriteLine("|{0,-10}|{1,-20}|{2,-12}|", "ID", "HoTen", "Ngay Sinh");
            thuNgans.ForEach(tn =>Console.WriteLine(tn.ThongTin()));
        }
        public static ThuNgan Find(string ID,Database database)
        {
            return database.ThuNgans.Where(tn => tn.ID == ID).FirstOrDefault();
        }
        public static void Add(ThuNgan thuNgan, Database database)
        {
            database.ThuNgans.Add(thuNgan);
        }
        public static void Delete(string iD,Database database)
        {
            database.ThuNgans.Remove(ThuNgan.Find(iD,database));
        }
        public static void Update(string oldID,ThuNgan newThuNgan,Database database)
        {
            ThuNgan thuNgan = ThuNgan.Find(oldID,database);
            thuNgan.Copy(newThuNgan);
        }

        public override void Copy(object ojb)
        {
            ThuNgan thuNgan = ojb as ThuNgan;
            ID = thuNgan.ID;
            HoTen = thuNgan.HoTen;
            NgaySinh = thuNgan.NgaySinh;
            MatKhau = thuNgan.MatKhau;
        }
    }
}
