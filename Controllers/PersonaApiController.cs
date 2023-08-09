using Newtonsoft.Json.Linq;
using surtidora_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace surtidora_api.Controllers
{
    public class PersonaApiController : Controller
    {
        // GET: PersonaApi
        public JObject Index()
        {
            Respuesta r = new Respuesta(0, "nueva api index!!!!");

            return (JObject)JToken.FromObject(r);
        }

        // GET: PersonaApi/Create
        public JObject Create()
        {
            Respuesta r = new Respuesta(0, "Nueva API crear!!!!");


            return (JObject)JToken.FromObject(r);
        }

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
