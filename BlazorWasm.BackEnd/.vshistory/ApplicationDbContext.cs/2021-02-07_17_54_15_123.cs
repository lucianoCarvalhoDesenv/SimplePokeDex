﻿using BlazorMovies.Base.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlazorMovies.Server
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext() : base()
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<LivroCategoria>().HasKey(x => new {  x.LivroID, x.CategoriaID });
            modelBuilder.Entity<LivroPessoa>().HasKey(x => new { x.LivroID, x.PessoaID });
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<LivroCategoria> LivroCategorias { get; set; }
        public DbSet<LivroPessoa> LivroPessoas { get; set; }


    }
}
