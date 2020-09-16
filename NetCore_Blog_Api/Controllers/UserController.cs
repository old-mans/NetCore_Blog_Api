using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCoreDBContex;
using NetCoreDBContex.Extend;
using NetCoreDBContex.Models;
using Newtonsoft.Json.Converters;

namespace NetCore_Blog_Api.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDBHelper _dBHelper;
        private readonly IJsonHelper _jsonHelper;
        public UserController(IDBHelper dBHelper, IJsonHelper jsonHelper)
        {
            _dBHelper = dBHelper;
            _jsonHelper = jsonHelper;
        }
        [HttpPost]
        public int Login(string Uname, string Upwd)
        {
            int i = 0;
            using (var s = new BlogDBContext())
            {
                var a = s.users.Where(b => b.UName == Uname && b.UPwd == Upwd).ToList();
                if (a.Count != 0)
                    i = 1;
            }
            return i;

            //string sql = "select * from userinfo where uname=" + Uname + " and upwd=" + Upwd + "";
            //int i = _dBHelper.ExecuteScalar(sql);
            //return i;
        }

        [HttpPost]
        public int AddUser(UserInfo user)
        {
            int i = 0;
            using (var s = new BlogDBContext())
            {
                var a = new UserInfo { UName = user.UName, UPwd = user.UPwd, NickName = user.NickName, Avatar = user.Avatar, Description = user.Description };
                s.users.Add(a);
                i = s.SaveChanges();
            }
            return i;

            //string sql = "insert into userinfo values (" + user.Uid + "," + user.UName + "," + user.UPwd + "," + user.NickName + "," + user.Avatar + "," + user.Description + ")";
            //int i = _dBHelper.ExecuteNonQuery(sql);
            //return i;
        }

        [HttpPost]
        public int Del(int Uid)
        {
            int i = 0;
            using (var s = new BlogDBContext())
            {
                UserInfo user = s.users.Find(Uid);
                s.users.Remove(user);
                i = s.SaveChanges();
            }
            return i;
            //string sql = "delete from userinfo where Uid=" + Uid + "";
            //int i = _dBHelper.ExecuteNonQuery(sql);
            //return i;
        }

        [HttpPost]
        public int UpDate(int Uid, UserInfo use)
        {
            int i = 0;
            using (var s = new BlogDBContext())
            {
                UserInfo user = s.users.Find(Uid);
                user.UName = use.UName;
                user.UPwd = use.UPwd;
                user.Avatar = use.Avatar;
                user.Description = use.Description;
                user.NickName = use.NickName;
                i = s.SaveChanges();
            }
            return i;

            //string sql = "update userinfo set UName='" + use.UName + "',UPwd='" + use.UPwd + "',NickName='" + use.NickName + "',Avatar='" + use.Avatar + "',Description='" + use.Description + "' where Uid=" + Uid + "";
            //int i = _dBHelper.ExecuteNonQuery(sql);
            //return i;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        [HttpPost]
        public string UseList(string Ustring)
        {
            var sa = "";
            using (var s = new BlogDBContext())
            {
                var result = s.users.Where(item => EF.Functions.Like(item.UName, "%" + Ustring + "%")).ToList();
                sa = _jsonHelper.SerializeJSON(result);
            }
            return sa;
            //string sql = "select * from userinfo where UName like '%" + Ustring + "%'";
            //DataSet i = _dBHelper.ExecuteDataSet(sql);
            //return _jsonHelper.ToJson(i);
        }
        /// <summary>
        /// 所有用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetUse()
        {
            var sa = "";
            using (var s = new BlogDBContext())
            {
                var result = s.users.ToList();
                sa = _jsonHelper.SerializeJSON(result);
            }
            return sa;
            //string sql = "select * from userinfo ";
            //DataSet i = _dBHelper.ExecuteDataSet(sql);
            //return _jsonHelper.ToJson(i);
        }

    }
}
