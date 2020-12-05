using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BLL.ServiceInterface
{
    public interface ILopHocBLL
    {
        int Insert(LopHoc hs);
        int Delete(int mahocsinh);
        int Update(LopHoc hs);
        IList<LopHoc> getAll();
        IList<LopHoc> getAll(int PageNo, int PageSize, int Makhoihoc, int Siso, out int RecordCount);
        LopHoc getmaLopHoc_ID(int malop);
        int getmaLopHoc_Last();
        int checkmaLopHoc_ID(int malop);
        IList<LopHoc> Search(LopHoc hs);

    }
}
