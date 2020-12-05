using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Diem
    {
        public int mabangdiem;
        public int mahocsinh;
        public int malop;
        public int kihoc;
        public string namhoc;
        public float diemtb;
        public string hanhkiem;
        public string hocluc;
        public string danhhieu;
        public int magiaovien;
        public Diem()
        {
        }
        public Diem(Diem d)
        {
            this.mabangdiem = d.mabangdiem;
            this.mahocsinh = d.mahocsinh;
            this.malop = d.malop;
            this.kihoc = d.kihoc;
            this.namhoc = d.namhoc;
            this.diemtb = d.diemtb;
            this.hanhkiem = d.hanhkiem;
            this.hocluc = d.hocluc;
            this.danhhieu = d.danhhieu;
            this.magiaovien = d.magiaovien;
        }
        public Diem(int mabangdiem, int mahocsinh, int malop, int kihoc, string namhoc, float diemtb, string hanhkiem, string hocluc, string danhhieu, int magiaovien)
        {
            this.mabangdiem = mabangdiem;
            this.mahocsinh = mahocsinh;
            this.malop = malop;
            this.kihoc = kihoc;
            this.namhoc = namhoc;
            this.diemtb = diemtb;
            this.hanhkiem = hanhkiem;
            this.hocluc = hocluc;
            this.danhhieu = danhhieu;
            this.magiaovien = magiaovien;

        }
        public Diem(int mahocsinh, int malop, int kihoc, string namhoc, float diemtb, string hanhkiem, string hocluc, string danhhieu, int magiaovien)
        {
            this.mahocsinh = mahocsinh;
            this.malop = malop;
            this.kihoc = kihoc;
            this.namhoc = namhoc;
            this.diemtb = diemtb;
            this.hanhkiem = hanhkiem;
            this.hocluc = hocluc;
            this.danhhieu = danhhieu;
            this.magiaovien = magiaovien;

        }

        public int Mabangdiem { get; set; }
        public int Mahocsinh { get; set; }
        public int Malop { get; set; }
        public int Kihoc { get; set; }
        public string Namhoc { get; set; }
        public float Diemtb { get; set; }
        public string Hanhkiem { get; set; }
        public string Hocluc { get; set; }
        public string Danhhieu { get; set; }
        public int Magiaovien { get; set; }
    }
}
