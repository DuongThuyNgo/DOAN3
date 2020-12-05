using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL.ServiceInterface
{
    public interface IDiemBLL
    {
        int Insert(Diem hs);
        int Delete(int madiem);
        int Update(Diem hs);
        IList<Diem> getAll();
        Diem getmaDiem(int madiem);
     
       
    }
}
