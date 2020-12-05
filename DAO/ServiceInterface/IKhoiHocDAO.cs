using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.ServiceInterface
{
    public interface IKhoiHocDAO
    {
        int Insert(KhoiHoc kh);
        int Delete(int makhoihoc);
        int Update(KhoiHoc kh);
        IList<KhoiHoc> getAll();
        KhoiHoc getmaKhoiHoc(int makhoihoc);
       
        int checkmaKhoiHoc_ID(int makhoihoc);
    }
}
