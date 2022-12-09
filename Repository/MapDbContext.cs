using System;
using System.Collections.Generic;
using ApiMap.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMap.Repository;

public partial class MapDbContext : DbContext
{
    public MapDbContext()
    {
    }

    public MapDbContext(DbContextOptions<MapDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mapaddress> Mapaddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
