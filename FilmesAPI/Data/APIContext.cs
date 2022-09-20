using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> opcoes) : base(opcoes)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(E => E.Cinema)
                .WithOne(C => C.Endereco)
                .HasForeignKey<Cinema>(C => C.EnderecoID);

            builder.Entity<Cinema>()
                .HasOne(C => C.Gerente)
                .WithMany(G => G.Cinemas)
                .HasForeignKey(C => C.GerenteID);


            builder.Entity<Sessao>()
                .HasOne(S => S.Filme)
                .WithMany(F => F.Sessoes)
                .HasForeignKey(S => S.FilmeID);

            builder.Entity<Sessao>()
                .HasOne(S => S.Cinema)
                .WithMany(C => C.Sessoes)
                .HasForeignKey(S => S.CinemaID); ;
        }


        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }

        public DbSet<Sessao> Sessoes { get; set; }
    }
}