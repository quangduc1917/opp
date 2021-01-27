using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    abstract class ConNguoi
    {
        protected string ID { get; set; }
        protected string HoTen { get; set; }
        protected DateTime NgaySinh { get; set; }
        protected ConNguoi(string iD, string hoTen,DateTime ngaySinh)
        {
            ID = iD;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }
        public abstract void Copy(object ojb);
        public virtual String ThongTin()
        {
            return String.Format("|{0,-10}|{1,-20}|{2,-2}/{3,-2}/{4,-6}|", ID, HoTen, NgaySinh.Day.ToString(),NgaySinh.Month.ToString(),NgaySinh.Year.ToString());
        }
        public virtual string GetHoTen()
        {
            return HoTen;
        }
        public virtual string GetID()
        {
            return ID;
        }
        public virtual DateTime GetNgaySinh()
        {
            return NgaySinh;
        }
    }
}
