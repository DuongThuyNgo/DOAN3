using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.ServiceInterface
{
    public interface ILoaiDiemBLL
    {
        int Insert(LoaiDiem k);
        int Delete(int maloaidiem);
        int Update(LoaiDiem k);
        IList<LoaiDiem> getAll();
        LoaiDiem getmaLoaiDiem(int maloaidiem);
        int checkmaLoaiDiem_ID(int maloaidiem);
    }
}
