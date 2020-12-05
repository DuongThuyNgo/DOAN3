using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.ServiceInterface
{
    public interface IHocSinhDAO
    {
        int Insert(HocSinh hs);
        int Delete(int mahocsinh);
        int Update(HocSinh hs);
        IList<HocSinh> getAll();
       // IList<HocSinh> getAll(int PageNo, int PageSize,string Tenhocsinh, string Quequan, out int RecordCount);
        HocSinh getmaHocSinh(int mahocsinh);
        int getmaHocSinh_Last();
        int checkmaHocSinh_ID(int mahocsinh);
    }
}
