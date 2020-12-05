using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.ServiceInterface
{
    public interface IGiaoVienBLL
    {
        int Insert(GiaoVien hs);
        int Delete(int maGV);
        int Update(GiaoVien hs);
        IList<GiaoVien> getAll();
        GiaoVien getmaGiaoVien(int maGV);
        int getmaGiaoVien_Last();
        int checkmaGiaoVien_ID(int maGV);
        
    }
}
