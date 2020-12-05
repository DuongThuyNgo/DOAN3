using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonHoc
    {
        public int mamonhoc;
        public string tenmonhoc;
        public int sotiet;

        public MonHoc()
        {
        }
        public MonHoc(MonHoc mh)
        {
            this.mamonhoc = mh.mamonhoc;
            this.tenmonhoc = mh.tenmonhoc;
            this.sotiet = mh.sotiet;

        }
        public MonHoc(int mamonhoc, string tenmonhoc, int sotiet)
        {
            this.mamonhoc = mamonhoc;
            this.tenmonhoc = tenmonhoc;
            this.sotiet = sotiet;
        }
        public MonHoc(string tenmonhoc, int sotiet)
        {
            this.tenmonhoc = tenmonhoc;
            this.sotiet = sotiet;
        }
        public int Mamonhoc { get { return mamonhoc; } set { mamonhoc = value; } }
        public string Tenmonhoc { get { return tenmonhoc; } set { tenmonhoc = value; } }
        public int Sotiet { get { return sotiet; } set { sotiet = value; } }
    }
}
