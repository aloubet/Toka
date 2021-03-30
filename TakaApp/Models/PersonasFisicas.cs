using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakaApp.Models
{
    public class PersonasFisicas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Direccion { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreador { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModifica { get; set; }
    }
}
