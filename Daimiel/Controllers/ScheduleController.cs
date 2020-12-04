using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daimiel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Daimiel.Controllers
{
    public class ScheduleController : Controller
    {
        private IConfiguration _config;

        public ScheduleController(IConfiguration config)
        {
            _config = config;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<Unidad> llenadoras = new List<Unidad>();
            db dbContext = new db(_config.GetConnectionString("DbConnection"));
            llenadoras = dbContext.GetListUnidades("Llenadora",null);
            return View(llenadoras);
        }

        [Authorize]
        [HttpPost]
        public JsonResult getOrdenEnvasadosFromWS([FromBody]OrdenEnvasado orden)
        {
            db dbContext = new db(_config.GetConnectionString("DbConnection"));

            List<OrdenEnvasado> ordenes = new List<OrdenEnvasado>();

            ordenes = dbContext.GetOrdenEnvasadosFromWS(orden.Fecha, orden.Puesto);

            return new JsonResult(ordenes);
        }
    }
}