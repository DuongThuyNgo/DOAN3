using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Users
    {
        public int mauser;
        public string tenuser;
        public string passwword;
        public string tenrole;
        public string trangthai;
        public Users()
        {
        }
        public Users(Users kh)
        {
            this.mauser = kh.mauser;
            this.tenuser = kh.tenuser;
            this.passwword = kh.passwword;
            this.tenrole = kh.tenrole;
            this.trangthai = kh.trangthai;
        }
        public Users(int mauser, string tenuser,string passwword,string tenrole,string trangthai)
        {
            this.mauser = mauser;
            this.tenuser = tenuser;
            this.passwword = passwword;
            this.tenrole = tenrole;
            this.trangthai = trangthai;
        }

        public int MaUser { get { return mauser; } set { mauser = value; } }
        public string TenUser { get { return tenuser; } set { tenuser = value; } }
        public string Passwword { get { return passwword; } set { passwword = value; } }
        public string TenRole { get { return tenrole; } set { tenrole = value; } }
        public string TrangThai { get { return trangthai; } set { trangthai = value; } }

    }
}
