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
        public string idPedido { get; set; }
        [DataMember]
        public string idProducto { get; set; }
        [DataMember]
        public decimal precio { get; set; }
        [DataMember]
        public decimal cantidad { get; set; }
        [DataMember]
        public int id { get; set; }
    }
}