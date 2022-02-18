using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bodegaWSREST.Dominio
{
    [DataContract]
    public class PedidoBodega
    {
        [DataMember]
        public string idPedido { get; set; }
        [DataMember]
        public string idCliente { get; set; }
        [DataMember]
        public string idBodega { get; set; }
        [DataMember]
        public decimal monto { get; set; }
        [DataMember]
        public DateTime fechaRegistro { get; set; }
        [DataMember]
        public DateTime fechaEntrega { get; set; }
        [DataMember]
        public string estado { get; set; }
    }
}