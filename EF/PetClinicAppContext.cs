using Microsoft.EntityFrameworkCore;
using PetClinicApp.Entities;

namespace PetClinicApp.EF;

public class PetClinicAppContext : DbContext
{
    private readonly string connString;

    public DbSet<Pet> Pets { get; set; }

    public PetClinicAppContext(string connString) => this.connString = connString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connString);
}
