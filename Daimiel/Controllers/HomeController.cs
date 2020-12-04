using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daimiel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
            parseJSON("45",DateTime.Now);
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
        [HttpPost]
        public JsonResult populateCbLlenadora()
        {
            var cs = this._config.GetConnectionString("DbConnection");
            db dbContext = new db(cs);

            List<LlenadorasUsuarios> llenadoras = new List<LlenadorasUsuarios>();

            llenadoras = dbContext.GetLlenadoras(User.Identity.Name);


            return new JsonResult(llenadoras);
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

        public void parseJSON(string llenadora, DateTime fecha)
        {
            /*var data = @"{""results"": [{""NumeroOrden"": ""1989351"",""Codigo"": ""17755"",""Semielaborado"": ""54191"",""Lote"": ""K050"",""Descripcion"": ""REF.SMOOT.PIÑA-PLAT-COC TESCO PET750MLX6"",
                                        ""DescripcionSemielaborado"": ""SMOOTHIE PIÑA PLATANO COCO (ALDI)"",""Fecha"": ""20201105"",""Cantidad"": """"},
                                        {""NumeroOrden"": ""1987158"",""Codigo"": ""16741"",""Semielaborado"": ""54191"",""Lote"": ""K050"",""Descripcion"": ""SMOOT JUICE CO TROPICAL PET750MLX6PROD2"",
                                        ""DescripcionSemielaborado"": ""SMOOTHIE PIÑA PLATANO COCO (ALDI)"",""Fecha"": ""20201105"",""Cantidad"": """"}
                        ]}";*/

            var data = System.IO.File.ReadAllText(@"C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Models\Json\10000831.json");

            JsonOrdenesRoot jsonOrdenes = JsonConvert.DeserializeObject<JsonOrdenesRoot>(data);           

            List<OrdenEnvasado> ordenes = new List<OrdenEnvasado>();

            ordenes = (from JsonOrden jsonOrden in jsonOrdenes.d.results
                          select new OrdenEnvasado()
                          {                              
                              Puesto = llenadora,
                              Puesto_Denominacion = "",
                              Orden = jsonOrden.NumeroOrden == "" ? 0 : Convert.ToInt32(jsonOrden.NumeroOrden),
                              Material = 0,
                              ProductoTerminado = jsonOrden.Descripcion,
                              ProductoTerminado_Denominacion = jsonOrden.Descripcion,
                              Semielaborado = jsonOrden.Semielaborado == "" ? 0 : Convert.ToInt32(jsonOrden.Semielaborado),
                              Semielaborado_Descr = jsonOrden.DescripcionSemielaborado,
                              Grado_Brix_VALOR_TEO = 0,
                              Temperatura_Pasteriz = 0,
                              Temperatura_Llenado = 0,
                              Fecha = fecha
                          }).ToList();

            db dbContext = new db(_config.GetConnectionString("DbConnection"));
            dbContext.AddOrdenEnvasado(ordenes);



        }

    }
}
