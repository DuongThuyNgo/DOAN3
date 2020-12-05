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
    public class CTDiẹmBLL : ICTDiemBLL
    {
        private readonly CTDiemDAO dal = new CTDiemDAO();

        public int Insert(CTDiem hs)
        {
            //if (checkmaGiaoVien_ID(hs.Madiem) == 0)
            //{


            return dal.Insert(hs);
            //}
            //else return -1;

        }
        public int Delete(int maCTdiem)
        {
            //if (checkmaGiaoVien_ID(mahocsinh) != 0)
            return dal.Delete(maCTdiem);
            //else return -1;
        }
        public int Update(CTDiem hs)
        {
            //if (checkmaGiaoVien_ID(hs.Magiaovien) != 0)
            //{

            return dal.Update(hs);
            //}
            //else return -1;
        }
        public IList<CTDiem> getAll()
        {
            return dal.getAll();
        }

    }
}


