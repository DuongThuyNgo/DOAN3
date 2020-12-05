using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiDiem
    {
        public int maloaidiem;
        public string tenloaidiem;
        public int heso;
        public LoaiDiem()
        {
        }
        public LoaiDiem(LoaiDiem ld)
        {
            this.maloaidiem = ld.maloaidiem;
            this.tenloaidiem = ld.tenloaidiem;
            this.heso = ld.heso;

        }
        public LoaiDiem(int maloaidiem, string tenloaidiem, int heso)
        {
            this.maloaidiem = maloaidiem;
            this.tenloaidiem = tenloaidiem;
            this.heso = heso;
        }
        public LoaiDiem(string tenloaidiem, int heso)
        {
            this.tenloaidiem = tenloaidiem;
            this.heso = heso;
        }
        public int Maloaidiem { get { return maloaidiem; } set { maloaidiem = value; } }
        public string Tenloaidiem { get { return tenloaidiem; } set { tenloaidiem = value; } }
        public int Heso { get { return heso; } set { heso = value; } }
    }
}
