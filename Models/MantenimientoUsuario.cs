using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgramaEgresadoSena.Models
{
    public class MantenimientoUsuario
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Alta(SE_Usuarios usu)//Inserta los elementos
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into SE_Usuarios(usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro)values(@usu_id,@usu_documento,@usu_tipodoc,@usu_nombre,@usu_celular,@usu_email,@usu_genero,@usu_aprendiz,@usu_egresado,@usu_areaformacion,@usu_fechaegresado,@usu_direccion,@usu_barrio,@usu_ciudad,@usu_departamento,@usu_fecharegistro)", con);

            //SqlDbType es para esepcificar que tipo de dato es en Sql Server.
            comando.Parameters.Add("@usu_id", SqlDbType.Int);
            comando.Parameters.Add("@usu_documento", SqlDbType.Int);
            comando.Parameters.Add("@usu_tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_celular", SqlDbType.Int);
            comando.Parameters.Add("@usu_email", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_genero", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_aprendiz", SqlDbType.Bit);
            comando.Parameters.Add("@usu_egresado", SqlDbType.Bit);
            comando.Parameters.Add("@usu_areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@usu_direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_fecharegistro", SqlDbType.Date);



            //lee y modifica los datos.
            comando.Parameters["@usu_id"].Value = usu.Usu_id;
            comando.Parameters["@usu_documento"].Value = usu.Usu_documento;
            comando.Parameters["@usu_tipodoc"].Value = usu.Usu_tipodoc;
            comando.Parameters["@usu_nombre"].Value = usu.Usu_nombre;
            comando.Parameters["@usu_celular"].Value = usu.Usu_celular;
            comando.Parameters["@usu_email"].Value = usu.Usu_email;
            comando.Parameters["@usu_genero"].Value = usu.Usu_genero;
            comando.Parameters["@usu_aprendiz"].Value = usu.Usu_aprendiz;
            comando.Parameters["@usu_egresado"].Value = usu.Usu_egresado;
            comando.Parameters["@usu_areaformacion"].Value = usu.Usu_areaformacion;
            comando.Parameters["@usu_fechaegresado"].Value = usu.Usu_fechaegresado;
            comando.Parameters["@usu_direccion"].Value = usu.Usu_direccion;
            comando.Parameters["@usu_barrio"].Value = usu.Usu_barrio;
            comando.Parameters["@usu_ciudad"].Value = usu.Usu_ciudad;
            comando.Parameters["@usu_departamento"].Value = usu.Usu_departamento;
            comando.Parameters["@usu_fecharegistro"].Value = usu.Usu_fecharegistro;


            //se abre la cadena
            con.Open();
            int i = comando.ExecuteNonQuery();//devuelve el numero de filas afectadas.
            con.Close();
            return i;
        }
        public List<SE_Usuarios> RecuperarTodos()//nos trae los articulos que estan en la base de datos.
        {
            Conectar();//abre la conexion.
            List<SE_Usuarios> usuarios = new List<SE_Usuarios>();
            SqlCommand com = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro from SE_Usuarios order by usu_id asc", con);

            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())//muestra los registros por linea, uno por uno.
            {
                SE_Usuarios usu= new SE_Usuarios
                {
                    Usu_id = int.Parse(registros["usu_id"].ToString()),
                    Usu_documento = int.Parse(registros["usu_documento"].ToString()),
                    Usu_tipodoc = registros["usu_tipodoc"].ToString(),
                    Usu_nombre = registros["usu_nombre"].ToString(),
                    Usu_celular = int.Parse(registros["usu_celular"].ToString()),
                    Usu_email = registros["usu_email"].ToString(),
                    Usu_genero = registros["usu_genero"].ToString(),
                    Usu_aprendiz = bool.Parse(registros["usu_aprendiz"].ToString()),
                    Usu_egresado = bool.Parse(registros["usu_egresado"].ToString()),
                    Usu_areaformacion =registros["usu_areaformacion"].ToString(),
                    Usu_fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString()),
                    Usu_direccion = registros["usu_direccion"].ToString(),
                    Usu_barrio = registros["usu_barrio"].ToString(),
                    Usu_ciudad = registros["usu_ciudad"].ToString(),
                    Usu_departamento = registros["usu_departamento"].ToString(),
                    Usu_fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString())


                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }
        public SE_Usuarios Recuperardocumento(int usu_documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro from SE_Usuarios where usu_documento=@usu_documento", con);//consulta en la base de datos.
            comando.Parameters.Add("@usu_documento", SqlDbType.Int);
            comando.Parameters["@usu_documento"].Value = usu_documento;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();//trae cuantas lineas se guardo o afecto y ejecuta la sentencia.
            SE_Usuarios usuario = new SE_Usuarios();

            if (registros.Read())
            {
                //trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.
                usuario.Usu_id= int.Parse(registros["usu_id"].ToString());
                usuario.Usu_documento = int.Parse(registros["usu_documento"].ToString());
                usuario.Usu_tipodoc = registros["usu_tipodoc"].ToString();
                usuario.Usu_nombre = registros["usu_nombre"].ToString();
                usuario.Usu_celular = int.Parse(registros["usu_celular"].ToString());
                usuario.Usu_email = registros["usu_email"].ToString();
                usuario.Usu_genero = registros["usu_genero"].ToString();
                usuario.Usu_aprendiz = bool.Parse(registros["usu_aprendiz"].ToString());
                usuario.Usu_egresado = bool.Parse(registros["usu_egresado"].ToString());
                usuario.Usu_areaformacion = registros["usu_areaformacion"].ToString();
                usuario.Usu_fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.Usu_direccion = registros["usu_direccion"].ToString();
                usuario.Usu_barrio = registros["usu_barrio"].ToString();
                usuario.Usu_ciudad = registros["usu_ciudad"].ToString();
                usuario.Usu_departamento = registros["usu_departamento"].ToString();
                usuario.Usu_fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString());

            }
            else
               usuario = null;
               con.Close();
               return usuario;
        }
        public SE_Usuarios Recuperarareaformacion(string usu_areaformacion)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro from SE_Usuarios where usu_areaformacion=@usu_areaformacion", con);//consulta en la base de datos.
            comando.Parameters.Add("@usu_areaformacion", SqlDbType.VarChar);
            comando.Parameters["@usu_areaformacion"].Value =usu_areaformacion;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();//trae cuantas lineas se guardo o afecto y ejecuta la sentencia.
            SE_Usuarios usuario = new SE_Usuarios();

            if (registros.Read())
            {
                //trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.
                usuario.Usu_id = int.Parse(registros["usu_id"].ToString());
                usuario.Usu_documento = int.Parse(registros["usu_documento"].ToString());
                usuario.Usu_tipodoc = registros["usu_tipodoc"].ToString();
                usuario.Usu_nombre = registros["usu_nombre"].ToString();
                usuario.Usu_celular = int.Parse(registros["usu_celular"].ToString());
                usuario.Usu_email = registros["usu_email"].ToString();
                usuario.Usu_genero = registros["usu_genero"].ToString();
                usuario.Usu_aprendiz = bool.Parse(registros["usu_aprendiz"].ToString());
                usuario.Usu_egresado = bool.Parse(registros["usu_egresado"].ToString());
                usuario.Usu_areaformacion = registros["usu_areaformacion"].ToString();
                usuario.Usu_fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.Usu_direccion = registros["usu_direccion"].ToString();
                usuario.Usu_barrio = registros["usu_barrio"].ToString();
                usuario.Usu_ciudad = registros["usu_ciudad"].ToString();
                usuario.Usu_departamento = registros["usu_departamento"].ToString();
                usuario.Usu_fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString());

            }
            else
                usuario = null;
            con.Close();
            return usuario;
        }
        public SE_Usuarios Recuperargenero(string usu_genero)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro from SE_Usuarios where usu_genero=@usu_genero", con);//consulta en la base de datos.
            comando.Parameters.Add("@usu_genero", SqlDbType.VarChar);
            comando.Parameters["@usu_genero"].Value = usu_genero;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();//trae cuantas lineas se guardo o afecto y ejecuta la sentencia.
            SE_Usuarios usuario = new SE_Usuarios();

            if (registros.Read())
            {
                //trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.
                usuario.Usu_id = int.Parse(registros["usu_id"].ToString());
                usuario.Usu_documento = int.Parse(registros["usu_documento"].ToString());
                usuario.Usu_tipodoc = registros["usu_tipodoc"].ToString();
                usuario.Usu_nombre = registros["usu_nombre"].ToString();
                usuario.Usu_celular = int.Parse(registros["usu_celular"].ToString());
                usuario.Usu_email = registros["usu_email"].ToString();
                usuario.Usu_genero = registros["usu_genero"].ToString();
                usuario.Usu_aprendiz = bool.Parse(registros["usu_aprendiz"].ToString());
                usuario.Usu_egresado = bool.Parse(registros["usu_egresado"].ToString());
                usuario.Usu_areaformacion = registros["usu_areaformacion"].ToString();
                usuario.Usu_fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.Usu_direccion = registros["usu_direccion"].ToString();
                usuario.Usu_barrio = registros["usu_barrio"].ToString();
                usuario.Usu_ciudad = registros["usu_ciudad"].ToString();
                usuario.Usu_departamento = registros["usu_departamento"].ToString();
                usuario.Usu_fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString());

            }
            else
                usuario = null;
            con.Close();
            return usuario;
        }
        public int Modificar(SE_Usuarios usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update SE_Usuarios set usu_tipodoc=@usu_tipodoc,usu_nombre=@usu_nombre,usu_celular=@usu_celular,usu_email=@usu_email,usu_genero=@usu_genero,usu_aprendiz=@usu_aprendiz,usu_egresado=@usu_egresado,usu_areaformacion=@usu_areaformacion,usu_fechaegresado=@usu_fechaegresado,usu_direccion=@usu_direccion,usu_barrio=@usu_barrio,usu_ciudad=@usu_ciudad,usu_departamento=@usu_departamento,usu_fecharegistro=@usu_fecharegistro where usu_documento=@usu_documento", con);

            comando.Parameters.Add("@usu_tipodoc", SqlDbType.VarChar);
            comando.Parameters["@usu_tipodoc"].Value = usu.Usu_tipodoc;

            comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
            comando.Parameters["@usu_nombre"].Value = usu.Usu_nombre;

            comando.Parameters.Add("@usu_celular", SqlDbType.Int);
            comando.Parameters["@usu_celular"].Value = usu.Usu_celular;

            comando.Parameters.Add("@usu_email", SqlDbType.VarChar);
            comando.Parameters["@usu_email"].Value = usu.Usu_email;

            comando.Parameters.Add("@usu_genero", SqlDbType.VarChar);
            comando.Parameters["@usu_genero"].Value = usu.Usu_genero;

            comando.Parameters.Add("@usu_aprendiz", SqlDbType.Bit);
            comando.Parameters["@usu_aprendiz"].Value = usu.Usu_aprendiz;

            comando.Parameters.Add("@usu_egresado", SqlDbType.Bit);
            comando.Parameters["@usu_egresado"].Value = usu.Usu_egresado;

            comando.Parameters.Add("@usu_areaformacion", SqlDbType.VarChar);
            comando.Parameters["@usu_areaformacion"].Value = usu.Usu_areaformacion;

            comando.Parameters.Add("@usu_fechaegresado", SqlDbType.DateTime);
            comando.Parameters["@usu_fechaegresado"].Value = usu.Usu_fechaegresado;

            comando.Parameters.Add("@usu_direccion", SqlDbType.VarChar);
            comando.Parameters["@usu_direccion"].Value = usu.Usu_direccion;

            comando.Parameters.Add("@usu_barrio", SqlDbType.VarChar);
            comando.Parameters["@usu_barrio"].Value = usu.Usu_barrio;

            comando.Parameters.Add("@usu_ciudad", SqlDbType.VarChar);
            comando.Parameters["@usu_ciudad"].Value = usu.Usu_ciudad;

            comando.Parameters.Add("@usu_departamento", SqlDbType.VarChar);
            comando.Parameters["@usu_departamento"].Value = usu.Usu_departamento;

            comando.Parameters.Add("@usu_fecharegistro", SqlDbType.DateTime);
            comando.Parameters["@usu_fecharegistro"].Value = usu.Usu_fecharegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int usu_id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from SE_Usuarios where usu_id=@usu_id", con);
            comando.Parameters.Add("@usu_id", SqlDbType.Int);
            comando.Parameters["@usu_id"].Value = usu_id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}