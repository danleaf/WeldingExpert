using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using WeldingExpert.Attributes;

namespace WeldingExpert.Models
{
    public class Welder
    {
        [Key]
        [Required]
        [SocialID]
        [Display(Name = "身份证号")]
        [StringLength(18, ErrorMessage = "{0}是18个字符", MinimumLength = 18)]
        public string SocialID { get; set; }

        [Required]
        [Display(Name = "姓名")]
        [StringLength(10, ErrorMessage = "{0}至少有{2}个字符", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "出生年份")]
        [Age(1900,2100)]
        public int BirthYear { get; set; }

        [Required]
        [Display(Name = "等级")]
        public int Level { get; set; }  // enum WelderLevel
    }
}