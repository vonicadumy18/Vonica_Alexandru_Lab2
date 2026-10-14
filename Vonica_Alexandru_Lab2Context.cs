using Microsoft.EntityFrameworkCore;
using Vonica_Alexandru_Lab2.Models;

public class Vonica_Alexandru_Lab2Context : DbContext
{
    public Vonica_Alexandru_Lab2Context(DbContextOptions<Vonica_Alexandru_Lab2Context> options)
        : base(options)
    {
    }

    public DbSet<Vonica_Alexandru_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Vonica_Alexandru_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Vonica_Alexandru_Lab2.Models.Author> Author { get; set; } = default!;
}