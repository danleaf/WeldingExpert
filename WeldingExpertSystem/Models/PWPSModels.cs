using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WeldingExpertSystem.Models
{
    public class WPS
    {
        [Key]
        [Display(Name="焊接工艺规程编号")]
        public String WPSNo { get; set; }

        [Display(Name = "焊接工艺评定报告编号")]
        public String PQRNo { get; set; }

        [Display(Name = "执行标准")]
        public Standard Standard { get; set; }

        [Display(Name = "焊接方法")]
        public List<WeldingWay> WeldingWays { get; set; }

        [Display(Name = "机械化程度")]
        public int MechanLevel { get; set; }    // enum MechanLevel

        public int Joint { get; set; }
    }

    public class WeldingWay
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<WPS> WPSs { get; set; }
    }
}

