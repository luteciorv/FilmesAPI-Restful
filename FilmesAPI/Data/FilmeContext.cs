using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opcoes) : base(opcoes)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
