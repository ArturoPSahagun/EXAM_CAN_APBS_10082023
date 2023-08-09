using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace surtidora_api.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public Respuesta(int id, string mensaje)
        {
            Id = id;
            Mensaje = mensaje;
        }
    }
}