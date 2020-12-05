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
    public class GiaoVienBLL:IGiaoVienBLL
    {
        private readonly GiaoVienDAO dal = new GiaoVienDAO();

        public int Insert(GiaoVien hs)
        {
            if (checkmaGiaoVien_ID(hs.Magiaovien) == 0)
            {

                hs.Tengiaovien = Tools.ChuanHoaXau(hs.Tengiaovien);
                hs.Quequan = Tools.ChuanHoaXau(hs.Quequan);
                return dal.Insert(hs);
            }
            else return -1;

        }
        public int Delete(int mahocsinh)
        {
            if (checkmaGiaoVien_ID(mahocsinh) != 0)
                return dal.Delete(mahocsinh);
            else return -1;
        }
        public int Update(GiaoVien hs)
        {
            if (checkmaGiaoVien_ID(hs.Magiaovien) != 0)
            {
                hs.Tengiaovien = Tools.ChuanHoaXau(hs.Tengiaovien);
                hs.Quequan = Tools.ChuanHoaXau(hs.Quequan);
                return dal.Update(hs);
            }
            else return -1;
        }
        public IList<GiaoVien> getAll()
        {
            return dal.getAll();
        }
        public GiaoVien getmaGiaoVien(int magv)
        {
            return dal.getmaGiaoVien(magv);
        }
        public int getmaGiaoVien_Last()
        {
            if (dal.getAll().Count == 0)
                return 0;
            else return dal.getmaGiaoVien_Last();
        }
        public int checkmaGiaoVien_ID(int mahocsinh)
        {
            return dal.checkmaGiaoVien_ID(mahocsinh);
        }
    }
}


