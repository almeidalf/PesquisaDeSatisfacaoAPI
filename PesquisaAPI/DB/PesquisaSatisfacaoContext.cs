using Microsoft.EntityFrameworkCore;
using PesquisaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaAPI.DB
{
    public class PesquisaSatisfacaoContext : DbContext
    {
        public PesquisaSatisfacaoContext(DbContextOptions<PesquisaSatisfacaoContext> options) : base(options)
        { 
        }

        public DbSet<Perguntas> Pesquisa { get; set; }
        public DbSet<InformacoesRespostas> Informacoes { get; set; }
        public DbSet<Respostas> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Perguntas>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<InformacoesRespostas>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Respostas>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
