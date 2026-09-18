using CodeFirstFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstFilmes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Representa a tabela de diretores
        public DbSet<Diretor> Diretores => Set<Diretor>();

        // Representa a tabela de filmes
        public DbSet<Filme> Filmes => Set<Filme>();

        // Representa a tabela de generos
        public DbSet<Genero> Generos => Set<Genero>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            // Configura os relacionamentos entre as entidades
            // Configura o relacionamento 1:N entre diretor e filmes
            modelBuilder.Entity<Diretor>()
                .HasMany(d => d.Filmes)
                .WithOne(f => f.Diretor)
                .HasForeignKey(f => f.DiretorId);

            modelBuilder.Entity<Filme>()
                .HasMany(f => f.Generos)
                .WithMany(g => g.Filmes);
        }


    }
}
