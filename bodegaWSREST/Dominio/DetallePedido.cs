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
        public string idcliente { get; set; }

        [DataMember]
        public string idbodega { get; set; }

        [DataMember]
        public double monto { get; set; }

        [DataMember]
        public DateTime fechaRegistro { get; set; }

        [DataMember]
        public DateTime fechaEntrega { get; set; }

        [DataMember]
        public bool estado { get; set; }

    }
}