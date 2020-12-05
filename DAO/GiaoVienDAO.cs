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
    public class GiaoVienDAO : IGiaoVienDAO
    {
        private const string PARM_MAGIAOVIEN = "@magiaovien";
        private const string PARM_TENGIAOVIEN = "@tengiaovien";
        private const string PARM_NGAYSINH = "@ngaysinh";
        private const string PARM_GIOITINH = "@gioitinh";
        private const string PARM_QUEQUAN = "@quequan";
        private const string PARM_SODT = "@sodienthoai";
        private const string PARM_SOCMND = "@socmnd";

        public int Insert(GiaoVien gv)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),
                new SqlParameter(PARM_TENGIAOVIEN,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_NGAYSINH,SqlDbType.DateTime),
                new SqlParameter(PARM_GIOITINH,SqlDbType.NVarChar,3),
                new SqlParameter(PARM_QUEQUAN,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_SODT,SqlDbType.NVarChar,11),
                new SqlParameter(PARM_SOCMND,SqlDbType.NVarChar,11),

            };
            parm[0].Value = gv.Magiaovien;
            parm[1].Value = gv.Tengiaovien;
            parm[2].Value = gv.Ngaysinh;
            parm[3].Value = gv.Gioitinh;
            parm[4].Value = gv.Quequan;
            parm[5].Value = gv.Sodienthoai;
            parm[6].Value = gv.Socmnd;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_GiaoVien_Ins", parm);
        }


        public int Delete(int magiaovien)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int)
            };
            parm[0].Value = magiaovien;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_GiaoVien_Del", parm);
        }

        public int Update(GiaoVien gv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),
                new SqlParameter(PARM_TENGIAOVIEN,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_NGAYSINH,SqlDbType.DateTime),
                new SqlParameter(PARM_GIOITINH,SqlDbType.NVarChar,3),
                new SqlParameter(PARM_QUEQUAN,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_SODT,SqlDbType.NVarChar,11),
                new SqlParameter(PARM_SOCMND,SqlDbType.NVarChar,11),

            };
            parm[0].Value = gv.Magiaovien;
            parm[1].Value = gv.Tengiaovien;
            parm[2].Value = gv.Ngaysinh;
            parm[3].Value = gv.Gioitinh;
            parm[4].Value = gv.Quequan;
            parm[5].Value = gv.Sodienthoai;
            parm[6].Value = gv.Socmnd;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_GiaoVien_Upd", parm);
        }

        public IList<GiaoVien> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_GiaoVien_Sel_All", null);
            IList<GiaoVien> list = new List<GiaoVien>();
            while (dra.Read())
            {
                list.Add(new GiaoVien(
                    int.Parse(dra["magiaovien"].ToString()),
                    dra["tengiaovien"].ToString(),
                    DateTime.Parse(dra["ngaysinh"].ToString()),
                    dra["gioitinh"].ToString(),
                    dra["quequan"].ToString(),
                    dra["sodienthoai"].ToString(),
                    dra["socmnd"].ToString()));
            }
            dra.Dispose();
            return list;
        }
        public IList<GiaoVien> getAll(int Magiaovien, string Tengiaovien, DateTime Ngaysinh, string Gioitinh, string Quequan, string Sodienthoai, string Socmnd, out int RecordCount)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@magiaovien",SqlDbType.Int),
                new SqlParameter("@tengiaovien",SqlDbType.NVarChar,20),
                new SqlParameter("@ngaysinh",SqlDbType.DateTime),
                new SqlParameter("@gioitinh",SqlDbType.NVarChar,20),
                new SqlParameter("@quequan",SqlDbType.NVarChar,20),
                new SqlParameter("@sodienthoai",SqlDbType.NVarChar,20),
                new SqlParameter("@socmnd",SqlDbType.NVarChar,20),

           };
            parm[0].Value = Magiaovien;
            parm[1].Value = Tengiaovien;
            parm[2].Value = Ngaysinh;
            parm[3].Value = Gioitinh;
            parm[4].Value = Quequan;
            parm[5].Value = Sodienthoai;
            parm[6].Value = Socmnd;
            RecordCount = 0;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_GiaoVien_Sel_All_Page", parm);
            IList<GiaoVien> list = new List<GiaoVien>();
            while (dra.Read())
            {
                RecordCount = int.Parse(dra["RecordCount"].ToString());
                list.Add(new GiaoVien(
                    int.Parse(dra["magiaovien"].ToString()),
                    dra["tengiaovien"].ToString(),
                    DateTime.Parse(dra["ngaysinh"].ToString()),
                    dra["gioitinh"].ToString(),
                    dra["quequan"].ToString(),
                    dra["sodienthoai"].ToString(),
                    dra["socmnd"].ToString()));
            }
            dra.Dispose();
            return list;
        }

        public GiaoVien getmaGiaoVien(int magiaovien)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int)
            };
            parm[0].Value = magiaovien;
            GiaoVien gv = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_KhoiHoc_Sel_ID", parm);
            if (dra.Read())
            {
                gv = new GiaoVien(
                    int.Parse(dra["magiaovien"].ToString()),
                    dra["tengiaovien"].ToString(),
                    DateTime.Parse(dra["ngaysinh"].ToString()),
                    dra["gioitinh"].ToString(),
                    dra["quequan"].ToString(),
                    dra["sodienthoai"].ToString(),
                    dra["socmnd"].ToString());
            }
            dra.Dispose();
            return gv;
        }
        public int getmaGiaoVien_Last()
        {
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.Text, "select top 1 magiaovien from tbl_GiaoVien order by magiaovien desc", null);
        }
        public int checkmaGiaoVien_ID(int magiaovien)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int)
            };
            parm[0].Value = magiaovien;
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_GiaoVien_Check", parm);
        }
    }
}
