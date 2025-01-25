using Microsoft.EntityFrameworkCore;
using EvenimenteSportive.Models;

public class EvenimenteContext : DbContext
{
    public EvenimenteContext(DbContextOptions<EvenimenteContext> options)
        : base(options)
    {
    }

    public DbSet<EvenimentSportiv> EvenimenteSportive { get; set; }
    public DbSet<Locatie> Locatii { get; set; }
    public DbSet<Participant> Participanti { get; set; }
    public DbSet<Sponsor> Sponsori { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvenimentSportiv>()
            .HasOne(e => e.Locatie)
            .WithMany()
            .HasForeignKey(e => e.IDLocatie)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Participant>()
            .HasOne(p => p.EvenimentSportiv)
            .WithMany(e => e.Participanti)
            .HasForeignKey(p => p.IDEveniment);

        modelBuilder.Entity<Sponsor>()
            .HasOne(s => s.EvenimentSportiv)
            .WithMany(e => e.Sponsori)
            .HasForeignKey(s => s.IDEveniment);
    }
}
