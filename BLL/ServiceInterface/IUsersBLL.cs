using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;


namespace BLL.ServiceInterface
{
    public interface IUsersBLL
    {
        Users CheckAccount(string tenuser, string password);

    }
}
