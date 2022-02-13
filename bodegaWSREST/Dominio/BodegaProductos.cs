using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bodegaWSREST.Dominio
{
    [DataContract]
    public class BodegaProductos
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string idproducto { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string imagen { get; set; }

        [DataMember]
        public double precio { get; set; }

        [DataMember]
        public bool activo { get; set; }

        [DataMember]
        public string idcategoria { get; set; }

        [DataMember]
        public string descategoria { get; set; }
    }
}