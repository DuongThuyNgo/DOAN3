using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ServiceInterface
{
    public interface IMonHocDAO
    {
        int Insert(MonHoc mh);
        int Delete(int mamonhoc);
        int Update(MonHoc mh);
        IList<MonHoc> getAll();
        IList<MonHoc> getAll(int Mamonhoc, string Tenmonhoc, int Sotiet, out int RecordCount);
        MonHoc getmaMonHoc(int mamonhoc);
        int getmaMonHoc_Last();
        int checkmaMonHoc_ID(int mamonhoc);
    }
}
