using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramaEgresadoSena.Models
{
    public class SE_Usuarios
    {
        public int Usu_id { get; set; }
        public int Usu_documento { get; set; }
        public string Usu_tipodoc { get; set; }
        public string Usu_nombre { get; set; }
        public int Usu_celular { get; set; }
        public string Usu_email { get; set; }
        public string Usu_genero{ get; set; }
        public bool Usu_aprendiz { get; set; }
        public bool Usu_egresado { get; set; }
        public string Usu_areaformacion { get; set; }
        public DateTime Usu_fechaegresado { get; set; }
        public string Usu_direccion { get; set; }
        public string Usu_barrio { get; set; }
        public string Usu_ciudad { get; set; }
        public string Usu_departamento { get; set; }
        public DateTime Usu_fecharegistro { get; set; }

    }
}