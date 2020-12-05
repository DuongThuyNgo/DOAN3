using DAO.ServiceInterface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LoaiDiemDAO : ILoaiDiemDAO
    {
        private const string PARM_MALOAIDIEM = "@maloaidiem";
        private const string PARM_TENLOAIDIEM = "@tenloaidiem";
        private const string PARM_HESO = "@heso";

        public int Insert(LoaiDiem lđ)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_MALOAIDIEM,SqlDbType.Int),
                new SqlParameter(PARM_TENLOAIDIEM,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_HESO,SqlDbType.Int),

            };
            parm[0].Value = lđ.Maloaidiem;
            parm[1].Value = lđ.Tenloaidiem;
            parm[2].Value = lđ.Heso;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LoaiDiem_Insert", parm);
        }


        public int Delete(int maloaidiem)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOAIDIEM,SqlDbType.Int)
            };
            parm[0].Value = maloaidiem;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LoaiDiem_Del", parm);
        }

        public int Update(LoaiDiem ld)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOAIDIEM,SqlDbType.Int),
                new SqlParameter(PARM_TENLOAIDIEM,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_HESO,SqlDbType.Int),

            };
            parm[0].Value = ld.Maloaidiem;
            parm[1].Value = ld.Tenloaidiem;
            parm[2].Value = ld.Heso;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LoaiDiem_Upd", parm);
        }

        public IList<LoaiDiem> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LoaiDiem_Sel_All", null);
            IList<LoaiDiem> list = new List<LoaiDiem>();
            while (dra.Read())
            {
                list.Add(new LoaiDiem(
                    int.Parse(dra["maloaidiem"].ToString()),
                    dra["tenloaidiem"].ToString(),
                    int.Parse(dra["heso"].ToString())));

            }
            dra.Dispose();
            return list;
        }
      

        public LoaiDiem getmaLoaiDiem(int maloaidiem)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOAIDIEM,SqlDbType.Int)
            };
            parm[0].Value = maloaidiem;
            LoaiDiem ld = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LoaiDiem_Sel_ID", parm);
            if (dra.Read())
            {
                ld = new LoaiDiem(
                    int.Parse(dra["maloaidiem"].ToString()),
                    dra["tenloaidiem"].ToString(),
                    int.Parse(dra["heso"].ToString()));
            }
            dra.Dispose();
            return ld;
        }
        public int getmaLoaiDiem_Last()
        {
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.Text, "select top 1 maloaidiem from tbl_LoaiDiem order by maloaidiem desc", null);
        }
        public int checkmaLoaiDiem_ID(int maloaidiem)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOAIDIEM,SqlDbType.Int)
            };
            parm[0].Value = maloaidiem;
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LoaiDiem_Check", parm);
        }
    }
}
