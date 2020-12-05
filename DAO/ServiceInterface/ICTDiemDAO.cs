using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.ServiceInterface
{
    public interface ICTDiemDAO
    {
        int Insert(CTDiem ctd);
        int Delete(int mactdiem);
        int Update(CTDiem ctd);
        IList<CTDiem> getAll();
        
    }
}
