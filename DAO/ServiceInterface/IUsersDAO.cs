using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.ServiceInterface
{
    public interface IUsersDAO
    {
        Users checkAccount(string tenuser, string password);
    }
}
