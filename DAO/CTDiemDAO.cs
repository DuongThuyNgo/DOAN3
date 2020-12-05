using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class CTDiemDAO
    {

        private const string PARM_MACTDIEM = "@mactdiem";
        private const string PARM_MAHOCSINH = "@mahocsinh";
        private const string PARM_MABANGDIEM= "@mabangdiem";
        private const string PARM_MAMONHOC = "@mamonhoc";
        private const string PARM_MALOAIDIEM = "@maloaidiem";
        private const string PARM_DIEM = "@diem";
        private const string PARM_DIEMTBMON = "@diemtbmon";
       
        private const string PARM_MAGIAOVIEN = "@magiaovien";

        public int Insert(CTDiem ctd)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter(PARM_MACTDIEM,SqlDbType.Int),
               new SqlParameter(PARM_MABANGDIEM,SqlDbType.Int),
               new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int),
               new SqlParameter(PARM_MAMONHOC,SqlDbType.Int),
               new SqlParameter(PARM_MALOAIDIEM,SqlDbType.Int),
               new SqlParameter(PARM_DIEM,SqlDbType.Int),
               new SqlParameter(PARM_DIEMTBMON,SqlDbType.Float),
           
               new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),

            };

            parm[0].Value = ctd.Mactdiem;
            parm[1].Value = ctd.Mabangdiem;
            parm[2].Value = ctd.Mahocsinh;
            parm[3].Value = ctd.Mamonhoc;
            parm[4].Value = ctd.Maloaidiem;
            parm[5].Value = ctd.Diem;
            parm[6].Value = ctd.Diemtbmon;
           
            parm[7].Value = ctd.Magiaovien;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_CTDiem_Insert", parm);
        }


        public int Delete(int maCTdiem)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MACTDIEM,SqlDbType.Int)
            };
            parm[0].Value = maCTdiem;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_CTDiem_Del", parm);
        }

        public int Update(CTDiem ctd)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter(PARM_MACTDIEM,SqlDbType.Int),
               new SqlParameter(PARM_MABANGDIEM,SqlDbType.Int),
               new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int),
               new SqlParameter(PARM_MAMONHOC,SqlDbType.Int),
               new SqlParameter(PARM_MALOAIDIEM,SqlDbType.Int),
               new SqlParameter(PARM_DIEM,SqlDbType.Int),
               new SqlParameter(PARM_DIEMTBMON,SqlDbType.Float),
               new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),

            };

            parm[0].Value = ctd.Mactdiem;
            parm[1].Value = ctd.Mabangdiem;
            parm[2].Value = ctd.Mahocsinh;
            parm[3].Value = ctd.Mamonhoc;
            parm[4].Value = ctd.Maloaidiem;
            parm[5].Value = ctd.Diem;
            parm[6].Value = ctd.Diemtbmon;
            parm[7].Value = ctd.Magiaovien;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_CTDiem_Upd", parm);
        }

        public IList<CTDiem> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_CTDiem_Sel_All", null);
            IList<CTDiem> list = new List<CTDiem>();
            while (dra.Read())
            {
                list.Add(new CTDiem(
                    int.Parse(dra["mactdiem"].ToString()),
                    int.Parse(dra["mabangdiem"].ToString()),
                    
                    int.Parse(dra["mahocsinh"].ToString()),
                    int.Parse(dra["mamonhoc"].ToString()),
                    int.Parse(dra["maloaidiem"].ToString()),
                    int.Parse(dra["diem"].ToString()),
                    float.Parse(dra["diemtb"].ToString()),
                   
                    int.Parse(dra["magiaovien"].ToString())));
            }
            dra.Dispose();
            return list;
        }
       
        
    }
}
