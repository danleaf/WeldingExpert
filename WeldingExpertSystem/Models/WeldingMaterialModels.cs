using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WeldingExpertSystem.Models
{
    public class WeldingMaterial
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name="型号")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "规格(mm)")]
        public double Standard { get; set; }

        [Display(Name = "移植号")]
        public string TransNo { get; set; }

        [Display(Name = "复检报告编号")]
        public string ReviewReportNo { get; set; } 
    }
}