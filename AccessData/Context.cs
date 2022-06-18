using Domain;
using Microsoft.EntityFrameworkCore;
namespace AccesData
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Alquileres> Alquileres { get; set; }
        public DbSet<EstadoDeAlquileres> EstadoDeAlquileres { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=RODRIGONOTEBOOK\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(c => c.ClienteID);
                entity.Property(c => c.DNI).HasMaxLength(10).HasColumnName("DNI").IsRequired();
                entity.Property(c => c.Nombre).HasMaxLength(45).HasColumnName("Nombre").IsRequired();
                entity.Property(c => c.Apellido).HasMaxLength(45).HasColumnName("Apellido").IsRequired();
                entity.Property(c => c.Email).HasMaxLength(45).HasColumnName("Email").IsRequired();

            });

            modelBuilder.Entity<Alquileres>(entity =>
            {
                entity.ToTable("Alquileres");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cliente_idx).HasColumnName("Cliente").IsRequired();
                entity.Property(e => e.Libros_idx).HasColumnName("ISBN").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Estado_idx).HasColumnName("Estado").IsRequired();

                entity.Property(e => e.FechaAlquiler).HasColumnName("FechaAlquiler").IsRequired(false);
                entity.Property(e => e.FechaReserva).HasColumnName("FechaReserva").IsRequired(false);
                entity.Property(e => e.FechaDevolucion).HasColumnName("FechaDevolucion").IsRequired(false);

                entity.HasOne(x => x.Cliente)
                    .WithMany(a => a.Alquileres)
                    .HasForeignKey(x => x.Cliente_idx);

                entity.HasOne(x => x.Estado)
                    .WithMany(a => a.Alquileres)
                    .HasForeignKey(x => x.Estado_idx);

                entity.HasOne(x => x.Libros)
                    .WithMany(p => p.Alquileres)
                    .HasForeignKey(x => x.Libros_idx);

            });


            modelBuilder.Entity<Libros>(entity =>
            {
                entity.ToTable("Libros");
                entity.HasAlternateKey(e => e.ISBN);
                entity.Property(e => e.ISBN).HasMaxLength(50).HasColumnName("ISBN").IsRequired();
                entity.Property(e => e.Titulo).HasMaxLength(45).HasColumnName("Titulo").IsRequired();
                entity.Property(e => e.Autor).HasMaxLength(45).HasColumnName("Autor").IsRequired();
                entity.Property(e => e.Editorial).HasMaxLength(45).HasColumnName("Editorial").IsRequired();
                entity.Property(e => e.Edicion).HasMaxLength(45).HasColumnName("Edicion").IsRequired();
                entity.Property(e => e.Stock).HasColumnName("Stock").IsRequired(false);
                entity.Property(e => e.Imagen).HasMaxLength(45).HasColumnName("Imagen").IsRequired();
            });

            modelBuilder.Entity<EstadoDeAlquileres>(entity =>
            {
                entity.HasKey(e => e.EstadoId);
                entity.Property(e => e.Descripcion).HasColumnName("Descripcion").HasMaxLength(45).IsRequired();
            });



            modelBuilder.Entity<Libros>().HasData(
                new Libros
                {
                    ISBN = "8445071866",
                    Titulo = "Casa Tomada",
                    Autor = "Cortazar",
                    Editorial = "Ediciones Minotauro",
                    Edicion = "1995",
                    Stock = 10,
                    Imagen = "https://picture/sdfdf.jpg",
                },
                new Libros
                {
                    ISBN = "9789877252538",
                    Titulo = "Rayuela",
                    Autor = "Cortazar",
                    Editorial = "DEBOLSILLO",
                    Edicion = "2019",
                    Stock = 10,
                    Imagen = "https://ed77b8615c4e99183f6da2.jpg",
                },
                new Libros
                {
                    ISBN = "9789875666474",
                    Titulo = "Ficciones",
                    Autor = "Borges",
                    Editorial = "DEBOLSILLO",
                    Edicion = "2011",
                    Stock = 10,
                    Imagen = "https://contentv2/974_1.jpg?id_com=1113",
                },
                new Libros
                {
                    ISBN = "9783150197882",
                    Titulo = "La biblioteca de Babel",
                    Autor = "Borges",
                    Editorial = "Emece",
                    Edicion = "2000",
                    Stock = 10,
                    Imagen = "https://isbn/9789500421300-es-300.jpg",
                },
                new Libros
                {
                    ISBN = "9786124507724",
                    Titulo = "El túnel",
                    Autor = "Sabato",
                    Editorial = "Booket",
                    Edicion = "1",
                    Stock = 10,
                    Imagen = "https://images/b564d07e519e687f9d51e4.jpg",
                },
                new Libros
                {
                    ISBN = "9789878317748",
                    Titulo = "La resistencia",
                    Autor = "Sabato",
                    Editorial = "Booket",
                    Edicion = "2021",
                    Stock = 10,
                    Imagen = "https://contentv2/917748_1.jpg?id_com=1113",
                },
                new Libros
                {
                    ISBN = "978-84-206-7273-1",
                    Titulo = "La invención de Morel",
                    Autor = "Bioy Casares",
                    Editorial = "Alianza Editorial",
                    Edicion = "2022",
                    Stock = 10,
                    Imagen = "https://static.cegal/9788420/9067273.gif",
                },
                new Libros
                {
                    ISBN = "9788420673615",
                    Titulo = "El sueño de los héroes",
                    Autor = "Bioy Casares",
                    Editorial = "Alianza Editorial",
                    Edicion = "2012",
                    Stock = 10,
                    Imagen = "https://imagessl5/9788420673615.jpg",
                },
                new Libros
                {
                    ISBN = "9789875802957",
                    Titulo = "20 Poemas De Amor Y Una Cancion Des",
                    Autor = "Neruda",
                    Editorial = "Cuspide",
                    Edicion = "2008",
                    Stock = 10,
                    Imagen = "https://9789875802957_1.jpg?id_com=1113",
                },
                new Libros
                {
                    ISBN = "9788432248450",
                    Titulo = "Cien Sonetos de Amor",
                    Autor = "Neruda",
                    Editorial = "Austral",
                    Edicion = "2012",
                    Stock = 10,
                    Imagen = "https://images.bba75516df65156022bb.jpg",
                }
            );

            modelBuilder.Entity<EstadoDeAlquileres>().HasData(
                new EstadoDeAlquileres
                {
                    EstadoId = 1,
                    Descripcion = "Reservado"
                },
                new EstadoDeAlquileres
                {
                    EstadoId = 2,
                    Descripcion = "Alquilado"
                },
                new EstadoDeAlquileres
                {
                    EstadoId = 3,
                    Descripcion = "Cancelado"
                });

        }

    }
}