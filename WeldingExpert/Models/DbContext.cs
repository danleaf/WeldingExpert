using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WeldingExpert.Models
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Welder> Welders { get; set; }
        public DbSet<WeldingMaterial> WeldingMaterials { get; set; }
        public DbSet<ParentMetalClass> ParentMetalClasses { get; set; }
        public DbSet<Standard> Standards { get; set; }

        public DbContext()
            : base("WeldingExpertContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    public class DBInitializer : DropCreateDatabaseAlways<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            context.Welders.Add(new Welder { SocialID = "123456789012345677", Name = "Joe Tang", BirthYear = 1990, Level = 5 });
            context.Users.Add(new User { UserName = "admin", Password = "admin", Role = (int)UserRoleEnum.Admin, RealName = "叶丹", WorkerID = 1 });
            context.WeldingMaterials.Add(new WeldingMaterial() { Type = "E316L", Standard = 2.0, TransNo = "15-S-16", ReviewReportNo = "R101" });

            var pmc1 = new ParentMetalClass { Type = "Fe-1", Group = "Fe-1-1", Grade = "Q345R" };
            var pmc2 = new ParentMetalClass { Type = "Fe-2", Group = "Fe-2-1", Grade = "Q543R" };
            var pmc3 = new ParentMetalClass { Type = "Fe-3", Group = "Fe-3-1", Grade = "Q753R" };

            var s1 = new Standard { Code = "GB/T2054", Description = "ll" };
            var s2 = new Standard { Code = "GB/T2882", Description = "mm" };
            var s3 = new Standard { Code = "GB/T4741", Description = "nn" };

            pmc1.Standards = new List<Standard> { s1, s2, s3 };
            pmc2.Standards = new List<Standard> { s2, s3 };
            pmc3.Standards = new List<Standard> { s1, s2 };

            context.ParentMetalClasses.Add(pmc1);
            context.ParentMetalClasses.Add(pmc2);
            context.ParentMetalClasses.Add(pmc3);

            context.Standards.Add(s1);
            context.Standards.Add(s2);
            context.Standards.Add(s3);

            base.Seed(context);
        }
    }
}