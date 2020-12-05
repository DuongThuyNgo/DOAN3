using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHoc
    {
        public int malop;
        public string tenlop;
        public int makhoihoc;
        public int magiaovien;
        public int siso;
        public LopHoc()
        {
        }
        public LopHoc(LopHoc lh)
        {
            this.malop = lh.malop;
            this.tenlop = lh.tenlop;
            this.makhoihoc = lh.makhoihoc;
            this.magiaovien = lh.magiaovien;
            this.siso = lh.siso;
        }
        public LopHoc(int malop, string tenlop, int makhoihoc, int magiaovien, int siso)
        {
            this.malop = malop;
            this.tenlop = tenlop;
            this.makhoihoc = makhoihoc;
            this.magiaovien = magiaovien;
            this.siso = siso;
        }
        public LopHoc(string tenlop, int makhoihoc, int magiaovien, int siso)
        {
            this.tenlop = tenlop;
            this.makhoihoc = makhoihoc;
            this.magiaovien = magiaovien;
            this.siso = siso;
        }

        public int Malop { get { return malop; } set { malop = value; } }
        public string Tenlop { get { return tenlop; } set { tenlop = value; } }
        public int Makhoihoc { get { return makhoihoc; } set { makhoihoc = value; } }
        public int Magiaovien { get { return magiaovien; } set { magiaovien = value; } }
        public int Siso { get { return siso; } set { siso = value; } }
    }
}
