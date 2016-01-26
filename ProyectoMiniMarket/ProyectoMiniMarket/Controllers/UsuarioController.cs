using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;


namespace ProyectoMiniMarket.Controllers
{
    public class UsuarioController : Controller
    {
        minimarketDBEntities1 bd = new minimarketDBEntities1();
       
        // GET: Usuario
        public ActionResult Index(string idusuario, string passwordusuario)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (!string.IsNullOrEmpty(idusuario) && !string.IsNullOrEmpty(passwordusuario))
            {

                foreach (var user in bd.usuario)
                {
                    if (user.id.Equals(idusuario) && user.pwd.Equals(passwordusuario))
                    {
                        Session["usuario"] = user;
                        return RedirectToAction("Lista");
                       
                    }
                    else
                    {
                        /*return Content("<script language='javascript' type='text/javascript'>alert('USUARIO INCORRECTO');</script>");*/
                        ViewData["Message"] = "USUARIO O Clave ERRADA";                       
                    }
                }

            }


            return View();
        }
       

        public ActionResult Lista()
        {
            
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                var listado = (from x in bd.productos
                               select x).ToList();

                return View(listado);
            }
            
        }

        public ActionResult desconectar()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Session.Clear();

            return RedirectToAction("Index");
            

        }

        public ActionResult Edit(int?id)
        {
            var producto = new productos();
            usuario usuarioObTenido = Session["usuario"] as usuario;
            if (usuarioObTenido.tipoUsuario.Equals("I"))
            {
                ViewData["Message2"] = "usted no tiene los permisos necesarios";
                ViewData["Message2"] =  usuarioObTenido.nombre+"usted no tiene los permisos necesarios";
                return RedirectToAction("Lista");
            }
            else
            {
                producto = (from x in bd.productos
                                where x.idproducto == id
                                select x).FirstOrDefault();
                ViewBag.IdCategoria = new SelectList
                    (bd.productos.ToList(), "idCategoria", "nombreProducto", producto.idCategoria);
                return View(producto);   
            }
            
        }
    }
}