using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            TaoDuLieu(database);
            while (true)
            {
                string cv;
                string mode;
                while (true)
                {
                    cv = DangNhap(database);
                    if (cv != null) break;
                }
                if (cv == "-1")
                    return;
                if (cv == "ql")
                {
                    while (true)
                    {
                        Console.Clear();
                        ConsoleView.Menu("0: Thoat", "1: Quan Ly Hoa Don", "2: Quan Ly Nhan Vien", "3: Quan Ly Phan Cong", "4: Quan ly Ban", "5: Quan Ly Thuc Uong", "6: Quan Ly Thu Ngan");
                        mode = Console.ReadLine();
                        if (mode == "0")
                            break;
                        if (mode == "1")
                        {
                            QLHD(database);
                        }
                        if (mode == "2")
                        {
                            QLNV(database);
                        }
                        if (mode == "3")
                        {
                            QLPC(database);
                        }
                        if (mode == "4")
                        {
                            QLB(database);
                        }
                        if (mode == "5")
                        {
                            QLTU(database);
                        }
                        if (mode == "6")
                        {
                            QLTN(database);
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        ConsoleView.Menu("0: Thoat", "1: Quan Ly Hoa Don", "2: Xem Nhan Vien", "3: Xem Phan Cong", "4: Xem Ban", "5: Xem Thuc Uong");
                        mode = Console.ReadLine();
                        if (mode == "0")
                            break;
                        if (mode == "1")
                        {
                            QLHDTN(database);
                        }
                        if (mode == "2")
                        {
                            while (true)
                            {
                                Console.Clear();
                                ConsoleView.Menu("0:Thoat");
                                NhanVien.PrintTable(database.NhanViens);
                                Console.Write("chon mode:");
                                string i = Console.ReadLine();
                                if (i == "0") break;
                            }
                        }
                        if (mode == "3")
                        {
                            while (true)
                            {
                                Console.Clear();
                                ConsoleView.Menu("0:Thoat");
                                PhanCong.PrintTable(database.PhanCongs);
                                Console.Write("chon mode:");
                                string i = Console.ReadLine();
                                if (i == "0") break;
                            }

                        }
                        if (mode == "4")
                        {
                            while (true)
                            {
                                Console.Clear();
                                ConsoleView.Menu("0:Thoat");
                                Ban.PrintTable(database.Bans);
                                Console.Write("chon mode:");
                                string i = Console.ReadLine();
                                if (i == "0") break;
                            }

                        }
                        if (mode == "5")
                        {
                            while (true)
                            {
                                Console.Clear();
                                ConsoleView.Menu("0:Thoat");
                                ThucUong.PrintTable(database.ThucUongs);
                                Console.Write("chon mode:");
                                string i = Console.ReadLine();
                                if (i == "0") break;
                            }

                        }
                    }
                }

            }
        }
        public static string NhapXoaID(string table, Database database)
        {
            int i = 0;
            string ID;
            while (true)
            {
                switch (table)
                {
                    case "NhanVien":
                        Console.Write("nhap Id nhan vien:");
                        ID = Console.ReadLine();
                        if (NhanVien.Find(ID, database) != null)
                            return ID;
                        break;
                    case "HoaDon":
                        Console.Write("nhap Id hoa don:");
                        ID = Console.ReadLine();
                        if (HoaDon.Find(ID, database) != null)
                            return ID;
                        break;
                    case "ThucUong":
                        Console.Write("nhap Id thuc uong (nhap 'stop' de dung lai):");
                        ID = Console.ReadLine();
                        if (ThucUong.Find(ID, database) != null)
                            return ID;
                        if (ID == "stop")
                            return "stop";
                        break;
                    case "ThuNgan":
                        Console.Write("nhap Id thu ngan:");
                        ID = Console.ReadLine();
                        if (ThuNgan.Find(ID, database) != null)
                            return ID;
                        break;
                    case "Ban":
                        Console.Write("nhap Id ban:");
                        ID = Console.ReadLine();
                        if (Ban.Find(ID, database) != null)
                            return ID;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Id khong ton tai");
                if (++i == 3) return string.Empty;
            }
        }
        public static string NhapTaoID(string table, Database database)
        {
            int i = 0;
            while (true)
            {
                Console.Write("nhap Id:");
                string ID = Console.ReadLine();
                switch (table)
                {
                    case "NhanVien":
                        if (NhanVien.Find(ID, database) == null)
                            return ID;
                        break;
                    case "HoaDon":
                        if (HoaDon.Find(ID, database) == null)
                            return ID;
                        break;
                    case "ThucUong":
                        if (ThucUong.Find(ID, database) == null)
                            return ID;
                        break;
                    case "ThuNgan":
                        if (ThuNgan.Find(ID, database) == null)
                            return ID;
                        break;
                    case "Ban":
                        if (Ban.Find(ID, database) == null)
                            return ID;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Id da ton tai");
                if (++i == 3) return string.Empty;
            }
        }
        public static void TaoDuLieu(Database database)
        {
            Ban.Add(new Ban("ban01", 3, new PhanCong(), new List<HoaDon>()), database);
            Ban.Add(new Ban("ban02", 2, new PhanCong(), new List<HoaDon>()), database);
            NhanVien.Add(new NhanVien("nv01", "Minh Duc", DateTime.Now), database);
            NhanVien.Add(new NhanVien("nv02", "Thanh Long", DateTime.Now), database);
            PhanCong.Add(new PhanCong(NhanVien.Find("nv01", database), Ban.Find("ban01", database), "ca4", DateTime.Now), database);
            PhanCong.Add(new PhanCong(NhanVien.Find("nv02", database), Ban.Find("ban02", database), "ca4", DateTime.Now), database);
            QuanLy.Add(new QuanLy("ql01", "Thanh Lam", DateTime.Now, "123123"), database);
            ThuNgan.Add(new ThuNgan("tn01", "Hieu Vo", DateTime.Now, "123123"), database);
            ThucUong.Add(new ThucUong("tu01", "Bia Sai Gon", "Co Con", 100, 200000), database);
            ThucUong.Add(new ThucUong("tu02", "Sinh To Buoi", "Sinh To", 20, 40000), database);
            ThucUong.Add(new ThucUong("tu03", "cocacola", "nuoc ngot", 100, 20000), database);
            List<ThucUong> thucUongs = new List<ThucUong>();
            thucUongs.Add(ThucUong.Find("tu01", database));
            thucUongs.Add(ThucUong.Find("tu02", database));
            List<ThucUong> thucUongs2 = new List<ThucUong>();
            thucUongs2.Add(ThucUong.Find("tu01", database));
            HoaDon.Add(new HoaDon("hd01", DateTime.Now, Ban.Find("ban01", database), NhanVien.Find("nv01", database), thucUongs), database);
            HoaDon.Add(new HoaDon("hd02", DateTime.Now, Ban.Find("ban02", database), NhanVien.Find("nv02", database), thucUongs2), database);
        }
        public static void QLHDTN(Database database)
        {
            while (true)
            {
                Console.Clear();
                ConsoleView.Menu("0:Thoat", "1:them", "2:Thuc uong da dc trong hoa don");
                HoaDon.PrintTable(database);
                Console.Write("chon mode:");
                string i = Console.ReadLine();
                if (i == "0") break;
                if (i == "1")
                {
                    string id = NhapTaoID("HoaDon", database);
                    if (id == string.Empty) continue;
                    string idban = NhapXoaID("Ban", database);
                    if (idban == string.Empty) continue;
                    string idnv = NhapXoaID("NhanVien", database);
                    if (idnv == string.Empty) continue;
                    List<ThucUong> thucUongs = new List<ThucUong>();
                    string idTu = "";
                    while (true)
                    {
                        idTu = NhapXoaID("ThucUong", database);
                        if (idTu == string.Empty) continue;
                        if (idTu == "stop") break;
                        thucUongs.Add(ThucUong.Find(idTu, database));
                    }
                    HoaDon.Add(new HoaDon(id, DateTime.Now, Ban.Find(idban, database), NhanVien.Find(idnv, database), thucUongs), database);
                }
                if (i == "2")
                {
                    string id = NhapXoaID("HoaDon", database);
                    if (id == string.Empty) continue;
                    HoaDon hoaDon = HoaDon.Find(id, database);
                    hoaDon.ThucUongs.ForEach(t => Console.WriteLine("-matu:{0}  |ten:{1} |loai:{2}", t.ID, t.TenThucUong, t.LoaiThuocUong));
                    Console.Read();
                }
            }
        }

        public static void QLHD(Database database)
        {
            while (true)
            {
                Console.Clear();
                ConsoleView.Menu("0:Thoat", "1:xoa", "2:cac thuc uong da dc goi trong hd");
                HoaDon.PrintTable(database);
                Console.Write("chon mode:");
                string i = Console.ReadLine();
                if (i == "0") break;
                if (i == "1")
                {
                    string id = NhapXoaID("HoaDon", database);
                    if (id == string.Empty) continue;
                    HoaDon.Delete(id, database);
                }
                if (i == "2")
                {
                    string id = NhapXoaID("HoaDon", database);
                    if (id == string.Empty) continue;
                    HoaDon hoaDon = HoaDon.Find(id, database);
                    hoaDon.ThucUongs.ForEach(t => Console.WriteLine("-matu:{0}  |ten:{1} |loai:{2}", t.ID, t.TenThucUong, t.LoaiThuocUong));
                    Console.Read();
                }
            }
        }

        public static void QLNV(Database database)
        {
            while (true)
            {
                Console.Clear();
                ConsoleView.Menu("0:Thoat", "1:xoa", "2:them", "3:sua", "4:Ca lam");
                NhanVien.PrintTable(database.NhanViens);
                Console.Write("chon mode:");
                string i = Console.ReadLine();
                if (i == "0") break;
                if (i == "1")
                {
                    string id = NhapXoaID("NhanVien", database);
                    if (id == string.Empty) continue;
                    NhanVien.Delete(id, database);
                }
                if (i == "2")
                {
                    string ID = NhapTaoID("NhanVien", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap Ho Ten:");
                    string hoten = Console.ReadLine();
                    DateTime dateTime = new DateTime();
                    Console.Write("nhap ngay sinh:(nam/thang/ngay)");
                    try
                    {
                        dateTime = Convert.ToDateTime(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ngay Khong Hop Le");
                        Console.Read();
                        continue;
                    }
                    NhanVien.Add(new NhanVien(ID, hoten, dateTime), database);
                }
                if (i == "3")
                {
                    string ID = NhapXoaID("NhanVien", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap Ho Ten:");
                    string hoten = Console.ReadLine();
                    DateTime dateTime = new DateTime();
                    Console.Write("nhap ngay sinh:(nam/thang/ngay)");
                    dateTime = Convert.ToDateTime(Console.ReadLine());
                    NhanVien.Update(ID, new NhanVien(ID, hoten, dateTime), database);
                }
                if (i == "4")
                {
                    string ID = NhapXoaID("NhanVien", database);
                    if (ID == string.Empty) continue;
                    NhanVien nhanVien = NhanVien.Find(ID, database);
                    nhanVien.PhanCongs.ForEach(p => Console.WriteLine("ca lam: {0}   ban: {1}", p.Ca, p.Ban.MaBan));
                    Console.Read();
                }

            }
        }
        public static void QLPC(Database database)
        {
            while (true)
            {
                Console.Clear();
                ConsoleView.Menu("0:Thoat", "1:xoa", "2:them", "3:sua");
                PhanCong.PrintTable(database.PhanCongs);
                Console.Write("chon mode:");
                string i = Console.ReadLine();
                if (i == "0") break;
                if (i == "1")
                {
                    string idnv = NhapXoaID("NhanVien", database);
                    if (idnv == string.Empty) continue;
                    string idb = NhapXoaID("Ban", database);
                    if (idb == string.Empty) continue;
                    if (PhanCong.Find(idnv, idb, database) == null) continue;
                    PhanCong.Delete(idnv, idb, database);
                }
                if (i == "2")
                {

                    string ID = NhapXoaID("NhanVien", database);
                    if (ID == string.Empty) continue;
                    string idban = NhapXoaID("Ban", database);
                    if (idban == string.Empty) continue;
                    if(Ban.Find(idban,database).PhanCong.NhanVien != null)
                    {
                        Console.WriteLine("Ban Nay Da Co NV Phu Trach");
                        Console.Read();
                        continue;

                    }
                    if (PhanCong.Find(ID, idban, database) != null)
                    {
                        Console.WriteLine("Da Ton Tai Phan Cong Nay");
                        Console.Read();
                        continue;
                    }
                    
                    Console.Write("Nhap ca lam");
                    string ca = Console.ReadLine();
                    PhanCong.Add(new PhanCong(NhanVien.Find(ID, database), Ban.Find(idban, database), ca, DateTime.Now), database);
                }
                if (i == "3")
                {
                    string ID = NhapXoaID("NhanVien", database);
                    if (ID == string.Empty) continue;
                    string idban = NhapXoaID("Ban", database);
                    if (idban == string.Empty) continue;
                    if (PhanCong.Find(ID, idban, database) == null)
                    {
                        Console.WriteLine("Khong ton tai phan khong nay");
                        Console.Read();
                        continue;
                    }
                    Console.Write("nhap ca lam:");
                    string ca = Console.ReadLine();
                    PhanCong.Update(ID, idban, new PhanCong(NhanVien.Find(ID, database), Ban.Find(idban, database), ca, DateTime.Now), database);
                }

            }
        }
        public static void QLB(Database database)
        {
            while (true)
            {
                Console.Clear();
                ConsoleView.Menu("0:Thoat", "1:xoa", "2:them", "3:sua");
                Ban.PrintTable(database.Bans);
                Console.Write("chon mode:");
                string i = Console.ReadLine();
                if (i == "0") break;
                if (i == "1")
                {
                    string ID = NhapXoaID("Ban", database);
                    if (ID == string.Empty) continue;
                    Ban.Delete(Console.ReadLine(), database);
                }
                if (i == "2")
                {
                    string ID = NhapTaoID("Ban", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap so ghe:");
                    string idban = Console.ReadLine();
                    Ban.Add(new Ban(ID, Convert.ToInt32(idban), new PhanCong(), new List<HoaDon>()), database);
                }
                if (i == "3")
                {
                    string ID = NhapXoaID("Ban", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap so ghe:");
                    string idban = Console.ReadLine();
                    Ban.Update(ID, new Ban(ID, Convert.ToInt32(idban), new PhanCong(), new List<HoaDon>()), database);
                }

            }
        }
        public static void QLTU(Database database)
        {
            while (true)
            {
                Console.Clear();
                ConsoleView.Menu("0:Thoat", "1:xoa", "2:them", "3:sua", "4:hoa don goi");
                ThucUong.PrintTable(database.ThucUongs);
                Console.Write("chon mode:");
                string i = Console.ReadLine();
                if (i == "0") break;
                if (i == "1")
                {
                    string id = NhapXoaID("ThucUong", database);
                    if (id == string.Empty) continue;
                    ThucUong.Delete(Console.ReadLine(), database);
                }
                if (i == "2")
                {
                    string ID = NhapTaoID("ThucUong", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap ten:");
                    string ten = Console.ReadLine();
                    Console.Write("nhap loai thuc uong:");
                    string loai = Console.ReadLine();
                    Console.Write("nhap gia:");
                    string gia = Console.ReadLine();
                    Console.Write("nhap so luong trong kho:");
                    string soluong = Console.ReadLine();
                    ThucUong.Add(new ThucUong(ID, ten, loai, Convert.ToInt32(soluong), Convert.ToInt32(gia)), database);
                }
                if (i == "3")
                {
                    string ID = NhapXoaID("ThucUong", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap ten:");
                    string ten = Console.ReadLine();
                    Console.Write("nhap loai thuc uong:");
                    string loai = Console.ReadLine();
                    Console.Write("nhap gia:");
                    string gia = Console.ReadLine();
                    Console.Write("nhap so luong trong kho:");
                    string soluong = Console.ReadLine();
                    ThucUong.Add(new ThucUong(ID, ten, loai, Convert.ToInt32(soluong), Convert.ToInt32(gia)), database);
                }
                if (i == "4")
                {
                    string ID = NhapXoaID("ThucUong", database);
                    if (ID == string.Empty) continue;
                    ThucUong thucUong = ThucUong.Find(Console.ReadLine(), database);
                    thucUong.HoaDons.ForEach(h => Console.WriteLine("- MaHD:{0,-10}  Ngay:{1,-30}", h.ID, h.NgayLap));
                    Console.Read();
                }

            }

        }
        public static void QLTN(Database database)
        {
            while (true)
            {
                Console.Clear();
                ConsoleView.Menu("0:Thoat", "1:xoa", "2:them", "3:sua");
                ThuNgan.PrintTable(database.ThuNgans);
                Console.Write("chon mode:");
                string i = Console.ReadLine();
                if (i == "0") break;
                if (i == "1")
                {
                    string ID = NhapXoaID("ThuNgan", database);
                    if (ID == string.Empty) continue;
                    ThuNgan.Delete(Console.ReadLine(), database);
                }
                if (i == "2")
                {
                    string ID = NhapXoaID("ThuNgan", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap Ho Ten:");
                    string hoten = Console.ReadLine();
                    Console.Write("nhap MK:");
                    string mk = Console.ReadLine();
                    Console.Write("nhap ngay sinh:(nam/thang/ngay)");
                    DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                    ThuNgan.Add(new ThuNgan(ID, hoten, dateTime, mk), database);
                }
                if (i == "3")
                {
                    string ID = NhapXoaID("ThuNgan", database);
                    if (ID == string.Empty) continue;
                    Console.Write("nhap Ho Ten:");
                    string hoten = Console.ReadLine();
                    Console.Write("nhap MK:");
                    string mk = Console.ReadLine();
                    Console.Write("nhap ngay sinh:(nam/thang/ngay)");
                    DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                    ThuNgan.Update(ID, new ThuNgan(ID, hoten, dateTime, mk), database);
                }
            }
        }

        public static string DangNhap(Database database)
        {
            Console.Clear();
            string cv;
            string ID;
            string MK;
            int sls = 0;
            while (true)
            {
                Console.Write("Ban la (ql hay tn|nhap -1 de tac phan men):");
                cv = Console.ReadLine();
                if (cv == "-1") return cv;
                if (cv == "ql" || cv == "tn") break;
                else
                {
                    Console.WriteLine("Khong hop le");
                }
            }
            if (cv == "ql")
            {
                while (true)
                {
                    Console.Write("ID:");
                    ID = Console.ReadLine();
                    if (QuanLy.Find(ID, database) == null)
                    {
                        Console.WriteLine("ID khong ton tai");
                        if (++sls == 3)
                            return null;
                    }
                    else break;
                }
                while (true)
                {
                    Console.Write("Mat Khau:");
                    MK = Console.ReadLine();
                    QuanLy quanLy = QuanLy.Find(ID, database);
                    if (QuanLy.Find(ID, database).MatKhau != MK)
                    {
                        Console.WriteLine("Sai Mat Khau");
                        if (++sls == 3)
                            return null;
                    }
                    else break;
                }
                return cv;
            }
            while (true)
            {
                Console.Write("ID:");
                ID = Console.ReadLine();
                if (ThuNgan.Find(ID, database) == null)
                {
                    Console.WriteLine("ID khong ton tai");
                    if (++sls == 3)
                        return null;
                }
                else break;
            }
            while (true)
            {
                Console.Write("Mat Khau:");
                MK = Console.ReadLine();
                if (ThuNgan.Find(ID, database).MatKhau != MK)
                {
                    Console.WriteLine("Sai Mat Khau");
                    if (++sls == 3)
                        return null;
                }
                else break;
            }
            return cv;
        }
    }
}
