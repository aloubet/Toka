﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakaApp.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreador { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModifica { get; set; }
    }
}
