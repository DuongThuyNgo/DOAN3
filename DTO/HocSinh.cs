using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinh
    {
        public int mahocsinh;
        public int malop;
        public string tenhocsinh;
        public DateTime ngaysinh;
        public string gioitinh;
        public string quequan;
        public string sodienthoai;
        public string socmnd;

        public HocSinh()
        {
        }
        public HocSinh(HocSinh hs)
        {
            this.mahocsinh = hs.mahocsinh;
            this.malop = hs.malop;
            this.tenhocsinh = hs.tenhocsinh;
            this.ngaysinh = hs.ngaysinh;
            this.gioitinh = hs.gioitinh;
            this.quequan = hs.quequan;
            this.sodienthoai = hs.sodienthoai;
            this.socmnd = hs.socmnd;
        }
        public HocSinh(int mahocsinh, int malop, string tenhocsinh, DateTime ngaysinh, string gioitinh, string quequan, string sodienthoai, string socmnd)
        {
            this.mahocsinh = mahocsinh;
            this.malop = malop;
            this.tenhocsinh = tenhocsinh;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.quequan = quequan;
            this.sodienthoai = sodienthoai;
            this.socmnd = socmnd;

        }
        public HocSinh(int malop, string tenhocsinh, DateTime ngaysinh, string gioitinh, string quequan, string sodienthoai, string socmnd)
        {
            this.malop = malop;
            this.tenhocsinh = tenhocsinh;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.quequan = quequan;
            this.sodienthoai = sodienthoai;
            this.socmnd = socmnd;
        }
        public int Mahocsinh { get { return mahocsinh; } set { mahocsinh = value; } }
        public int Malop { get { return malop; } set { malop = value; } }
        public string Tenhocsinh { get { return tenhocsinh; } set { tenhocsinh = value; } }
        public DateTime Ngaysinh { get { return ngaysinh; } set { ngaysinh = value; } }
        public string Gioitinh { get { return gioitinh; } set { gioitinh = value; } }
        public string Quequan { get { return quequan; } set { quequan = value; } }
        public string Tenkhoihoc { get { return quequan; } set { quequan = value; } }
        public string Sodienthoai { get { return sodienthoai; } set { sodienthoai = value; } }
        public string Socmnd { get { return socmnd; } set { socmnd = value; } }
    }
}
