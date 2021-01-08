using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }
        public int Monto { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_matricula{ get; set; }
        public bool Nuevo { get; set; }
        public string Estado { get; set; }

     
    }
}
