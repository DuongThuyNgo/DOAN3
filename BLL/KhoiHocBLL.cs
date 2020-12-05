
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
    public class KhoiHocBLL : IKhoiHocBLL
    {
        private readonly KhoiHocDAO dal = new KhoiHocDAO();

        public int Insert(KhoiHoc k)
        {
            //if (checkmaKhoiHoc_ID(k.Makhoihoc) == 0)
            //{

            k.Tenkhoihoc = Tools.ChuanHoaXau(k.Tenkhoihoc);
            return dal.Insert(k);
            //}
            //else return -1;

        }


        public int Delete(int makhoihoc)
        {
            ///if (checkmaKhoiHoc_ID(makhoihoc) != 0)
                return dal.Delete(makhoihoc);
            //else return -1;
        }


        public int Update(KhoiHoc k)
        {
            //if (checkmaKhoiHoc_ID(k.Makhoihoc) != 0)
            //{
            k.Tenkhoihoc = Tools.ChuanHoaXau(k.Tenkhoihoc);
            return dal.Update(k);
            //}
            //else return -1;
        }


        public IList<KhoiHoc> getAll()
        {
            return dal.getAll();
        }

       


        public KhoiHoc getmaKhoiHoc_ID(int makhoihoc)
        {
            return dal.getmaKhoiHoc(makhoihoc);
        }

        


        public int checkmaKhoiHoc_ID(int makhoihoc)
        {
            return dal.checkmaKhoiHoc_ID(makhoihoc);
        }

        
    }
}
