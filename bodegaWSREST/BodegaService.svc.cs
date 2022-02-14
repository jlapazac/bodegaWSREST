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

        public bodega ModificarBodega(bodega bodegaAModificar)
        {
            db.Entry(bodegaAModificar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            bodega bodega = ObtenerBodega(bodegaAModificar.idbodega);
            return bodega;
        }

        public bodega ObtenerBodega(string idbodega)
        {
            var query = from bodega in db.bodega.Where(x => (x.idbodega == idbodega))
                        select bodega;
            bodega resultado = query.First();
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
            bodega resultado = query.First();
            return resultado;
        }
    }
}
