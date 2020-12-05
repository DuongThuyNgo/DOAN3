using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiaoVien
    {
        public int magiaovien;
        public string tengiaovien;
        public DateTime ngaysinh;
        public string gioitinh;
        public string quequan;
        public string sodienthoai;
        public string socmnd;

        public GiaoVien()
        {
        }
        public GiaoVien(GiaoVien gv)
        {
            this.magiaovien = gv.magiaovien;
            this.tengiaovien = gv.tengiaovien;
            this.ngaysinh = gv.ngaysinh;
            this.gioitinh = gv.gioitinh;
            this.quequan = gv.quequan;
            this.sodienthoai = gv.sodienthoai;
            this.socmnd = gv.socmnd;
        }
        public GiaoVien(int magiaovien, string tengiaovien, DateTime ngaysinh, string gioitinh, string quequan, string sodienthoai, string socmnd)
        {
            this.magiaovien = magiaovien;
            this.tengiaovien = tengiaovien;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.quequan = quequan;
            this.sodienthoai = sodienthoai;
            this.socmnd = socmnd;

        }
        public GiaoVien(string tengiaovien, DateTime ngaysinh, string gioitinh, string quequan, string sodienthoai, string socmnd)
        {
            this.tengiaovien = tengiaovien;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.quequan = quequan;
            this.sodienthoai = sodienthoai;
            this.socmnd = socmnd;
        }
        public int Magiaovien { get; set; }
        public string Tengiaovien { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Quequan { get; set; }
        public string Tenkhoihoc { get; set; }
        public string Sodienthoai { get; set; }
        public string Socmnd { get; set; }
    }
}
