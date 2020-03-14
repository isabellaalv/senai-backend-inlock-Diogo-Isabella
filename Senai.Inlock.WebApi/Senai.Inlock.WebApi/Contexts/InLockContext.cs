using Microsoft.EntityFrameworkCore;
using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Contexts
{
    public class InLockContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Jogo> Jogos { get; set; }

        public InLockContext()
        {

        }

        //**
        //OBS IMPORTANTE: Necessário OnConfiguring na classe CONTEXT caso CRUD seja feito "na mão", sem ajuda de padrão repositório ou UnitOfWork
        //**
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; initial catalog=InLock_Tarde; Integrated Security=True");
                optionsBuilder.UseSqlServer("Data Source=DEV1\\SQLEXPRESS; initial catalog=InLock_Tarde; user Id=sa; pwd=sa@132;");
            }
        }
        //**
        public InLockContext(DbContextOptions<InLockContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>(e =>
            {
                e.Property(x => x.Id).IsRequired();
                e.HasIndex(x => x.Id);
            });

            modelBuilder.Entity<Estudio>(e =>
            {
                e.Property(x => x.Id).IsRequired();
                e.HasIndex(x => x.Id);
            });

            modelBuilder.Entity<Usuario>(e =>
            {
                e.Property(x => x.Id).IsRequired();
                e.HasIndex(x => x.Id);

                e.HasOne<TipoUsuario>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("TipoUsuarioId");
            });

            modelBuilder.Entity<Jogo>(e =>
            {
                e.Property(x => x.Id).IsRequired();
                e.HasIndex(x => x.Id);

                e.HasOne<Estudio>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("EstudioId");
            });
        }
    }
}
