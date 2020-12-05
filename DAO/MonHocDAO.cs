using DAO.ServiceInterface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MonHocDAO : IMonHocDAO
    {
        private const string PARM_MAMONHOC = "@mamonhoc";
        private const string PARM_TENMONHOC = "@tenmonhoc";
        private const string PARM_SOTIET = "@sotiet";



        public int Insert(MonHoc mh)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               
                new SqlParameter(PARM_TENMONHOC,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_SOTIET,SqlDbType.Int),

            };
           
            parm[0].Value = mh.Tenmonhoc;
            parm[1].Value = mh.Sotiet;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_MonHoc_Insert", parm);
        }


        public int Delete(int mamonhoc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAMONHOC,SqlDbType.Int)
            };
            parm[0].Value = mamonhoc;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_MonHoc_Del", parm);
        }

        public int Update(MonHoc mh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAMONHOC,SqlDbType.Int),
                new SqlParameter(PARM_TENMONHOC,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_SOTIET,SqlDbType.Int),

            };
            parm[0].Value = mh.Mamonhoc;
            parm[1].Value = mh.Tenmonhoc;
            parm[2].Value = mh.Sotiet;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_MonHoc_Upd", parm);
        }

        public IList<MonHoc> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_MonHoc_Sel_All", null);
            IList<MonHoc> list = new List<MonHoc>();
            while (dra.Read())
            {
                list.Add(new MonHoc(
                    int.Parse(dra["mamonhoc"].ToString()),
                    dra["tenmonhoc"].ToString(),
                    int.Parse(dra["sotiet"].ToString())));

            }
            dra.Dispose();
            return list;
        }
        public IList<MonHoc> getAll(int Mamonhoc, string Tenmonhoc, int Sotiet, out int RecordCount)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@mamochoc",SqlDbType.Int),
                new SqlParameter("@tenmonhoc",SqlDbType.NVarChar,20),
                new SqlParameter("@sotiet",SqlDbType.Int),

            };
            parm[0].Value = Mamonhoc;
            parm[1].Value = Tenmonhoc;
            parm[2].Value = Sotiet;
            RecordCount = 0;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_MonHoc_Sel_All_Page", parm);
            IList<MonHoc> list = new List<MonHoc>();
            while (dra.Read())
            {
                RecordCount = int.Parse(dra["RecordCount"].ToString());
                list.Add(new MonHoc(
                    int.Parse(dra["mamonhoc"].ToString()),
                    dra["tenmonhoc"].ToString(),
                    int.Parse(dra["sotiet"].ToString())));
            }
            dra.Dispose();
            return list;
        }

        public MonHoc getmaMonHoc(int mamonhoc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAMONHOC,SqlDbType.Int)
            };
            parm[0].Value = mamonhoc;
            MonHoc l = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_MonHoc_Sel_ID", parm);
            if (dra.Read())
            {
                l = new MonHoc(
                    int.Parse(dra["mamonhoc"].ToString()),
                    dra["tenmonhoc"].ToString(),
                    int.Parse(dra["sotiet"].ToString()));
            }
            dra.Dispose();
            return l;
        }
        public int getmaMonHoc_Last()
        {
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.Text, "select top 1 mamonhoc from tbl_MonHoc order by mamonhoc desc", null);
        }
        public int checkmaMonHoc_ID(int mamonhoc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAMONHOC,SqlDbType.Int)
            };
            parm[0].Value = mamonhoc;
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_MonHoc_Check", parm);
        }
    }
}
