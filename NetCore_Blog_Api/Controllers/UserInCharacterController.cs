using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreDBContex.Extend;

namespace NetCore_Blog_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserInCharacterController : ControllerBase
    {
        private readonly IDBHelper _dBHelper;
        private readonly IJsonHelper _jsonHelper;
        public UserInCharacterController(IDBHelper dBHelper, IJsonHelper jsonHelper)
        {
            _dBHelper = dBHelper;
            _jsonHelper = jsonHelper;
        }

    }
}
