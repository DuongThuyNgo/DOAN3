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
    public class HocSinhDAO : IHocSinhDAO
    {
        private const string PARM_MAHOCSINH = "@mahocsinh";
        private const string PARM_MALOP = "@malop";
        private const string PARM_TENHOCSINH = "@tenhocsinh";
        private const string PARM_NGAYSINH = "@ngaysinh";
        private const string PARM_GIOITINH = "@gioitinh";
        private const string PARM_QUEQUAN = "@quequan";
        private const string PARM_SODT = "@sodienthoai";
        private const string PARM_SOCMND = "@socmnd";

        public int Insert(HocSinh hs)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                
                new SqlParameter(PARM_MALOP,SqlDbType.Int),
                new SqlParameter(PARM_TENHOCSINH,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_NGAYSINH,SqlDbType.DateTime),
                new SqlParameter(PARM_GIOITINH,SqlDbType.NVarChar,3),
                new SqlParameter(PARM_QUEQUAN,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_SODT,SqlDbType.NVarChar,11),
                new SqlParameter(PARM_SOCMND,SqlDbType.NVarChar,11),

            };
           
            parm[0].Value = hs.Malop;
            parm[1].Value = hs.Tenhocsinh;
            parm[2].Value = hs.Ngaysinh;
            parm[3].Value = hs.Gioitinh;
            parm[4].Value = hs.Quequan;
            parm[5].Value = hs.Sodienthoai;
            parm[6].Value = hs.Socmnd;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Insert", parm);
        }


        public int Delete(int mahocsinh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int)
            };
            parm[0].Value = mahocsinh;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Del", parm);
        }

        public int Update(HocSinh hs)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int),
                new SqlParameter(PARM_MALOP,SqlDbType.Int),
                new SqlParameter(PARM_TENHOCSINH,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_NGAYSINH,SqlDbType.DateTime),
                new SqlParameter(PARM_GIOITINH,SqlDbType.NVarChar,3),
                new SqlParameter(PARM_QUEQUAN,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_SODT,SqlDbType.NVarChar,11),
                new SqlParameter(PARM_SOCMND,SqlDbType.NVarChar,11),

            };
            parm[0].Value = hs.Mahocsinh;
            parm[1].Value = hs.Malop;
            parm[2].Value = hs.Tenhocsinh;
            parm[3].Value = hs.Ngaysinh;
            parm[4].Value = hs.Gioitinh;
            parm[5].Value = hs.Quequan;
            parm[6].Value = hs.Sodienthoai;
            parm[7].Value = hs.Socmnd;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Upd", parm);
        }

        public IList<HocSinh> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Sel_All", null);
            IList<HocSinh> list = new List<HocSinh>();
            while (dra.Read())
            {
                list.Add(new HocSinh(
                    int.Parse(dra["mahocsinh"].ToString()),
                    int.Parse(dra["malop"].ToString()),
                    dra["tenhocsinh"].ToString(),
                    DateTime.Parse(dra["ngaysinh"].ToString()),
                    dra["gioitinh"].ToString(),
                    dra["quequan"].ToString(),
                    dra["sodienthoai"].ToString(),
                    dra["socmnd"].ToString()));
            }
            dra.Dispose();
            return list;
        }
        //public IList<HocSinh> getAll(int PageNo, int PageSize, string Tenhocsinh, string Quequan, out int RecordCount)
        //{
        //    SqlParameter[] parm = new SqlParameter[]
        //   {
        //       new SqlParameter("@PageIndex",SqlDbType.Int),
        //        new SqlParameter("@PageSize",SqlDbType.Int),
        //        new SqlParameter("@tenhocsinh",SqlDbType.NVarChar,20),
        //        new SqlParameter("@quequan",SqlDbType.NVarChar,20),
        //   };
        //    parm[0].Value = PageNo;
        //    parm[1].Value = PageSize;
        //    parm[2].Value = Tenhocsinh;
        //    parm[3].Value = Quequan;

        //    RecordCount = 0;
        //    SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Sell_All_Page", parm);
        //    IList<HocSinh> list = new List<HocSinh>();
        //    while (dra.Read())
        //    {
        //        RecordCount = int.Parse(dra["RecordCount"].ToString());
        //        list.Add(new HocSinh(
        //            int.Parse(dra["mahocsinh"].ToString()),
        //            int.Parse(dra["malop"].ToString()),
        //            dra["tenhocsinh"].ToString(),
        //            DateTime.Parse(dra["ngaysinh"].ToString()),
        //            dra["gioitinh"].ToString(),
        //            dra["quequan"].ToString(),
        //            dra["sodienthoai"].ToString(),
        //            dra["socmnd"].ToString()));
        //    }
        //    dra.Dispose();
        //    return list;
        //}

        public HocSinh getmaHocSinh(int mahocsinh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int)
            };
            parm[0].Value = mahocsinh;
            HocSinh hs = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Sel_ID", parm);
            if (dra.Read())
            {
                hs = new HocSinh(
                    int.Parse(dra["mahocsinh"].ToString()),
                    int.Parse(dra["malop"].ToString()),
                    dra["tenhocsinh"].ToString(),
                    DateTime.Parse(dra["ngaysinh"].ToString()),
                    dra["gioitinh"].ToString(),
                    dra["quequan"].ToString(),
                    dra["sodienthoai"].ToString(),
                    dra["socmnd"].ToString());
            }
            dra.Dispose();
            return hs;
        }
        public int getmaHocSinh_Last()
        {
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.Text, "select top 1 Mahocsinh from tbl_HocSinh order by Mahocsinh desc", null);
        }
        public int checkmaHocSinh_ID(int mahocsinh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int)
            };
            parm[0].Value = mahocsinh;
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Check", parm);
        }
    }
}
