using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramaEgresadoSena.Models
{
    public class SE_Usuarios
    {
        public int id { get; set; }
        public int documento { get; set; }
        public string tipodoc { get; set; }
        public string nombre { get; set; }
        public int celular { get; set; }
        public string email { get; set; }
        public string genero{ get; set; }
        public string aprendiz { get; set; }
        public string egresado { get; set; }
        public string areaformacion { get; set; }
        public DateTime fecha_egresado { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public DateTime fecha_registro { get; set; }

    }
}