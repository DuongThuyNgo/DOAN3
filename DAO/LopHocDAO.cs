using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.ServiceInterface;
using DTO;

namespace DAO
{
    public class LopHocDAO : ILopHocDAO
    {
        private const string PARM_MALOP = "@malop";
        private const string PARM_TENLOP = "@tenlop";
        private const string PARM_MAGIAOVIEN = "@magiaovien";
        private const string PARM_MAKHOI = "@makhoihoc";
        private const string PARM_SISO = "siso";


        public int Insert(LopHoc l)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                
                new SqlParameter(PARM_TENLOP,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_MAKHOI,SqlDbType.Int),
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),
                new SqlParameter(PARM_SISO,SqlDbType.Int),
            };
           
            parm[0].Value = l.Tenlop;
            parm[1].Value = l.Makhoihoc;
            parm[2].Value = l.Magiaovien;
            parm[3].Value = l.Siso;


            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LopHoc_Ins", parm);
        }


        public int Delete(int malop)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOP,SqlDbType.Int)
            };
            parm[0].Value = malop;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LopHoc_Del", parm);
        }

        public int Update(LopHoc l)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOP,SqlDbType.Int),
                new SqlParameter(PARM_TENLOP,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_MAKHOI,SqlDbType.Int),
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),
                new SqlParameter(PARM_SISO,SqlDbType.Int),

            };
            parm[0].Value = l.Malop;
            parm[1].Value = l.Tenlop;
            parm[2].Value = l.Makhoihoc;
            parm[3].Value = l.Magiaovien;
            parm[4].Value = l.Siso;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LopHoc_Upd", parm);
        }

        public IList<LopHoc> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LopHoc_Sel_All", null);
            IList<LopHoc> list = new List<LopHoc>();
            while (dra.Read())
            {
                list.Add(new LopHoc(
                    int.Parse(dra["malop"].ToString()),
                    dra["tenlop"].ToString(),
                    int.Parse(dra["makhoihoc"].ToString()),
                    int.Parse(dra["magiaovien"].ToString()),
                    int.Parse(dra["siso"].ToString())));

            }
            dra.Dispose();
            return list;
        }
        public IList<LopHoc> getAll(int PageNo, int PageSize, int Makhoihoc,int Siso, out int RecordCount)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@makhoihoc",SqlDbType.Int),
                new SqlParameter("@siso",SqlDbType.Int),

            };
            parm[0].Value = PageNo;
            parm[1].Value = PageSize;
            parm[2].Value = Makhoihoc;
            parm[3].Value = Siso;
            RecordCount = 0;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LopHoc_Sel_All_Page", parm);
            IList<LopHoc> list = new List<LopHoc>();
            while (dra.Read())
            {
                RecordCount = int.Parse(dra["RecordCount"].ToString());
                list.Add(new LopHoc(
                    int.Parse(dra["malop"].ToString()),
                    dra["tenlop"].ToString(),
                    int.Parse(dra["makhoihoc"].ToString()),
                    int.Parse(dra["magiaovien"].ToString()),
                    int.Parse(dra["siso"].ToString())));
            }
            dra.Dispose();
            return list;
        }

        public LopHoc getmaLopHoc(int malop)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOP,SqlDbType.Int)
            };
            parm[0].Value = malop;
            LopHoc l = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LopHoc_Sel_ID", parm);
            if (dra.Read())
            {
                l = new LopHoc(
                    int.Parse(dra["malop"].ToString()),
                    dra["tenlop"].ToString(),
                    int.Parse(dra["makhoihoc"].ToString()),
                    int.Parse(dra["magiaovien"].ToString()),
                    int.Parse(dra["siso"].ToString()));
            }
            dra.Dispose();
            return l;
        }
        public int getmaLopHoc_Last()
        {
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.Text, "select top 1 malop from tbl_LopHoc order by malop desc", null);
        }
        public int checkmaLopHoc_ID(int malop)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MALOP,SqlDbType.Int)
            };
            parm[0].Value = malop;
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_LopHoc_Check", parm);
        }
    }
}
