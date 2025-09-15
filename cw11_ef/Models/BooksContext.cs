using System;
using Microsoft.EntityFrameworkCore;

namespace cw11_ef.Models;

public class BooksContext : DbContext
{
    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    { }
    public DbSet<Book> Books { get; set; }
    public DbSet<Editor> Editors { get; set; }
    //dodanie startowych danych
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //dodanie startowych danych
        modelBuilder.Entity<Book>()
            .HasOne(e => e.Editor)
            .WithMany(e => e.Books)
            .HasForeignKey(e => e.EditorId)
            .IsRequired();

        modelBuilder.Entity<Editor>()
            .HasMany(e => e.Books)
            .WithOne(e => e.Editor)
            .HasForeignKey(e => e.EditorId)
            .IsRequired();
    }
}