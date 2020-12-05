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
    public class DiẹmBLL : IDiemBLL
    {
        private readonly DiemDAO dal = new DiemDAO();

        public int Insert(Diem hs)
        {
            //if (checkmaGiaoVien_ID(hs.Madiem) == 0)
            //{

                hs.Namhoc = Tools.ChuanHoaXau(hs.Namhoc);
                hs.Hanhkiem = Tools.ChuanHoaXau(hs.Hanhkiem);
                hs.Hocluc = Tools.ChuanHoaXau(hs.Hocluc);
                hs.Danhhieu = Tools.ChuanHoaXau(hs.Danhhieu);
            return dal.Insert(hs);
            //}
            //else return -1;

        }
        public int Delete(int madiem)
        {
            //if (checkmaGiaoVien_ID(mahocsinh) != 0)
                return dal.Delete(madiem);
            //else return -1;
        }
        public int Update(Diem hs)
        {
            //if (checkmaGiaoVien_ID(hs.Magiaovien) != 0)
            //{
            hs.Namhoc = Tools.ChuanHoaXau(hs.Namhoc);
            hs.Hanhkiem = Tools.ChuanHoaXau(hs.Hanhkiem);
            hs.Hocluc = Tools.ChuanHoaXau(hs.Hocluc);
            hs.Danhhieu = Tools.ChuanHoaXau(hs.Danhhieu);
            return dal.Update(hs);
            //}
            //else return -1;
        }
        public IList<Diem> getAll()
        {
            return dal.getAll();
        }
        public Diem getmaDiem(int madiem)
        {
            return dal.getmaDiem(madiem);
        }
     
        public int checkmaDiem_ID(int madiem)
        {
            return dal.checkmaDiem_ID(madiem);
        }
    }
}


