using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NetCoreDBContex.Models;
using System;
using System.Collections.Generic;

namespace NetCoreDBContex
{
    public class BlogDBContext : DbContext
    {
        private string ConDB = "server=127.0.0.1;port=3306;user=root;password=123456.;database=blogdb";

        #region  连接数据库
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConDB);
            //context.Database.EnsureCreated();//针对当前访问的上下文对象，如果数据库中存在该表，则不做修改；否则的话进行创建
        }
        #endregion

        //public BlogDBContext(DbContextOptions options) : base(options)
        //{

        //}
        #region DbSet 数据集

        public DbSet<UserInfo> users { get; set; }
        public DbSet<UserInCharacter> userincharacters { get; set; }
        public DbSet<Character> characters { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///初始化数据
            modelBuilder.Entity<UserInfo>().HasData(new List<UserInfo>()
            {

            });
            modelBuilder.Entity<UserInCharacter>().HasData(new List<UserInCharacter>()
            {

            });
            modelBuilder.Entity<Character>().HasData(new List<Character>()
            {

            });
        }
    }
}
