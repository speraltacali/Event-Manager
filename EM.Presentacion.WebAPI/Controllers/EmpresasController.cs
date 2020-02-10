using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.CondicionIva;
using EM.IServicio.Empresa;
using EM.IServicio.Empresa.DTOs;
using EM.Servicio.CondicionIva;
using EM.Servicio.Empresa;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class EmpresasController : Controller
    {
        private IEmpresaServicio _empresaServicio = new EmpresaServicio();
        private ICondicionIvaServicio _condicionIvaServicio = new CondicionIvaServicio();


        // GET: Empresas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewData["condicionIva"] = _condicionIvaServicio.Obtener();

            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpresaDto empresa)
        {
            if(ModelState.IsValid)
            {

            }

            return View();
        }
    }
}