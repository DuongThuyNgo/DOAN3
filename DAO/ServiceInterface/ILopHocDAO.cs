using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ServiceInterface
{
    public interface ILopHocDAO
    {
        int Insert(LopHoc l);
        int Delete(int malop);
        int Update(LopHoc l);
        IList<LopHoc> getAll();
        IList<LopHoc> getAll(int PageNo, int PageSize, int Makhoihoc, int Siso, out int RecordCount);
        LopHoc getmaLopHoc(int malop);
        int getmaLopHoc_Last();
        int checkmaLopHoc_ID(int malop);
    }
}
