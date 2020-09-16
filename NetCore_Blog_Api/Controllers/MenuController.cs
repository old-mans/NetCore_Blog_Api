using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreDBContex;
using NetCoreDBContex.Extend;
using NetCoreDBContex.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore_Blog_Api.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IDBHelper _dBHelper;
        private readonly IJsonHelper _jsonHelper;
        public MenuController(IDBHelper dBHelper, IJsonHelper jsonHelper)
        {
            _dBHelper = dBHelper;
            _jsonHelper = jsonHelper;
        }

        [HttpPost]
        public string GetMenu()
        {
            using (var db = new BlogDBContext())
            {
                var blogs = db.menus
                            .ToList();

                return _jsonHelper.SerializeJSON(blogs);
            }

            //string sql = "select * from menuinfo";
            //DataSet i = _dBHelper.ExecuteDataSet(sql);
            //return _jsonHelper.ToJson(i);
        }

        [HttpPost]
        public int AddMenu(MenuInfo menu)
        {
            int i = 0;
            using (var s = new BlogDBContext())
            {
                var a = new MenuInfo { MName = menu.MName, MUrl = menu.MUrl };
                s.menus.Add(a);
                i = s.SaveChanges();
            }
            return i;

            //string sql = "insert into menuinfo values (" + menu.Mid + ",'" + menu.MName + "','" + menu.MUrl + "')";
            //int i = _dBHelper.ExecuteNonQuery(sql);
            //return i;
        }
        //[HttpPost]
        //public string MenuList()
        //{
        //    var db = new BlogDBContext();

        //    var blogs = db.menus
        //        .ToList();

        //    return _jsonHelper.SerializeJSON(blogs);
        //}


    }
}
