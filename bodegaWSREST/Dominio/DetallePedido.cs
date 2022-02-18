using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bodegaWSREST.Dominio
{
    [DataContract]
    public class DetallePedido
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string idpedido { get; set; }

        [DataMember]
        public string idproducto { get; set; }

        [DataMember]
        public string desproducto { get; set; }

        [DataMember]
        public decimal precio { get; set; }

        [DataMember]
        public decimal cantidad { get; set; }
    }
}