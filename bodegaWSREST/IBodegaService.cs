using bodegaWSREST.Dominio;
using bodegaWSREST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace bodegaWSREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBodegaService" in both code and config file together.
    [ServiceContract]
    public interface IBodegaService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "bodegas", ResponseFormat = WebMessageFormat.Json)]
        bodega CrearBodega(bodega bodegaACrear);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "bodegas", ResponseFormat = WebMessageFormat.Json)]
        bodega ModificarBodega(bodega bodegaAModificar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "bodegas/{idbodega}", ResponseFormat = WebMessageFormat.Json)]
        bodega ObtenerBodega(string idbodega);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "bodegaproductos/{idbodega}", ResponseFormat = WebMessageFormat.Json)]
        List<BodegaProductos> ObtenerBodegaProductos(string idbodega);
    }
}
