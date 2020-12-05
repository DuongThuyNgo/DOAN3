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
    public class UsersDAO : IUsersDAO
    {
        private const string PARM_MAUSER = "@mauser";
        private const string PARM_TENUSER = "@tenuser";
        private const string PARM_PASSWORD = "@passwword";
        private const string PARM_TENROLE = "@tenrole";
        private const string PARM_TRANGTHAI = "@trangthai";

        public Users checkAccount(string tenuser,string password)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_TENUSER,SqlDbType.NVarChar,20),
                new SqlParameter(PARM_PASSWORD,SqlDbType.NVarChar,20),
            };
            parm[0].Value = tenuser;
            parm[1].Value = password;
            Users cls = null;
            SqlDataReader dra = DataAccessHelper.ExecuteReader(DataAccessHelper.ConnectionString, CommandType.StoredProcedure, "tbl_User_CheckAccount", parm);
            if (dra.Read())
            {
                cls = new Users(
                    int.Parse(dra["mauser"].ToString()),
                    dra["tenuser"].ToString(),
                    dra["passwword"].ToString(),
                    dra["tenrole"].ToString(),
                    dra["trangthai"].ToString());
            }
            dra.Dispose();
            return cls;
        }
    }
}
