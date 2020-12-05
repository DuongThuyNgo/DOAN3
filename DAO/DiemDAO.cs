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
    public class DiemDAO
    {
        
        private const string PARM_MABANGDIEM = "@mahocsinh";
        private const string PARM_MALOP = "@malop";
        private const string PARM_MAHOCSINH = "@mahocsinh";
        private const string PARM_KIHOC = "@kihoc";
        private const string PARM_NAMHOC = "@namhoc";
        private const string PARM_DIEMTB = "@diemtb";
        private const string PARM_HANHKIEM = "@hanhkiem";
        private const string PARM_HOCLUC = "@hocluc";
        private const string PARM_DANHHIEU = "@danhhieu";
        private const string PARM_MAGIAOVIEN = "@magiaovien";

        public int Insert(Diem d)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter(PARM_MABANGDIEM,SqlDbType.Int),
               new SqlParameter(PARM_MALOP,SqlDbType.Int),
               new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int),
               new SqlParameter(PARM_KIHOC,SqlDbType.Int),
               new SqlParameter(PARM_NAMHOC,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_DIEMTB,SqlDbType.Float),
                new SqlParameter(PARM_HANHKIEM,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_HOCLUC,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_DANHHIEU,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),
                
            };

            parm[0].Value = d.Mabangdiem;
            parm[1].Value = d.Malop;
            parm[2].Value = d.Mahocsinh;
            parm[3].Value = d.Kihoc;
            parm[4].Value = d.Namhoc;
            parm[5].Value = d.Diemtb;
            parm[6].Value = d.Hanhkiem;
            parm[7].Value = d.Hocluc;
            parm[8].Value = d.Danhhieu;
            parm[9].Value = d.Magiaovien;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_Diem_Insert", parm);
        }


        public int Delete(int mabangdiem)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int)
            };
            parm[0].Value = mabangdiem;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_Diem_Del", parm);
        }

        public int Update(Diem d)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MABANGDIEM,SqlDbType.Int),
               new SqlParameter(PARM_MALOP,SqlDbType.Int),
               new SqlParameter(PARM_MAHOCSINH,SqlDbType.Int),
               new SqlParameter(PARM_KIHOC,SqlDbType.Int),
               new SqlParameter(PARM_NAMHOC,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_DIEMTB,SqlDbType.Float),
                new SqlParameter(PARM_HANHKIEM,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_HOCLUC,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_DANHHIEU,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_MAGIAOVIEN,SqlDbType.Int),

            };
            parm[0].Value = d.Mabangdiem;
            parm[1].Value = d.Malop;
            parm[2].Value = d.Mahocsinh;
            parm[3].Value = d.Kihoc;
            parm[4].Value = d.Namhoc;
            parm[5].Value = d.Diemtb;
            parm[6].Value = d.Hanhkiem;
            parm[7].Value = d.Hocluc;
            parm[8].Value = d.Danhhieu;
            parm[9].Value = d.Magiaovien;

            return DataAccessHelper.ExecuteNonQuery(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_Diem_Upd", parm);
        }

        public IList<Diem> getAll()
        {
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_Diem_Sel_All", null);
            IList<Diem> list = new List<Diem>();
            while (dra.Read())
            {
                list.Add(new Diem(
                    int.Parse(dra["mabangdiem"].ToString()),
                    int.Parse(dra["malop"].ToString()),
                    int.Parse(dra["mahocsinh"].ToString()),
                    int.Parse(dra["kihoc"].ToString()),
                    dra["namhoc"].ToString(),
                    float.Parse(dra["diemtb"].ToString()),
                    dra["hanhkiem"].ToString(),
                    dra["hocluc"].ToString(),
                    dra["danhhieu"].ToString(),
                    int.Parse(dra["magiaovien"].ToString())));
            }
            dra.Dispose();
            return list;
        }
        public IList<Diem> getAll(int PageNo, int PageSize,int Malop,int Kihoc, string Namhoc, out int RecordCount)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                 new SqlParameter("@malop",SqlDbType.Int),
               new SqlParameter("@kihoc",SqlDbType.Int),
               new SqlParameter("@namhoc",SqlDbType.NVarChar,20),

           };
            parm[0].Value = PageNo;
            parm[1].Value = PageSize;
            parm[2].Value = Malop;
            parm[3].Value = Kihoc;
            parm[3].Value = Namhoc;

            RecordCount = 0;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_HocSinh_Sell_All_Page", parm);
            IList<Diem> list = new List<Diem>();
            while (dra.Read())
            {
                RecordCount = int.Parse(dra["RecordCount"].ToString());
               
                    list.Add(new Diem(
                    int.Parse(dra["mabangdiem"].ToString()),
                    int.Parse(dra["malop"].ToString()),
                    int.Parse(dra["mahocsinh"].ToString()),
                    int.Parse(dra["kihoc"].ToString()),
                    dra["namhoc"].ToString(),
                    float.Parse(dra["diemtb"].ToString()),
                    dra["hanhkiem"].ToString(),
                    dra["hocluc"].ToString(),
                    dra["danhhieu"].ToString(),
                    int.Parse(dra["magiaovien"].ToString())));
            }
            dra.Dispose();
            return list;
        }

        public Diem getmaDiem(int mabangdiem)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MABANGDIEM,SqlDbType.Int)
            };
            parm[0].Value = mabangdiem;
            Diem d = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_Diem_Sel_ID", parm);
            if (dra.Read())
            {
                d = new Diem(
                    int.Parse(dra["mabangdiem"].ToString()),
                    int.Parse(dra["malop"].ToString()),
                    int.Parse(dra["mahocsinh"].ToString()),
                    int.Parse(dra["kihoc"].ToString()),
                    dra["namhoc"].ToString(),
                    float.Parse(dra["diemtb"].ToString()),
                    dra["hanhkiem"].ToString(),
                    dra["hocluc"].ToString(),
                    dra["danhhieu"].ToString(),
                    int.Parse(dra["magiaovien"].ToString()));
            }
            dra.Dispose();
            return d;
        }
        public int getmaDiem_Last()
        {
            return (int)DataAccessHelper.ExecuteScalar(DataAccessHelper.ConnectionString, CommandType.Text, "select top 1 Mahocsinh from tbl_HocSinh order by Mahocsinh desc", null);
        }
        public int checkmaDiem_ID(int mahocsinh)
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
