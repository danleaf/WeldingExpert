using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WeldingExpert.Models
{
    public class ParentMetalClass
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "牌号")]
        public string Grade { get; set; }

        [Required]
        [Display(Name="类别")]
        public string Type { get; set; }

        [Display(Name = "组别")]
        public string Group { get; set; }

        public List<Standard> Standards { get; set; }
    }

    public class Standard
    {
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        public List<ParentMetalClass> ParentMetalClasses { get; set; }
    }

 #region nouse
    /*
    public class ParentMetalClassStandard
    {
        public int ParentMetalClassID { get; set; }
        public int StandardID { get; set; }

        public ParentMetalClass ParentMetalClass { get; set; }
        public Standard Standard { get; set; }

        public static void Configure(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ParentMetalClassStandard>();

            entity.HasKey(o => new { o.ParentMetalClassID, o.StandardID });
            entity.HasRequired(o => o.ParentMetalClass).WithMany(o => o.ParentMetalClassStandards).HasForeignKey(o => o.ParentMetalClassID);
            entity.HasRequired(o => o.Standard).WithMany(o => o.ParentMetalClassStandards).HasForeignKey(o => o.StandardID);
        }
    }*/
 #endregion
}