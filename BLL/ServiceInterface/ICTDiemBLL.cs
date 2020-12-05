using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterface
{
   public interface ICTDiemBLL
    {
        int Insert(CTDiem hs);
        int Delete(int madiem);
        int Update(CTDiem hs);
        IList<CTDiem> getAll();
       
    }
}
