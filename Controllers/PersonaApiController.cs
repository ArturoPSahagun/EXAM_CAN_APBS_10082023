using Newtonsoft.Json.Linq;
using surtidora_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace surtidora_api.Controllers
{
    public class PersonaApiController : Controller
    {


        // POST: PersonaApi/NuevaPersona
        [HttpPost]
        public JObject NuevaPersona()
        {
            JObject body;
            using (StreamReader stream = new StreamReader(HttpContext.Request.InputStream))
            {
                string b = stream.ReadToEnd();
                body = JObject.Parse(b);
            }

            var token = Request.Headers["Authorization"];
            if(!Auth.Check(token))
            {
                Respuesta r = new Respuesta(0, "Error al autorizar");
                return (JObject)JToken.FromObject(r);
            }

            Respuesta senddata;
            using (surtidoradbEntities db = new surtidoradbEntities())
            {
                var resp = db.SP_NuevaPersona((string)body.GetValue("Nombre"),
                                               (string)body.GetValue("Paterno"),
                                               (string)body.GetValue("Materno"),
                                               (string)body.GetValue("RFC"), 
                                               new DateTime(
                                                   (int)body.GetValue("BYear"),
                                                   (int)body.GetValue("BMonth"),
                                                   (int)body.GetValue("BDay")
                                                   ), (int)body.GetValue("Usuario")
                                              );
                var fresp = resp.First();
                senddata = new Respuesta((int)fresp.ERROR, fresp.MENSAJEERROR);
            }

            return (JObject)JToken.FromObject(senddata);
            
        }

        // PUT: PersonaApi/ActualizarPersona
        [HttpPut]
        public JObject ActualizarPersona()
        {
            JObject body;
            using (StreamReader stream = new StreamReader(HttpContext.Request.InputStream))
            {
                string b = stream.ReadToEnd();
                body = JObject.Parse(b);
            }

            var token = Request.Headers["Authorization"];
            if (!Auth.Check(token))
            {
                Respuesta r = new Respuesta(0, "Error al autorizar");
                return (JObject)JToken.FromObject(r);
            }

            Respuesta senddata;
            using (surtidoradbEntities db = new surtidoradbEntities())
            {
                var resp = db.SP_Actualizar(   (int)body.GetValue("IdPer"),
                                               (string)body.GetValue("Nombre"),
                                               (string)body.GetValue("Paterno"),
                                               (string)body.GetValue("Materno"),
                                               (string)body.GetValue("RFC"),
                                               new DateTime(
                                                   (int)body.GetValue("BYear"),
                                                   (int)body.GetValue("BMonth"),
                                                   (int)body.GetValue("BDay")
                                                   ), (int)body.GetValue("Usuario")
                                              );
                var fresp = resp.First();
                senddata = new Respuesta((int)fresp.ERROR, fresp.MENSAJEERROR);
            }

            return (JObject)JToken.FromObject(senddata);
            
        }

        // DELETE: PersonaApi/EliminarPersona
        [HttpDelete]
        public JObject EliminarPersona()
        {
            JObject body;
            using (StreamReader stream = new StreamReader(HttpContext.Request.InputStream))
            {
                string b = stream.ReadToEnd();
                body = JObject.Parse(b);
            }

            var token = Request.Headers["Authorization"];
            if (!Auth.Check(token))
            {
                Respuesta r = new Respuesta(0, "Error al autorizar");
                return (JObject)JToken.FromObject(r);
            }

            Respuesta senddata;
            using (surtidoradbEntities db = new surtidoradbEntities())
            {
                var resp = db.SP_Eliminar((int)body.GetValue("IdPer"));
                var fresp = resp.First();
                senddata = new Respuesta((int)fresp.ERROR, fresp.MENSAJEERROR);
            }

            return (JObject)JToken.FromObject(senddata);

        }

    }
}
