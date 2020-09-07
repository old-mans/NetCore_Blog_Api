using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCoreDBContex.Models
{
    //角色表
    [Table("Character")]
    public class Character
    {
        [Key]
        //数据库自动增长列
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cid { get; set; }
        public string CName { get; set; }//角色名称



    }
}
