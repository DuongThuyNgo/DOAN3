using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.ServiceInterface
{
    public interface IDiemDAO
    {
        int Insert(Diem d);
        int Delete(int mabangdiem);
        int Update(Diem d);
        IList<Diem> getAll();
        IList<Diem> getAll(int PageNo, int PageSize, int Malop, int Kihoc, string Namhoc, out int RecordCount);
        Diem getmaDiem(int mabangdiem);
        int getmaDiem_Last();
        int checkmaDiem_ID(int mabangdiem);
    }
}
