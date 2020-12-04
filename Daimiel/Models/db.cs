using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace Daimiel.Models
{
    public class db
    {
        private readonly string _cs;
        //SqlConnection cn = new SqlConnection("Data Source=ES5CD8322PKK;Initial Catalog=TPFormDB;Integrated Security=True");
        //SqlConnection cn = new SqlConnection("Data Source=ES5CD8322PKK;Initial Catalog=TPFormDB;User Id=sa;Password=zaqXSW4321;");
        SqlConnection cn;

        public db(string cs)
        {
            _cs = cs;
            cn = new SqlConnection(cs);
        }

        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true);
            return builder.Build();
        }

        public string LoginCheck(Ad_Login ad)
        {
            using (cn)
            {                
                SqlCommand cmd = new SqlCommand("uspLogin", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pLoginName", ad.Usuario);
                cmd.Parameters.AddWithValue("@pPassword", ad.Password);
                SqlParameter oblogin = new SqlParameter();
                oblogin.ParameterName = "@responseMessage";
                oblogin.SqlDbType = SqlDbType.NVarChar;
                oblogin.Size = 250;
                oblogin.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(oblogin);
                cn.Open();
                cmd.ExecuteNonQuery();
                string res = oblogin.Value.ToString();
                return res;
            }
            
        }

        public List<LlenadorasUsuarios> GetLlenadoras(string email)
        {
            List<LlenadorasUsuarios> llenadorasUsuarios = new List<LlenadorasUsuarios>();

            using (cn)
            {
                SqlCommand cmd = new SqlCommand("sp_S_GetLlenadorasByEmail", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pEmail", email);
                SqlParameter oblogin = new SqlParameter();
                cn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                llenadorasUsuarios = (from DataRow dr in dt.Rows
                                      select new LlenadorasUsuarios()
                                      {
                                          Usuario = dr.ItemArray[0].ToString(),
                                          Email = dr.ItemArray[1].ToString(),
                                          Grupo = dr.ItemArray[2].ToString(),
                                          Puesto = dr.ItemArray[3].ToString(),
                                          Estado = dr.ItemArray[4] is DBNull ? "" : dr.ItemArray[4].ToString(),
                                          Descripcion = dr.ItemArray[5] is DBNull ? "" : dr.ItemArray[5].ToString()
                                      }).ToList();
            }//End of using          

            return llenadorasUsuarios;
        }

        public List<OrdenEnvasado> GetOrdenesEnvasado(string puesto)
        {
            List<OrdenEnvasado> ordenes = new List<OrdenEnvasado>();

            using (cn)
            {
                SqlCommand cmd = new SqlCommand("sp_S_GetOrdenesEnvasado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pPuesto", puesto);
                SqlParameter oblogin = new SqlParameter();
                try
                {
                    cn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ordenes = (from DataRow dr in dt.Rows
                               select new OrdenEnvasado()
                               {
                                   Id = Convert.ToInt32(dr.ItemArray[0]),
                                   Puesto = dr.ItemArray[1].ToString(),
                                   Puesto_Denominacion = dr.ItemArray[2].ToString(),
                                   Orden = Convert.ToInt32(dr.ItemArray[3]),
                                   Material = Convert.ToInt32(dr.ItemArray[4]),
                                   ProductoTerminado = dr.ItemArray[5].ToString(),
                                   ProductoTerminado_Denominacion = dr.ItemArray[6].ToString(),
                                   Semielaborado = Convert.ToInt32(dr.ItemArray[7]),
                                   Semielaborado_Descr = dr.ItemArray[8].ToString(),
                                   Grado_Brix_VALOR_TEO = (float)Convert.ChangeType(dr.ItemArray[9],typeof(float)),
                                   Temperatura_Pasteriz = (float)Convert.ChangeType(dr.ItemArray[10], typeof(float)),
                                   Temperatura_Llenado = (float)Convert.ChangeType(dr.ItemArray[11], typeof(float)),                                  
                               }).ToList();
                }
                catch(Exception error)
                {
                    string result = error.Message;
                }
                
            }//End of using

            return ordenes;
        }
        public List<OrdenEnvasado> GetOrdenEnvasado(OrdenLlenadora orden)
        {
            List<OrdenEnvasado> ordenes = new List<OrdenEnvasado>();

            using (cn)
            {
                SqlCommand cmd = new SqlCommand("sp_S_GetOrdenEnvasado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pOrdenId", orden.ordenId);
                cmd.Parameters.AddWithValue("@pLlenadora", orden.Llenadora);
                try
                {
                    cn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ordenes = (from DataRow dr in dt.Rows
                               select new OrdenEnvasado()
                               {
                                   Id = Convert.ToInt32(dr.ItemArray[0]),
                                   Puesto = dr.ItemArray[1].ToString(),
                                   Puesto_Denominacion = dr.ItemArray[2].ToString(),
                                   Orden = Convert.ToInt32(dr.ItemArray[3]),
                                   Material = Convert.ToInt32(dr.ItemArray[4]),
                                   ProductoTerminado = dr.ItemArray[5].ToString(),
                                   ProductoTerminado_Denominacion = dr.ItemArray[6].ToString(),
                                   Semielaborado = Convert.ToInt32(dr.ItemArray[7]),
                                   Semielaborado_Descr = dr.ItemArray[8].ToString(),
                                   Grado_Brix_VALOR_TEO = (float)Convert.ChangeType(dr.ItemArray[9], typeof(float)),
                                   Temperatura_Pasteriz = (float)Convert.ChangeType(dr.ItemArray[10], typeof(float)),
                                   Temperatura_Llenado = (float)Convert.ChangeType(dr.ItemArray[11], typeof(float))
                               }).ToList();
                }
                catch (Exception error)
                {
                    string result = error.Message;
                }

            }//End of using

            return ordenes;
        }

        public int SetNewInicio(Llenadoras llenadora)
        {
            int result = 0;

            using (cn)
            {
                SqlCommand cmd = new SqlCommand("sp_I_SetNewInicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pSemielaborado", llenadora.semielaborado);
                cmd.Parameters.AddWithValue("@pOrigen", llenadora.origen);
                cmd.Parameters.AddWithValue("@pDestino", llenadora.destino);
                cmd.Parameters.AddWithValue("@pOrden", llenadora.orden);

                SqlParameter oblogin = new SqlParameter();
                oblogin.ParameterName = "@pResult";
                oblogin.SqlDbType = SqlDbType.Int;
                oblogin.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oblogin);
                cn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(oblogin.Value);

            }

            return result;
        }
        public int SetFin(Llenadoras llenadora)
        {
            int result = 0;

            using (cn)
            {
                DateTime fecha_inicio;
                DateTime fecha_fin;

                SqlCommand cmd = new SqlCommand("sp_I_SetFin", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pDestino", llenadora.destino);
                cmd.Parameters.AddWithValue("@pSemielaborado", llenadora.semielaborado);
                cmd.Parameters.AddWithValue("@pOrigen", llenadora.origen);
                cmd.Parameters.AddWithValue("@pOrden", llenadora.orden);

                if (llenadora.fecha_fin == "")
                    cmd.Parameters.AddWithValue("@pFecha_Fin", null);
                else
                {
                    fecha_fin = DateTime.ParseExact(llenadora.fecha_fin, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    cmd.Parameters.AddWithValue("@pFecha_Fin", fecha_fin);
                }

                if (llenadora.fecha_inicio == "")
                    cmd.Parameters.AddWithValue("@pFecha_Inicio", null);
                else
                {
                    fecha_inicio = DateTime.ParseExact(llenadora.fecha_inicio, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    cmd.Parameters.AddWithValue("@pFecha_Inicio", fecha_inicio);
                }             
                

                SqlParameter oblogin = new SqlParameter();
                oblogin.ParameterName = "@pResult";
                oblogin.SqlDbType = SqlDbType.Int;
                oblogin.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oblogin);
                cn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(oblogin.Value);

            }

            return result;
        }

        public List<TblLlenadoras> GetLlenadorasHist(string llenadora, int filter, int fromRow, int pgSize)
        {
            /*
             Filter:
                0: Nada
                1: Iniciado
                2: Finalizado
                4: Consolidado
                3: Iniciado + Finalizado
                5: Iniciado + Consolidado
                6: Finalizado + Consolidado
                7: Todo             
             */
            List<TblLlenadoras> llenadoras = new List<TblLlenadoras>();

            using (cn)
            {
                SqlCommand cmd = new SqlCommand("sp_S_GetLlenadorasHist", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pLlenadora", llenadora);
                cmd.Parameters.AddWithValue("@pFilter", filter);
                cmd.Parameters.AddWithValue("@FromRow", fromRow);
                cmd.Parameters.AddWithValue("@PgSize", pgSize);
                try
                {
                    cn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DateTimeFormatInfo datetimeFormat = new CultureInfo("es-ES",false).DateTimeFormat;

                    llenadoras = (from DataRow dr in dt.Rows
                                  select new TblLlenadoras()
                                  {
                                    id = Convert.ToInt32(dr.ItemArray[0]),
                                    formulacion_id = dr.ItemArray[1] is DBNull ? 0 : Convert.ToInt32(dr.ItemArray[1]),
                                    semielaborado = Convert.ToInt32(dr.ItemArray[2]),
                                    unidad = dr.ItemArray[3].ToString(),
                                    puesto = dr.ItemArray[4].ToString(),
                                    fecha_inicio = dr.ItemArray[5] is DBNull ? Convert.ToDateTime("01-01-1900", datetimeFormat) : Convert.ToDateTime(dr.ItemArray[5], datetimeFormat),
                                    fecha_fin = dr.ItemArray[6] is DBNull ? Convert.ToDateTime("01-01-1900", datetimeFormat) : Convert.ToDateTime(dr.ItemArray[6], datetimeFormat),
                                    inicio_vaciado_alsafe = dr.ItemArray[7] is DBNull ? Convert.ToDateTime("01-01-1900", datetimeFormat) : Convert.ToDateTime(dr.ItemArray[7], datetimeFormat),
                                    cantidad = dr.ItemArray[8] is DBNull ? 0 : (float)Convert.ChangeType(dr.ItemArray[8], typeof(float)),
                                    duracion = dr.ItemArray[9] is DBNull ? 0 : Convert.ToInt32(dr.ItemArray[9]),
                                    estado = dr.ItemArray[10].ToString(),
                                    orden = dr.ItemArray[11] is DBNull ? 0 : Convert.ToInt32(dr.ItemArray[11]),
                                  }).ToList();
                }
                catch (Exception error)
                {
                    string result = error.Message;
                }

            }//End of using



            return llenadoras;
        }

        public TblLlenadoras GetLlenadorasEstado(string llenadora)
        {
            TblLlenadoras llenadoraInfo = new TblLlenadoras();
            using (cn)
            {                
                SqlCommand cmd = new SqlCommand("sp_S_GetLlenadoraEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pLlenadora", llenadora);               

                try
                {
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DateTimeFormatInfo datetimeFormat = new CultureInfo("es-ES", false).DateTimeFormat;

                    if (dt.Rows.Count > 0)
                    {
                        llenadoraInfo.id = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                        llenadoraInfo.formulacion_id = dt.Rows[0].ItemArray[1] is DBNull ? 0 : Convert.ToInt32(dt.Rows[0].ItemArray[1]);
                        llenadoraInfo.semielaborado = Convert.ToInt32(dt.Rows[0].ItemArray[2]);                        
                        llenadoraInfo.puesto = llenadora;
                        llenadoraInfo.fecha_inicio = dt.Rows[0].ItemArray[5] is DBNull ? Convert.ToDateTime("01-01-1900", datetimeFormat) : Convert.ToDateTime(dt.Rows[0].ItemArray[5], datetimeFormat);
                        llenadoraInfo.estado = dt.Rows[0].ItemArray[10].ToString();
                        llenadoraInfo.orden = dt.Rows[0].ItemArray[11] is DBNull ? 0 : Convert.ToInt32(dt.Rows[0].ItemArray[11]);
                    }
                    else
                        llenadoraInfo = null;                  


                }
                catch (Exception error)
                {
                    string result = error.Message;
                }

            }//End of using

            return llenadoraInfo;
        }
        public int AddOrdenEnvasado(List<OrdenEnvasado> ordenes)
        {
            int result = 0;

            using (cn)
            {

                try
                {
                    cn.Open();

                    /*
                    SqlParameter param1 = new SqlParameter("@pPuesto", null);
                    SqlParameter param2 = new SqlParameter("@pPuesto_Denominacion", null);
                    SqlParameter param3 = new SqlParameter("@pOrden", null);
                    SqlParameter param4 = new SqlParameter("@pMaterial", null);
                    SqlParameter param5 = new SqlParameter("@pProductoTerminado", null);
                    SqlParameter param6 = new SqlParameter("@pProductoTerminado_Denominacion", null);
                    SqlParameter param7 = new SqlParameter("@pSemielaborado", null);
                    SqlParameter param8 = new SqlParameter("@pSemielaborado_Descr", null);
                    SqlParameter param9 = new SqlParameter("@pGrado_Brix_VALOR_TEO", null);
                    SqlParameter param10 = new SqlParameter("@pTemperatura_Pasteriz", null);
                    SqlParameter param11 = new SqlParameter("@pTemperatura_Llenado", null);
                    SqlParameter param12 = new SqlParameter("@pFecha", null);
                    */

                    foreach (OrdenEnvasado orden in ordenes)
                    {
                        SqlCommand cmd = new SqlCommand("sp_I_AddOrdenEnvasado", cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@pPuesto", orden.Puesto);
                        cmd.Parameters.AddWithValue("@pPuesto_Denominacion", orden.Puesto_Denominacion);
                        cmd.Parameters.AddWithValue("@pOrden", orden.Orden);
                        cmd.Parameters.AddWithValue("@pMaterial", orden.Material);
                        cmd.Parameters.AddWithValue("@pProductoTerminado", orden.ProductoTerminado);
                        cmd.Parameters.AddWithValue("@pProductoTerminado_Denominacion", orden.ProductoTerminado_Denominacion);
                        cmd.Parameters.AddWithValue("@pSemielaborado", orden.Semielaborado);
                        cmd.Parameters.AddWithValue("@pSemielaborado_Descr", orden.Semielaborado_Descr);
                        cmd.Parameters.AddWithValue("@pGrado_Brix_VALOR_TEO", orden.Grado_Brix_VALOR_TEO);
                        cmd.Parameters.AddWithValue("@pTemperatura_Pasteriz", orden.Temperatura_Pasteriz);
                        cmd.Parameters.AddWithValue("@pTemperatura_Llenado", orden.Temperatura_Llenado);
                        cmd.Parameters.AddWithValue("@pFecha", orden.Fecha);                       

                        cmd.ExecuteNonQuery();

                        cmd.Dispose();

                    }

                }
                catch(Exception error)
                {
                    var ErrorMsg = error.Message;
                    result = -1;
                }               

            }
                return result;
        }

        public List<OrdenEnvasado> GetOrdenEnvasadosFromWS(DateTime fecha, string llenadora)
        {
            List<OrdenEnvasado> ordenes = new List<OrdenEnvasado>();

            /*var data = @"{""results"": [{""NumeroOrden"": ""1989351"",""Codigo"": ""17755"",""Semielaborado"": ""54191"",""Lote"": ""K050"",""Descripcion"": ""REF.SMOOT.PIÑA-PLAT-COC TESCO PET750MLX6"",
                                        ""DescripcionSemielaborado"": ""SMOOTHIE PIÑA PLATANO COCO (ALDI)"",""Fecha"": ""20201105"",""Cantidad"": """"},
                                        {""NumeroOrden"": ""1987158"",""Codigo"": ""16741"",""Semielaborado"": ""54191"",""Lote"": ""K050"",""Descripcion"": ""SMOOT JUICE CO TROPICAL PET750MLX6PROD2"",
                                        ""DescripcionSemielaborado"": ""SMOOTHIE PIÑA PLATANO COCO (ALDI)"",""Fecha"": ""20201105"",""Cantidad"": """"}
                        ]}";*/

            /* Obtener el código de la llenadora a partir del nombre */

            using (cn)
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 Codigo FROM Unidades WHERE Unidad = @unidad", cn);
                cmd.Parameters.AddWithValue("@unidad", llenadora);
                try
                {
                    cn.Open();
                    var result = cmd.ExecuteScalar();
                }
                catch(Exception error)
                {
                    var errorMsg = error.Message;
                }
            }

            var data = File.ReadAllText(@"C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Models\Json\10000831.json");

            JsonOrdenesRoot jsonOrdenes = JsonConvert.DeserializeObject<JsonOrdenesRoot>(data);

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



            return ordenes;
        }
        public List<Unidad> GetListUnidades(string clase, int? codigo)
        {
            List<Unidad> unidades = new List<Unidad>();

            using (cn)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Unidades WHERE Clase = @clase", cn);
                cmd.Parameters.AddWithValue("@clase", clase);
                try
                {
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    unidades = (from DataRow dr in dt.Rows
                                select new Unidad()
                                {
                                    unidad = dr.ItemArray[1] is DBNull ? "" : dr.ItemArray[1].ToString(),
                                    clase = dr.ItemArray[2] is DBNull ? "" : dr.ItemArray[2].ToString(),
                                    descripcion = dr.ItemArray[3] is DBNull ? "" : dr.ItemArray[3].ToString(),
                                    codigo = dr.ItemArray[4] is DBNull ? 0 : Convert.ToInt32(dr.ItemArray[4]),
                                    centro = dr.ItemArray[5] is DBNull ? 0 : Convert.ToInt32(dr.ItemArray[5])
                                }
                                ).ToList();
                    
                }
                catch (Exception error)
                {
                    var errorMsg = error.Message;
                }
            }


            return unidades;

        }

    }
}
