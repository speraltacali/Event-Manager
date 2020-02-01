using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.IServicio.Empresa;
using EM.IServicio.Empresa.DTOs;
using EM.Servicio.Empresa;

namespace EM.Presentacion.WebAPI.Controllers
{
    public class EmpresaController : Controller
    {
        private IEmpresaServicio _empresaServicio = new EmpresaServicio();

        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpresaDto empresa)
        {
            if (ModelState.IsValid)
            {
                _empresaServicio.Insertar(empresa);
            }

            return View();
        }
    }
}