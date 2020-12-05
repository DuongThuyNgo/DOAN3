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
     public class MonHocBLL: IMonHocBLL
    {
        private readonly MonHocDAO dal = new MonHocDAO();

        public int Insert(MonHoc h)
        {
            if (checkmaMonHoc_ID(h.Mamonhoc) == 0)
            {

                h.Tenmonhoc = Tools.ChuanHoaXau(h.Tenmonhoc);
                return dal.Insert(h);
            }
            else return -1;

        }


        public int Delete(int mamonhoc)
        {
            if (checkmaMonHoc_ID(mamonhoc) != 0)
                return dal.Delete(mamonhoc);
            else return -1;
        }


        public int Update(MonHoc h)
        {
            if (checkmaMonHoc_ID(h.Mamonhoc) != 0)
            {
                h.Tenmonhoc = Tools.ChuanHoaXau(h.Tenmonhoc);
                return dal.Update(h);
            }
            else return -1;
        }


        public IList<MonHoc> getAll()
        {
            return dal.getAll();
        }




        public MonHoc getmaMonHoc(int mamonhoc)
        {
            return dal.getmaMonHoc(mamonhoc);
        }




        public int checkmaMonHoc_ID(int mamonhoc)
        {
            return dal.checkmaMonHoc_ID(mamonhoc);
        }
    }
}
