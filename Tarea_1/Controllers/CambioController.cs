using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using Tarea_1.Entities;

namespace Tarea_1.Controllers
{
    public class CambioController : ApiController
    {

        [HttpGet]
        [Route("api/Data/ObtenerDatosCompra")]
        public async Task<string> ConsultarDatos()
        {

            try
            {
                HttpClient client = new HttpClient();
                string ruta = "https://gee.bccr.fi.cr/Indicadores/Suscripciones/WS/wsindicadoreseconomicos.asmx/ObtenerIndicadoresEconomicosXML";
                string parametros = String.Format("Indicador={0}&FechaInicio={1}&FechaFinal={2}&Nombre={3}&SubNiveles=S&CorreoElectronico={4}&Token={5}",
                    317,
                    "01/08/2021",
                    "01/03/2022",
                    "Andres Barrantes",
                    "andreslml.ab@gmail.com",
                    "2DEMMR62M6"
                    );

                var response = await client.GetStringAsync(string.Concat(ruta, "?", parametros));
                //return response;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response);

                string json = JsonConvert.SerializeXmlNode(doc);

                //Console.WriteLine(json);
                return json;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                string messageError = $"Message :{e.Message} ";
                return messageError;
            }
        }
    }
}
