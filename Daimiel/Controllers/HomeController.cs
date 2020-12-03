using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daimiel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Daimiel.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config;

        public HomeController(IConfiguration config )
        {
            _config = config;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        [Authorize]
        public ViewResult Llenadora()
        {
            var cs = this._config.GetConnectionString("DbConnection");
            db dbContext = new db(cs);

            List<LlenadorasUsuarios> llenadoras = new List<LlenadorasUsuarios>();

            llenadoras = dbContext.GetLlenadoras(User.Identity.Name);

            return View(llenadoras);
        }
        [HttpPost]
        public JsonResult Llenadora([FromBody]string llenadora)
        {
            db dbContext = new db(_config.GetConnectionString("DbConnection"));
            List<OrdenEnvasado> ordenes = new List<OrdenEnvasado>();

            ordenes = dbContext.GetOrdenesEnvasado(llenadora);

            return new JsonResult(ordenes);
        }
        [HttpPost]
        public JsonResult OrdenEnvasado([FromBody]OrdenLlenadora orden)
        {
            db dbContext = new db(_config.GetConnectionString("DbConnection"));
            List<OrdenEnvasado> ordenes = new List<OrdenEnvasado>();

            ordenes = dbContext.GetOrdenEnvasado(orden);

            return new JsonResult(ordenes);
        }

        [HttpPost]
        public JsonResult LogInicio([FromBody]Llenadoras llenadora)
        {
            var result = 0;
            if (llenadora != null)
            {
                db dbContext = new db(_config.GetConnectionString("DbConnection"));                
                result = dbContext.SetNewInicio(llenadora);
            }           

            return new JsonResult(result);
        }
        [HttpPost]
        public JsonResult LogFin([FromBody]Llenadoras llenadora)
        {
            var result = 0;         


            if (llenadora != null)
            {
                db dbContext = new db(_config.GetConnectionString("DbConnection"));
                result = dbContext.SetFin(llenadora);
            }

            return new JsonResult(result);
        }
        [HttpGet]
        [Authorize]
        public ViewResult Historico()
        {
            db dbContext = new db(_config.GetConnectionString("DbConnection"));

            List<TblLlenadoras> llenadoras = new List<TblLlenadoras>();

            llenadoras = dbContext.GetLlenadorasHist("",7,1,10);

            return View(llenadoras);
        }
        public JsonResult FiltrarLlenadoras([FromBody]FiltroLlenadora filtro)
        {
            List<TblLlenadoras> llenadoras = new List<TblLlenadoras>();
            if (filtro != null)
            {
                db dbContext = new db(_config.GetConnectionString("DbConnection"));
                llenadoras = dbContext.GetLlenadorasHist(filtro.llenadora, filtro.estado,1,10);
            }

            return new JsonResult(llenadoras);
        }
        public JsonResult ConsultaEstadoLlenadora([FromBody]string llenadora)
        {
            TblLlenadoras llenadoraInfo = new TblLlenadoras();
            if (llenadora != null)
            {
                db dbContext = new db(_config.GetConnectionString("DbConnection"));
                llenadoraInfo = dbContext.GetLlenadorasEstado(llenadora);
            }

            return new JsonResult(llenadoraInfo);
        }

    }
}
