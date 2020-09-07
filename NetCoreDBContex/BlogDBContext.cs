using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using NetCoreDBContex.Models;
using System;
using System.Collections.Generic;

namespace NetCoreDBContex
{
    public class BlogDBContext : DbContext
    {
        //private string ConDB = "server=localhost;user id=root;persistsecurityinfo=True;database=blogdb";

        public BlogDBContext(string ConDB)
        {

        }
        #region  连接数据库
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL(ConDB);
        //}
        #endregion


        #region DbSet 数据集

        public DbSet<UserInfo> users { get; set; }
        public DbSet<UserInCharacter> userincharacters { get; set; }
        public DbSet<Character> characters { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///初始化数据
            //modelBuilder.Entity<UserInfo>().HasData(new List<UserInfo>()
            //{

            //});
        }
    }
}
