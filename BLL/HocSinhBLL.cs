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
    public class HocSinhBLL : IHocSinhBLL
    {
        private readonly HocSinhDAO dal = new HocSinhDAO();

        public int Insert(HocSinh hs)
        {
            //if (checkmaHocSinh_ID(hs.Mahocsinh) == 0)
            //{
               
                hs.Tenhocsinh = Tools.ChuanHoaXau(hs.Tenhocsinh);
                hs.Quequan = Tools.ChuanHoaXau(hs.Quequan);
                //hs.Gioitinh = Tools.ChuanHoaXau(hs.Gioitinh);
                return dal.Insert(hs);
            //}
            //else return -1;

        }


        public int Delete(int mahocsinh)
        {
            if (checkmaHocSinh_ID(mahocsinh) != 0)
                return dal.Delete(mahocsinh);
            else return -1;
        }


        public int Update(HocSinh hs)
        {
            //if (checkmaHocSinh_ID(hs.Mahocsinh) != 0)
            //{
                hs.Tenhocsinh = Tools.ChuanHoaXau(hs.Tenhocsinh);
                hs.Quequan = Tools.ChuanHoaXau(hs.Quequan);
                return dal.Update(hs);
            //}
            //else return -1;
        }


        public IList<HocSinh> getAll()
        {
            return dal.getAll();
        }

        //public IList<HocSinh> getAll(int PageNo, int PageSize, string Tenhocsinh, string Quequan, out int RecordCount)
        //{
        //    return dal.getAll(PageNo, PageSize, Tenhocsinh, Quequan, out RecordCount);
        //}


        public HocSinh getmaHocSinh_ID(int mahocsinh)
        {
            return dal.getmaHocSinh(mahocsinh);
        }

        public int getmaHocSinh_Last()
        {
            if (dal.getAll().Count == 0)
                return 0;
            else return dal.getmaHocSinh_Last();
        }


        public int checkmaHocSinh_ID(int mahocsinh)
        {
            return dal.checkmaHocSinh_ID(mahocsinh);
        }

        public IList<HocSinh> Search(HocSinh hs)
        {
            IList<HocSinh> list = getAll();
            IList<HocSinh> kq = new List<HocSinh>();
            //Voi gai tri ngam dinh ban dau
            if (hs.Malop == 0 && hs.Tenhocsinh == null && hs.Quequan == null)
            {
                kq = list;
            }
            //Tim theo mã lớp
            if (hs.Malop != 0 && hs.Tenhocsinh == null && hs.Quequan == null)
            {
                foreach (HocSinh hsi in list)
                    if (hsi.Malop > 0)
                    {
                        kq.Add(new HocSinh(hsi));
                    }
            }
            // Tim theo ten học sinh
            else if (hs.Malop == 0 && hs.Tenhocsinh != null && hs.Quequan == null)
            {
                foreach (HocSinh hsi in list)
                    if (hsi.Tenhocsinh.IndexOf(hs.Tenhocsinh) >= 0)
                    {
                        kq.Add(new HocSinh(hsi));
                    }
            }
            //Tim theo quê quán
            else if (hs.Malop == 0 && hs.Tenhocsinh == null && hs.Quequan != null)
            {
                foreach (HocSinh hsi in list)
                    if (hsi.Quequan.IndexOf(hs.Quequan) >= 0)
                    {
                        kq.Add(new HocSinh(hsi));
                    }
            }
            //Tim ket hop giua ten lop va ten giao vien,ten lop truong
            else if (hs.Malop == 0 && hs.Tenhocsinh == null && hs.Quequan != null)
            {
                foreach (HocSinh hsi in list)
                    if (hsi.Quequan.IndexOf(hs.Quequan) >= 0 && hsi.Quequan.IndexOf(hs.Quequan) >= 0 && hsi.Malop > 0)
                    {
                        kq.Add(new HocSinh(hsi));
                    }
            }
            //Cac truong hop khac cac ban tu lam
            else kq = null;
            return kq;
        }


    }
}
