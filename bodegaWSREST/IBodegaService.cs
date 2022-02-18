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
        [WebInvoke(Method = "GET", UriTemplate = "bodegauser/{iduser}", ResponseFormat = WebMessageFormat.Json)]
        bodega ObtenerBodegaUser(string iduser);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "bodegaproductos/{idbodega}", ResponseFormat = WebMessageFormat.Json)]
        List<BodegaProductos> ObtenerBodegaProductos(string idbodega);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "pedidos/{idbodega}", ResponseFormat = WebMessageFormat.Json)]
        List<PedidoBodega> ObtenerPedidoBodega(string idbodega);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "pedidos", ResponseFormat = WebMessageFormat.Json)]
        pedido ModificarPedido(pedido pedidoAModificar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "detallepedidos/{idpedido}", ResponseFormat = WebMessageFormat.Json)]
        List<DetallePedido> obtenerDetallePedido(string idPedido);
        
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "detallepedidos", ResponseFormat = WebMessageFormat.Json)]
        detallepedido ModificarDetallePedido(detallepedido detallepedidoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "detallepedidos/{idPedido}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarPedido(string idPedido);
    }
}
