using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogEX.Data
{
    public partial class RazorPageBlogContext : DbContext
    {
        public RazorPageBlogContext()
        {
        }
        public RazorPageBlogContext(DbContextOptions<RazorPageBlogContext> options)
            : base(options)
        {
        }
   
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<TagCloud> TagCloud { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity => { entity.Property(e => e.Id).ValueGeneratedNever(); });

            modelBuilder.Entity<TagCloud>(entity => { entity.Property(e => e.Id).ValueGeneratedNever(); });

            //OnModelCreatingPartial(modelBuilder);
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}