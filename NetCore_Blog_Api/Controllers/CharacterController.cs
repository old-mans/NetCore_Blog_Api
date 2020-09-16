using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreDBContex;
using NetCoreDBContex.Extend;

namespace NetCore_Blog_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IDBHelper _dBHelper;
        private readonly IJsonHelper _jsonHelper;
        public CharacterController(IDBHelper dBHelper, IJsonHelper jsonHelper)
        {
            _dBHelper = dBHelper;
            _jsonHelper = jsonHelper;
        }

        [HttpPost]
        public string GetCharaction()
        {
            var sa = "";
            using (var s = new BlogDBContext())
            {
                var result = s.characters.ToList();
                sa = _jsonHelper.SerializeJSON(result);
            }
            return sa;

            //string sql = "select * from character ";
            //DataSet i = _dBHelper.ExecuteDataSet(sql);
            //return _jsonHelper.ToJson(i);
        }

    }
}
