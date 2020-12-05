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
    public class LoaiDiemBLL: ILoaiDiemBLL
    {
        private readonly LoaiDiemDAO dal = new LoaiDiemDAO();

        public int Insert(LoaiDiem h)
        {
            //if (checkmaLoaiDiem_ID(h.Maloaidiem) == 0)
            //{

                h.Tenloaidiem = Tools.ChuanHoaXau(h.Tenloaidiem);
                return dal.Insert(h);
            //}
            //else return -1;

        }


        public int Delete(int mamonhoc)
        {
            if (checkmaLoaiDiem_ID(mamonhoc) != 0)
                return dal.Delete(mamonhoc);
            else return -1;
        }


        public int Update(LoaiDiem h)
        {
            //if (checkmaLoaiDiem_ID(h.Maloaidiem) != 0)
            //{
                h.Tenloaidiem = Tools.ChuanHoaXau(h.Tenloaidiem);
                return dal.Insert(h);
            //}
            //else return -1;
        }


        public IList<LoaiDiem> getAll()
        {
            return dal.getAll();
        }




        public LoaiDiem getmaLoaiDiem(int mald)
        {
            return dal.getmaLoaiDiem(mald);
        }




        public int checkmaLoaiDiem_ID(int mald)
        {
            return dal.checkmaLoaiDiem_ID(mald);
        }
    }
}
