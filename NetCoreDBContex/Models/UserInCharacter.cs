using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCoreDBContex.Models
{
    //用户角色关联表
    [Table("UserInCharacter")]
    public class UserInCharacter
    {
        [Key]
        //数据库自动增长列
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UCid { get; set; }
        public int Uid { get; set; }//用户ID
        public int Cid { get; set; }//角色ID

        //用户
        [NotMapped]//排除特定属性
        [ForeignKey("Uid")]
        public UserInfo UserInfo { get; set; }
        //角色
        [NotMapped]
        [ForeignKey("Cid")]
        public Character Character { get; set; }

    }
}
