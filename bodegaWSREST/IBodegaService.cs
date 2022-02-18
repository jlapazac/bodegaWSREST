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

        //A partir de aqui van los metodos pedido
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "pedidos", ResponseFormat = WebMessageFormat.Json)]
        pedido CrearPedido(pedido pedidoACrear);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "pedidos/{idpedido}", ResponseFormat = WebMessageFormat.Json)]
        pedido obtenerPedido(string idpedido);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "pedidoscliente/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        List<PedidosCliente> ObtenerPedidoClientes(string idcliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "pedidos", ResponseFormat = WebMessageFormat.Json)]
        pedido ModificarPedido(pedido pedidoAMOdificar);

        //A partir de aqui van los metodos detallePedido

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "detallepedidos", ResponseFormat = WebMessageFormat.Json)]
        detallepedido CrearDetallePedido(detallepedido detallepedidoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "detallepedidos/{id}", ResponseFormat = WebMessageFormat.Json)]
        detallepedido obtenerDetallePedido(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "detallepedidos", ResponseFormat = WebMessageFormat.Json)]
        detallepedido ModificarDetallePedido(detallepedido detallepedidoAMOdificar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "detallepedidosproductos/{idpedido}", ResponseFormat = WebMessageFormat.Json)]
        List<DetallePedido> obtenerDetallePedidoProductos(string idpedido);
    }
}
