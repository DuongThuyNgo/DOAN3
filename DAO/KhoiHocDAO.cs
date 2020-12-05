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
    public class KhoiHocDAO : IKhoiHocDAO
    {
        private const string PARM_MAKHOIHOC = "@makhoihoc";
        private const string PARM_TENKHOIHOC = "@tenkhoihoc"; 

            
        public int Insert(KhoiHoc kh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                
                new SqlParameter(PARM_TENKHOIHOC,SqlDbType.NVarChar,20)
            };
            parm[0].Value = kh.Tenkhoihoc;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_KhoiHoc_Insert", parm);
        }
        

        public int Delete(int makhoihoc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAKHOIHOC,SqlDbType.Int)
            };
            parm[0].Value = makhoihoc;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_KhoiHoc_Del", parm);
        }
          
        public int Update(KhoiHoc kh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAKHOIHOC,SqlDbType.Int),
                new SqlParameter(PARM_TENKHOIHOC,SqlDbType.NVarChar,20)

            };
            parm[0].Value = kh.Makhoihoc;
            parm[1].Value = kh.Tenkhoihoc;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_KhoiHoc_Upd", parm);
        }
       
        public IList<KhoiHoc> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_KhoiHoc_Sel_All", null);
            IList<KhoiHoc> list = new List<KhoiHoc>();
            while (dra.Read())
            {
                list.Add(new KhoiHoc(
                    int.Parse(dra["makhoihoc"].ToString()),
                    dra["tenkhoihoc"].ToString()));
            }
            dra.Dispose();
            return list;
        }
       
        
        public KhoiHoc getmaKhoiHoc(int makhoihoc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAKHOIHOC,SqlDbType.Int)
            };
            parm[0].Value = makhoihoc;
            KhoiHoc cls = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_KhoiHoc_Sel_ID", parm);
            if (dra.Read())
            {
                cls = new KhoiHoc(
                    int.Parse(dra["makhoihoc"].ToString()), 
                    dra["tenkhoihoc"].ToString());
            }
            dra.Dispose();
            return cls;
        }
        
        public int checkmaKhoiHoc_ID(int makhoihoc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAKHOIHOC,SqlDbType.Int)
            };
            parm[0].Value = makhoihoc;
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_KhoiHoc_Check", parm);
        }
    }
}
