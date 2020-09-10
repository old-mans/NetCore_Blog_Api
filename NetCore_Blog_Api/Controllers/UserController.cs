using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            string sql = "select * from userinfo where uname=" + Uname + " and upwd=" + Upwd + "";
            int i = _dBHelper.ExecuteScalar(sql);
            return i;
        }

        [HttpPost]
        public int Add(UserInfo user)
        {
            string sql = "insert into userinfo values (" + user.Uid + "," + user.UName + "," + user.UPwd + "," + user.NickName + "," + user.Avatar + "," + user.Description + ")";
            int i = _dBHelper.ExecuteNonQuery(sql);
            return i;
        }

        [HttpPost]
        public int Del(int Uid)
        {
            string sql = "delete from userinfo where Uid=" + Uid + "";
            int i = _dBHelper.ExecuteNonQuery(sql);
            return i;
        }

        [HttpPost]
        public int UpDate(int Uid, UserInfo use)
        {
            string sql = "update userinfo set UName='" + use.UName + "',UPwd='" + use.UPwd + "',NickName='" + use.NickName + "',Avatar='" + use.Avatar + "',Description='" + use.Description + "' where Uid=" + Uid + "";
            int i = _dBHelper.ExecuteNonQuery(sql);
            return i;
        }
        [HttpPost]
        public string UseList(int Uid)
        {
            string sql = "select * from userinfo where Uid=" + Uid + "";
            DataSet i = _dBHelper.ExecuteDataSet(sql);
            return _jsonHelper.ToJson(i);
        }

    }
}
