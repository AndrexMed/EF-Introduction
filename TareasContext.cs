using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroEF.Modelos;
using Microsoft.EntityFrameworkCore;

namespace IntroEF
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias{ get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) :base(options)
        {

        }

        //Mapeando - Fluent API - No need DataAnotations
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Categoria>(categoria => {
                categoria.ToTable("Categoria");
                categoria.HasKey(c => c.CategoriaId);
                categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(c => c.Descripcion);
                categoria.Property(c => c.Peso);

            });

            modelbuilder.Entity<Tarea>(tarea => 
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.TareaId);

                tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);

                tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t => t.Descripcion);
                tarea.Property(t => t.PrioridadTarea);
                tarea.Property(t => t.FechaCreacion);

                tarea.Ignore(t => t.Resumen);
            });
        }
    }
}