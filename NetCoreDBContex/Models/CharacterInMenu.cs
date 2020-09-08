using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCoreDBContex.Models
{
    [Table("CharacterInMenu")]
    public class CharacterInMenu
    {
        //用户角色关联表
        [Key]
        //数据库自动增长列
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CMid { get; set; }
        public int Mid { get; set; }//菜单ID
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
