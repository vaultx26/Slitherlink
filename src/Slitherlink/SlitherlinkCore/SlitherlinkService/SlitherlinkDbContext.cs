using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;

namespace Slitherlink.SlitherlinkCore.SlitherlinkService
{
    public class SlitherlinkDbContext : DbContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DbSet<Score> Scores { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Hodnotenie> Hodnotenies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Slitherlink;Trusted_Connection=True;");
        }
    }
}
