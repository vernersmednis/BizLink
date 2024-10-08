using System;
using System.Collections.Generic;
using BizLinkk.Models;
using Microsoft.EntityFrameworkCore;

namespace BizLinkk.Data;

public partial class PrakseContext : DbContext
{
    public PrakseContext()
    {
    }

    public PrakseContext(DbContextOptions<PrakseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=demo.ozols.lv;Database=Prakse;User Id=Praktikants;Password=Praks@sUzd@vum$;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.ToTable(tb =>
                {
                    tb.HasTrigger("RC_Partners");
                    tb.HasTrigger("tr_partners_slg");
                });

            entity.Property(e => e.Rcoc).HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.Rcoe).HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.Rctc).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Rcte).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegistrationNo).HasDefaultValue("");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
