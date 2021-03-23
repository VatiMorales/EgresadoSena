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
            SqlCommand comando = new SqlCommand("insert into SE_Usuarios(usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro)values(@documento,@tipodoc,@nombre,@celular,@email,@genero,@aprendiz,@egresado,@areaformacion,@fechaegresado,@direccion,@barrio,@ciudad,@departamento,@fecharegistro)", con);

            //SqlDbType es para esepcificar que tipo de dato es en Sql Server.
            
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);



            //lee y modifica los datos.

            comando.Parameters["@documento"].Value = usu.documento;
            comando.Parameters["@tipodoc"].Value = usu.tipodoc;
            comando.Parameters["@nombre"].Value = usu.nombre;
            comando.Parameters["@celular"].Value = usu.celular;
            comando.Parameters["@email"].Value = usu.email;
            comando.Parameters["@genero"].Value = usu.genero;
            comando.Parameters["@aprendiz"].Value = usu.aprendiz;
            comando.Parameters["@egresado"].Value = usu.egresado;
            comando.Parameters["@areaformacion"].Value = usu.areaformacion;
            comando.Parameters["@fechaegresado"].Value = usu.fecha_egresado;
            comando.Parameters["@direccion"].Value = usu.direccion;
            comando.Parameters["@barrio"].Value = usu.barrio;
            comando.Parameters["@ciudad"].Value = usu.ciudad;
            comando.Parameters["@departamento"].Value = usu.departamento;
            comando.Parameters["@fecharegistro"].Value = usu.fecha_registro;


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
                    id = int.Parse(registros["usu_id"].ToString()),
                    documento = int.Parse(registros["usu_documento"].ToString()),
                    tipodoc = registros["usu_tipodoc"].ToString(),
                    nombre = registros["usu_nombre"].ToString(),
                    celular = int.Parse(registros["usu_celular"].ToString()),
                    email = registros["usu_email"].ToString(),
                    genero = registros["usu_genero"].ToString(),
                    aprendiz = registros["usu_aprendiz"].ToString(),
                    egresado = registros["usu_egresado"].ToString(),
                    areaformacion =registros["usu_areaformacion"].ToString(),
                    fecha_egresado = DateTime.Parse(registros["usu_fechaegresado"].ToString()),
                    direccion = registros["usu_direccion"].ToString(),
                    barrio = registros["usu_barrio"].ToString(),
                    ciudad = registros["usu_ciudad"].ToString(),
                    departamento = registros["usu_departamento"].ToString(),
                    fecha_registro = DateTime.Parse(registros["usu_fecharegistro"].ToString())


                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }
        public SE_Usuarios Recuperardocumento(int documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro from SE_Usuarios where usu_documento=@documento", con);//consulta en la base de datos.
            comando.Parameters.Add("@usu_documento", SqlDbType.Int);
            comando.Parameters["@usu_documento"].Value = documento;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();//trae cuantas lineas se guardo o afecto y ejecuta la sentencia.
            SE_Usuarios usuario = new SE_Usuarios();

            if (registros.Read())
            {
                //trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.
                usuario.id= int.Parse(registros["usu_id"].ToString());
                usuario.documento = int.Parse(registros["usu_documento"].ToString());
                usuario.tipodoc = registros["usu_tipodoc"].ToString();
                usuario.nombre = registros["usu_nombre"].ToString();
                usuario.celular = int.Parse(registros["usu_celular"].ToString());
                usuario.email = registros["usu_email"].ToString();
                usuario.genero = registros["usu_genero"].ToString();
                usuario.aprendiz = registros["usu_aprendiz"].ToString();
                usuario.egresado = registros["usu_egresado"].ToString();
                usuario.areaformacion = registros["usu_areaformacion"].ToString();
                usuario.fecha_egresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.direccion = registros["usu_direccion"].ToString();
                usuario.barrio = registros["usu_barrio"].ToString();
                usuario.ciudad = registros["usu_ciudad"].ToString();
                usuario.departamento = registros["usu_departamento"].ToString();
                usuario.fecha_registro = DateTime.Parse(registros["usu_fecharegistro"].ToString());

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
                usuario.id = int.Parse(registros["usu_id"].ToString());
                usuario.documento = int.Parse(registros["usu_documento"].ToString());
                usuario.tipodoc = registros["usu_tipodoc"].ToString();
                usuario.nombre = registros["usu_nombre"].ToString();
                usuario.celular = int.Parse(registros["usu_celular"].ToString());
                usuario.email = registros["usu_email"].ToString();
                usuario.genero = registros["usu_genero"].ToString();
                usuario.aprendiz = registros["usu_aprendiz"].ToString();
                usuario.egresado = registros["usu_egresado"].ToString();
                usuario.areaformacion = registros["usu_areaformacion"].ToString();
                usuario.fecha_egresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.direccion = registros["usu_direccion"].ToString();
                usuario.barrio = registros["usu_barrio"].ToString();
                usuario.ciudad = registros["usu_ciudad"].ToString();
                usuario.departamento = registros["usu_departamento"].ToString();
                usuario.fecha_registro = DateTime.Parse(registros["usu_fecharegistro"].ToString());

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
                usuario.id = int.Parse(registros["usu_id"].ToString());
                usuario.documento = int.Parse(registros["usu_documento"].ToString());
                usuario.tipodoc = registros["usu_tipodoc"].ToString();
                usuario.nombre = registros["usu_nombre"].ToString();
                usuario.celular = int.Parse(registros["usu_celular"].ToString());
                usuario.email = registros["usu_email"].ToString();
                usuario.genero = registros["usu_genero"].ToString();
                usuario.aprendiz = registros["usu_aprendiz"].ToString();
                usuario.egresado = registros["usu_egresado"].ToString();
                usuario.areaformacion = registros["usu_areaformacion"].ToString();
                usuario.fecha_egresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.direccion = registros["usu_direccion"].ToString();
                usuario.barrio = registros["usu_barrio"].ToString();
                usuario.ciudad = registros["usu_ciudad"].ToString();
                usuario.departamento = registros["usu_departamento"].ToString();
                usuario.fecha_registro = DateTime.Parse(registros["usu_fecharegistro"].ToString());

            }
            else
                usuario = null;
            con.Close();
            return usuario;
        }
        public int Modificar(SE_Usuarios usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update SE_Usuarios set usu_tipodoc=@tipodoc,usu_nombre=@nombre,usu_celular=@celular,usu_email=@email,usu_genero=@genero,usu_aprendiz=@aprendiz,usu_egresado=@egresado,usu_areaformacion=@areaformacion,usu_fechaegresado=@fechaegresado,usu_direccion=@direccion,usu_barrio=@barrio,usu_ciudad=@ciudad,usu_departamento=@departamento,usu_fecharegistro=@fecharegistro where usu_documento=@documento", con);

            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters["@tipodoc"].Value = usu.tipodoc;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.nombre;

            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters["@celular"].Value = usu.celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.email;

            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = usu.genero;

            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters["@aprendiz"].Value = usu.aprendiz;

            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters["@egresado"].Value = usu.egresado;

            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = usu.areaformacion;

            comando.Parameters.Add("@fechaegresado", SqlDbType.DateTime);
            comando.Parameters["@fechaegresado"].Value = usu.fecha_egresado;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = usu.direccion;

            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters["@barrio"].Value = usu.barrio;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.ciudad;

            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters["@departamento"].Value = usu.departamento;

            comando.Parameters.Add("@fecharegistro", SqlDbType.DateTime);
            comando.Parameters["@fecharegistro"].Value = usu.fecha_registro;

            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters["@documento"].Value = usu.documento;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from SE_Usuarios where usu_documento=@documento", con);
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters["@documento"].Value = documento;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}