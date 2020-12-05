using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.ServiceInterface
{
    public interface ILoaiDiemDAO
    {
        int Insert(LoaiDiem ld);
        int Delete(int maloaidiem);
        int Update(LoaiDiem ld);
        IList<LoaiDiem> getAll();

        LoaiDiem getmaLoaiDiem(int maloaidiem);
        int getmaLoaiDiem_Last();
        int checkmaLoaiDiem_ID(int makhoihoc);
    }
}
