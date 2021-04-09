using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace khachhang.Models
{
    public partial class khachhangDbContext : DbContext
    {
        public khachhangDbContext()
            : base("name=khachhangDbContext")
        {
        }

        public virtual DbSet<KH> Khachhang { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
