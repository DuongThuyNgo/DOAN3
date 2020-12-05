using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.ServiceInterface
{
    public interface IGiaoVienDAO
    {
        int Insert(GiaoVien gv);
        int Delete(int magiaovien);
        int Update(GiaoVien gv);
        IList<GiaoVien> getAll();
        IList<GiaoVien> getAll(int Magiaovien, string Tengiaovien, DateTime Ngaysinh, string Gioitinh, string Quequan, string Sodienthoai, string Socmnd, out int RecordCount);
        GiaoVien getmaGiaoVien(int magiaovien);
        int getmaGiaoVien_Last();
        int checkmaGiaoVien_ID(int magiaovien);
    }
}
