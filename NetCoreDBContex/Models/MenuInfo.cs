using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCoreDBContex.Models
{
    [Table("MenuInfo")]
    public class MenuInfo
    {
        //主键
        [Key]
        //数据库自动增长列
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Mid { get; set; }
        public string MName { get; set; }//名称
        public string MUrl { get; set; }//地址

    }
}
