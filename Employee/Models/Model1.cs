using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Employee.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<send1> send1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<send1>()
                .Property(e => e.EmpNane)
                .IsUnicode(false);

            modelBuilder.Entity<send1>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<send1>()
                .Property(e => e.Report_To)
                .IsUnicode(false);

            modelBuilder.Entity<send1>()
                .Property(e => e.Resigned)
                .IsUnicode(false);
        }
    }
}
