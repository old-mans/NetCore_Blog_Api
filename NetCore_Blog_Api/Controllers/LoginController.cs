using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreDBContex.Extend;
using NetCoreDBContex.Models;

namespace NetCore_Blog_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBlogDBContextFactory _blogDBContextFactory;
        private readonly IDBHelper _dBHelper;

        public LoginController(ILogger<WeatherForecastController> logger, IBlogDBContextFactory blogDBContextFactory, IDBHelper dBHelper)
        {
            _logger = logger;
            _blogDBContextFactory = blogDBContextFactory;
            _dBHelper = dBHelper;
        }
        [HttpPost]
        public int Login(string Uname, string Upwd)
        {
            string sql = "select * from userinfo where uname=" + Uname + "and upwd=" + Upwd + "";
            int i = _dBHelper.ExecuteScalar(sql);
            return i;
        }
    }
}
