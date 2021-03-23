using ProgramaEgresadoSena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramaEgresadoSena.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            SE_Usuarios usu= new SE_Usuarios
            {

                documento = int.Parse(collection["documento"]),
                tipodoc = collection["tipodoc"],
                nombre = collection["nombre"],
                celular = int.Parse(collection["celular"]),
                email = collection["email"],
                genero = collection["genero"],
                aprendiz = collection["aprendiz"],
                egresado = collection["egresado"],
                areaformacion = collection["areaformacion"],
                fecha_egresado = DateTime.Parse(collection["fecha_egresado"].ToString()),
                direccion = collection["direccion"],
                barrio = collection["barrio"],
                ciudad = collection["ciudad"],
                departamento = collection["departamento"],
                fecha_registro = DateTime.Parse(collection["fecha_registro"].ToString())
            };
            ma.Alta(usu);
            return RedirectToAction("Index");
        }


        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            SE_Usuarios usu = ma.Recuperardocumento(id);
            return View(usu);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            SE_Usuarios art = new SE_Usuarios
            {
                documento = id,
                tipodoc = collection["tipodoc"],
                nombre = collection["nombre"],
                celular = int.Parse(collection["celular"]),
                email = collection["email"],
                genero = collection["genero"],
                aprendiz = collection["aprendiz"],
                egresado = collection["egresado"],
                areaformacion = collection["areaformacion"],
                fecha_egresado = DateTime.Parse(collection["fecha_egresado"].ToString()),
                direccion = collection["direccion"],
                barrio = collection["barrio"],
                ciudad = collection["ciudad"],
                departamento = collection["departamento"],
                fecha_registro = DateTime.Parse(collection["fecha_registro"].ToString())
              
            };
            ma.Modificar(art);
            return RedirectToAction("Index");

        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            SE_Usuarios usu = ma.Recuperardocumento(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            ma.Borrar(id);
            return RedirectToAction("Index");
            
        }
        public ActionResult Visualizar()
        {
            MantenimientoUsuario ma = new
            MantenimientoUsuario();
            return View(ma.RecuperarTodos());
        }
    }
}
