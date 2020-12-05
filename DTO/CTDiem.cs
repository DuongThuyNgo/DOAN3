using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTDiem
    {
        public int mactdiem;
        public int mabangdiem;
        public int mahocsinh;
        public int mamonhoc;
        public int maloaidiem;
        public int diem;
        public float diemtbmon;
        public int magiaovien;
        public CTDiem()
        {
        }
        public CTDiem(CTDiem d)
        {
            this.mactdiem = d.mactdiem;
            this.mabangdiem = d.mabangdiem;
            this.mahocsinh = d.mahocsinh;
            this.mamonhoc = d.mamonhoc;
            this.maloaidiem = d.maloaidiem;
            this.diem = d.diem;
            this.diemtbmon = d.diemtbmon;
            this.magiaovien = d.magiaovien;
        }
        public CTDiem(int mactdiem, int mabangdiem, int mahocsinh, int mamonhoc, int maloaidiem, int diem, float diemtbmon, int magiaovien)
        {
            this.mactdiem = mactdiem;
            this.mabangdiem = mabangdiem;
            this.mahocsinh = mahocsinh;
            this.mamonhoc = mamonhoc;
            this.maloaidiem = maloaidiem;
            this.diem = diem;
            this.diemtbmon = diemtbmon;
            this.magiaovien = magiaovien;

        }
        public CTDiem(int mabangdiem, int mahocsinh, int mamonhoc, int maloaidiem, int diem, float diemtbmon, int magiaovien)
        {
            this.mabangdiem = mabangdiem;
            this.mahocsinh = mahocsinh;
            this.mamonhoc = mamonhoc;
            this.maloaidiem = maloaidiem;
            this.diem = diem;
            this.diemtbmon = diemtbmon;
            this.magiaovien = magiaovien;


        }
        public int Mactdiem { get; set; }
        public int Mabangdiem { get; set; }
        public int Mahocsinh { get; set; }
        public int Mamonhoc { get; set; }
        public int Maloaidiem { get; set; }
        public int Diem { get; set; }
        public float Diemtbmon { get; set; }
        public int Magiaovien { get; set; }
    }
}
