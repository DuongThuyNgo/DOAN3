using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoiHoc
    {
        public int makhoihoc;
        public string tenkhoihoc;
        public KhoiHoc()
        {
        }
        public KhoiHoc(KhoiHoc kh)
        {
            this.makhoihoc = kh.makhoihoc;
            this.tenkhoihoc = kh.tenkhoihoc;

        }
        public KhoiHoc(int makhoihoc, string tenkhoihoc)
        {
            this.makhoihoc = makhoihoc;
            this.tenkhoihoc = tenkhoihoc;

        }
        
        public int Makhoihoc { get { return makhoihoc; } set { makhoihoc = value; } }
        public string Tenkhoihoc { get { return tenkhoihoc; } set { tenkhoihoc = value; } }
    }
}
