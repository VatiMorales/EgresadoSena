using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramaEgresadoSena.Models
{
    public class SE_Usuarios
    {
        public int usu_id { get; set; }
        public int usu_documento { get; set; }
        public string usu_tipodoc { get; set; }
        public string usu_nombre { get; set; }
        public int usu_celular { get; set; }
        public string usu_email { get; set; }
        public string usu_genero{ get; set; }
        public bool usu_aprendiz { get; set; }
        public bool usu_egresado { get; set; }
        public string usu_areaformacion { get; set; }
        public DateTime usu_fechaegresado { get; set; }
        public string usu_direccion { get; set; }
        public string usu_barrio { get; set; }
        public string usu_ciudad { get; set; }
        public string usu_departamento { get; set; }
        public DateTime usu_fecharegistro { get; set; }

    }
}