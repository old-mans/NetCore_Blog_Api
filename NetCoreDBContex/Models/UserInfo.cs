using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NetCoreDBContex.Models
{
    //对应数据库表名
    [Table("UserInfo")]
    public class UserInfo
    {
        //主键
        [Key]
        //数据库自动增长列
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Uid { get; set; }//主键ID
        public string UName { get; set; }//账户
        public string UPwd { get; set; }//密码
        public string NickName { get; set; }//昵称
        public string Avatar { get; set; }//头像
        public string Description { get; set; }//描述（简介）

    }
}
