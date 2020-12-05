using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.ServiceInterface
{
    public interface IMonHocBLL
    {
        int Insert(MonHoc k);
        int Delete(int mamonhoc);
        int Update(MonHoc k);
        IList<MonHoc> getAll();
        MonHoc getmaMonHoc(int mamonhoc);
        int checkmaMonHoc_ID(int mamonhoc);
    }
}
