using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroEF.Modelos
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }

        public string Nombre { get; set; }	

        public string Descripcion { get; set; }

        public virtual ICollection<Tarea> Tareas{ get; set; }
    }
}