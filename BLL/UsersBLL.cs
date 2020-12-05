using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using BLL.ServiceInterface;

namespace BLL
{
    public class UsersBLL:IUsersBLL
    {
        private readonly UsersDAO dal = new UsersDAO();
        public Users CheckAccount(string tenuser, string password)
        {
            return dal.checkAccount(tenuser, password);
        }
    }
}
