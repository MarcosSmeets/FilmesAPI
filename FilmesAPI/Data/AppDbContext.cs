using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EnderecoModel>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<CinemaModel>(cinema => cinema.EnderecoId);

            builder.Entity<CinemaModel>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinema)
                .HasForeignKey(cinema => cinema.GerenteId);
        }

        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<CinemaModel> Cinemas { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<GerenteModel> Gerentes { get; set; }
    }
}
