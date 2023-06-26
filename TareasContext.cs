using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using IntroEF.Modelos;
using Microsoft.EntityFrameworkCore;

namespace IntroEF
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        // public DbSet<Tarifa> tarifas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {

        }

        //Mapeando - Fluent API - No need DataAnotations
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("0ca6d57a-9817-4a6c-a80f-af672816a57f"), Nombre = "Actividades Pendientes", Peso = 20 });
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5b080b9d-e620-4e11-9b9f-5ca932ff5fe3"), Nombre = "Actividades Pendientes", Peso = 30 });

            modelbuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(c => c.CategoriaId);
                categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(c => c.Descripcion).IsRequired(false);
                categoria.Property(c => c.Peso);

                categoria.HasData(categoriasInit);

            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("402606b1-801e-4e3c-bc74-257f6fb73009"), CategoriaId = Guid.Parse("0ca6d57a-9817-4a6c-a80f-af672816a57f"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de Servicios Publicos", FechaCreacion = DateTime.Now });
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("c2aeeb3d-8037-4cda-9e46-8edbd10196cc"), CategoriaId = Guid.Parse("5b080b9d-e620-4e11-9b9f-5ca932ff5fe3"), PrioridadTarea = Prioridad.Baja, Titulo = "Termina Cursos Platzi", FechaCreacion = DateTime.Now });


            modelbuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.TareaId);

                tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);

                tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t => t.Descripcion).IsRequired(false);
                tarea.Property(t => t.PrioridadTarea);
                tarea.Property(t => t.FechaCreacion);

                tarea.Ignore(t => t.Resumen);

                tarea.Property(t => t.pruebaMigration).IsRequired(false);

                tarea.HasData(tareasInit);
            });


            // List<Tarifa> tarifas = new List<Tarifa>();

            // modelbuilder.Entity<Tarifa>(tarifa =>
            // {
            //     tarifa.ToTable("Tarifa");
            //     tarifa.HasKey(t => t.CodigoPrograma);
            //     tarifa.Property(t => t.ValorSemestre);
            //     tarifa.Property(t => t.Nivel);
            //     tarifa.Property(t => t.Periodo);
            //     tarifa.Property(t => t.Año);
            // });
        }
    }
}