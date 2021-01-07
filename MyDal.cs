using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MODEL;

namespace DAL
{
    public class MyDal
    {
        /// <summary>
        /// 显示所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<Roles> GetRoles() 
        {
            string sql = "select * from Roles";
            DataTable dt = DBHelper.GetDataTable(sql);
            return DBHelper.ConvertTableToList<Roles>(dt);
        } 
        /// <summary>
        /// 显示所有用户列表
        /// </summary>
        /// <returns></returns>
        public List<Users> GetUsers() 
        {
            string sql = "select * from Users";
            DataTable dt = DBHelper.GetDataTable(sql);
            return DBHelper.ConvertTableToList<Users>(dt);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUser(Users u) 
        {
            string sql = $"insert into Users values('{u.UName}','{u.UPwd}','{u.Emile}','{DateTime.Now}',default,default,'{u.RId}')";
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int EditUser(Users u) 
        {
            string sql = $"update Users set UName='{u.UName}',UPwd='{u.UPwd}',Emile='{u.Emile}',CreateTime='{DateTime.Now}',RId={u.RId} where UId={u.UId}";
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int LoginEdit(int id,string ip)
        {
            string sql = $"update Users set LoginTime='{DateTime.Now}',LoginId='{ip}'  where UId={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int AddRole(Roles r)
        {
            string sql = $"insert into Roles values('{r.RName}',{(r.RType==true? 1:0)})";
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int EditRole(Roles r)
        {
            string sql = $"update Roles set RName='{r.RName}',RType={(r.RType == true ? 1 : 0)} where  RId={r.RId}";
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int DelUser(int id)
        {
            string sql = $"delete Users where UId={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int DelUsers(string ids)
        {
            string sql = $"delete Users where UId in ({ids})";
            return DBHelper.ExecuteNonQuery(sql);
        }
        public int DelRole(int id)
        {
            string sql = $"delete Roles where RId={id}";
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
