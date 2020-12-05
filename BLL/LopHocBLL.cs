using BLL.ServiceInterface;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BLL
{
    public class LopHocBLL : ILopHocBLL
    {
        private readonly LopHocDAO dal = new LopHocDAO();

        public int Insert(LopHoc hs)
        {
            if (checkmaLopHoc_ID(hs.Malop) == 0)
            {

                hs.Tenlop = Tools.ChuanHoaXau(hs.Tenlop);
                
                return dal.Insert(hs);
            }
            else return -1;

        }


        public int Delete(int malop)
        {
            if (checkmaLopHoc_ID(malop) != 0)
                return dal.Delete(malop);
            else return -1;
        }


        public int Update(LopHoc hs)
        {
            if (checkmaLopHoc_ID(hs.Malop) != 0)
            {
                hs.Tenlop = Tools.ChuanHoaXau(hs.Tenlop);
                
                return dal.Update(hs);
            }
            else return -1;
        }


        public IList<LopHoc> getAll()
        {
            return dal.getAll();
        }

        public IList<LopHoc> getAll(int PageNo, int PageSize, int Makhoihoc, int Siso, out int RecordCount)
        {
            return dal.getAll(PageNo, PageSize, Makhoihoc,Siso, out RecordCount);
        }


        public LopHoc getmaLopHoc_ID(int malop)
        {
            return dal.getmaLopHoc(malop);
        }

        public int getmaLopHoc_Last()
        {
            if (dal.getAll().Count == 0)
                return 0;
            else return dal.getmaLopHoc_Last();
        }


        public int checkmaLopHoc_ID(int malop)
        {
            return dal.checkmaLopHoc_ID(malop);
        }

        public IList<LopHoc> Search(LopHoc hs)
        {
            IList<LopHoc> list = getAll();
            IList<LopHoc> kq = new List<LopHoc>();
            //Voi gai tri ngam dinh ban dau
            if (hs.Makhoihoc == 0 && hs.Siso == 0 && hs.Siso == ' ' && hs.Makhoihoc == ' ')
            {
                kq = list;
            }
            
            if (hs.Makhoihoc != 0 && hs.Siso == 0 && hs.Siso == ' ' && hs.Makhoihoc != ' ')
            {
                foreach (LopHoc hsi in list)
                    if (hsi.Malop > 0)
                    {
                        kq.Add(new LopHoc(hsi));
                    }
            }
            // Tim theo ten học sinh
            else if (hs.Makhoihoc == 0 && hs.Siso != 0 && hs.Siso != ' ' && hs.Makhoihoc == ' ')
            {
                foreach (LopHoc hsi in list)
                    if (hsi.Siso > 0)
                    {
                        kq.Add(new LopHoc(hsi));
                    }
            }

            else if (hs.Makhoihoc != 0 && hs.Siso != 0 && hs.Siso != ' ' && hs.Makhoihoc != ' ')
            {
                foreach (LopHoc hsi in list)
                    if (hsi.Siso > 0 && hsi.Makhoihoc > 0)
                    {
                        kq.Add(new LopHoc(hsi));
                    }
            }
            
            else kq = null;
            return kq;
        }


    }
}
