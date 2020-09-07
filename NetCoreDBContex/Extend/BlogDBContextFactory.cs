using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDBContex.Extend
{
    public class BlogDBContextFactory : IBlogDBContextFactory
    {
        //获取配置文件
        private IConfiguration _configuration;

        string ConDb = string.Empty;

        public BlogDBContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            ConDb = _configuration.GetConnectionString("ConDB").ToString();
        }

        /// <summary>
        /// 工厂类 实现接口
        /// </summary>
        /// <returns></returns>
        public BlogDBContext Context()
        {
            var context = new BlogDBContext(ConDb);
            context.Database.EnsureCreated();//针对当前访问的上下文对象，如果数据库中存在该表，则不做修改；否则的话进行创建
            return context;
        }

    }
}
