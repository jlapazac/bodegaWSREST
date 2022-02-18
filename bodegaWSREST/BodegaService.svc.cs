using bodegaWSREST.Dominio;
using bodegaWSREST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bodegaWSREST
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults =true)]
    public class BodegaService : IBodegaService
    {
        private bodegasEntities db = new bodegasEntities();
        public bodega CrearBodega(bodega bodegaACrear)
        {
            db.bodega.Add(bodegaACrear);
            db.SaveChanges();
            bodega bodega = ObtenerBodega(bodegaACrear.idbodega);
            return bodega;
        }

        public void EliminarPedido(string idPedido)
        {
            var query = from detallepedido in db.detallepedido.Where(x => (x.idpedido == idPedido))
                        select detallepedido;
            detallepedido resultado = query.FirstOrDefault();
            
            detallepedido pedido = resultado;
            
            db.detallepedido.Remove(pedido);
            db.SaveChanges();
        }

        public bodega ModificarBodega(bodega bodegaAModificar)
        {
            db.Entry(bodegaAModificar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            bodega bodega = ObtenerBodega(bodegaAModificar.idbodega);
            return bodega;
        }

        public detallepedido ModificarDetallePedido(detallepedido detallepedidoAModificar)
        {
            db.Entry(detallepedidoAModificar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            detallepedido detallepedido = ObtenerDetalle(detallepedidoAModificar.idpedido);
            return detallepedido;
        }

        public pedido ModificarPedido(pedido pedidoAModificar)
        {
            db.Entry(pedidoAModificar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            pedido pedido = ObtenerPedido(pedidoAModificar.idpedido);
            return pedido;
        }
        public bodega ObtenerBodega(string idbodega)
        {
            var query = from bodega in db.bodega.Where(x => (x.idbodega == idbodega))
                        select bodega;
            bodega resultado = query.FirstOrDefault();
            return resultado;
        }

        public List<BodegaProductos> ObtenerBodegaProductos(string idbodega)
        {
            var query = from a in db.producto.Where(x => (x.idbodega == idbodega))
                        join b in db.categoria on a.idcategoria equals b.idcategoria
                        select new BodegaProductos
                        {
                            id = a.id,
                            idproducto = a.idproducto,
                            nombre = a.nombre,
                            imagen = a.imagen,
                            precio = a.precio,
                            activo = a.activo,
                            idcategoria = a.idcategoria,
                            descategoria = b.catgoria
                        };
            return query.ToList();
        }

        public bodega ObtenerBodegaUser(string iduser)
        {
            var query = from bodega in db.bodega.Where(x => (x.iduser == iduser))
                        select bodega;
            bodega resultado = query.FirstOrDefault();
            return resultado;
        }

        public List<DetallePedido> obtenerDetallePedido(string idPedido)
        {
              var query = from detallepedido in db.detallepedido.Where(x => (x.idpedido == idPedido))
                          select new DetallePedido
                          {
                              idPedido = detallepedido.idpedido,
                              idProducto = detallepedido.idproducto,
                              precio = detallepedido.precio,
                              cantidad = detallepedido.cantidad,
                              id = detallepedido.id
                          };

              return query.ToList(); 

        }

        public pedido ObtenerPedido(string idbodega)
        {
            var query = from pedido in db.pedido.Where(x => (x.idbodega == idbodega))
                        select pedido;
            pedido resultado = query.FirstOrDefault();
            return resultado;
        }

        public detallepedido ObtenerDetalle(string idpedido)
        {
            var query = from detallepedido in db.detallepedido.Where(x => (x.idpedido == idpedido))
                        select detallepedido;
            detallepedido res = query.FirstOrDefault();
            return res;
        }
        List<PedidoBodega> IBodegaService.ObtenerPedidoBodega(string idbodega)
        {
            var query = from pedido in db.pedido.Where(x => (x.idbodega == idbodega))
                        select new PedidoBodega
                        {
                            idPedido = pedido.idpedido,
                            idCliente = pedido.idcliente,
                            idBodega = pedido.idbodega,
                            monto = pedido.monto,
                            fechaRegistro = pedido.fechaRegistro,
                            fechaEntrega = pedido.fechaEntrega,
                            estado = pedido.estado
                        };
           
            return query.ToList();

        }
    }
}
