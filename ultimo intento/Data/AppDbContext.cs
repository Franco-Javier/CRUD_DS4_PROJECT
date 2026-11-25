using ultimo_intento.Models;
using Microsoft.EntityFrameworkCore;

namespace ultimo_intento.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> People { get; set; }

}