using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.ServiceInterface
{
    public interface IKhoiHocBLL
    {
        int Insert(KhoiHoc k);
        int Delete(int makhoihoc);
        int Update(KhoiHoc k);
        IList<KhoiHoc> getAll();
        KhoiHoc getmaKhoiHoc_ID(int mahocsinh);
        int checkmaKhoiHoc_ID(int mahocsinh);
      
    }
}
