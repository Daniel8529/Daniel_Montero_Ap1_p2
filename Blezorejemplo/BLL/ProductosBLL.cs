using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using Blezorejemplo.Entidades;
using Blezorejemplo.DAL;
using System.Linq.Expressions;

namespace Blezorejemplo.BLL
{
    public class ProductosBLL
    {
        private Contexto contexto;

        public ProductosBLL(Contexto _contexto)
        {
            contexto = _contexto;
        }
        Productos productos = new Productos();
        Productosdetalle productosdetalle = new Productosdetalle();
         Productospaquete productospaquete = new Productospaquete();
        /*  Productospaquete productospaquete = new Productospaquete(); */
        public bool insertar(Productos inseta)
        {
            bool paso = false;
            try
            {
                if (Existe(inseta.Descripcion) || Existes(inseta.ProductoId))
                    return Modificar(inseta);
                else
                    contexto.Productos.Add(inseta);

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Insertar(Productospaquete inseta)
        {
            bool paso = false;
            try
            {

                contexto.productospaquetes.Add(inseta);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Productos? Buscar(int ProductoId)
        {

            Productos? productos;
            try
            {
                productos = contexto.Productos.Find(ProductoId);
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }
        public Productospaquete? Buscarpaquete(int ProductoId)
        {

            Productospaquete? productos;
            try
            {
                productos = contexto.productospaquetes.Find(ProductoId);
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }
        public bool Existe(string descripcion)
        {

            bool encontrado = false;

            try
            {
                encontrado = contexto.Productos.Any(l => l.Descripcion.ToLower() == descripcion.ToLower());
            }
            catch (Exception)
            {
                throw;
            }

            return encontrado;
        }
        
        private bool Modificar(Productos producto)
        {
            bool paso = false;
         


            try
            {
                 
                
                contexto.Database.ExecuteSqlRaw($"DELETE FROM Productosdetalle WHERE ProductoId={producto.ProductoId}");

                foreach (var Anterior in producto.DetalleProducto)
                {
                    contexto.Entry(Anterior).State = EntityState.Added;
                }

                contexto.Entry(producto).State = EntityState.Modified;

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
           public bool Modificarpararestar(Productos producto, Productospaquete productospaquete)
        {
            bool paso = false;

            try
            {
                paso = contexto.SaveChanges() > 0;

                foreach (var item in productospaquete.AyudaPaquete)
                {
                    Productos encontrado = contexto.Productos.Find(item.Idresta);

                    encontrado.Existencia -= item.Cantidad;
                    encontrado.Ganancia = (int)((producto.Precio - producto.Costo) * 100) / producto.Costo;
                    encontrado.ValorInventario = producto.Existencia * producto.Costo;

                    contexto.Entry(encontrado).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;

                }


                contexto.Database.ExecuteSqlRaw($"DELETE FROM Productosdetalle WHERE ProductoId={producto.ProductoId}");

                foreach (var Anterior in producto.DetalleProducto)
                {
                    contexto.Entry(Anterior).State = EntityState.Added;
                }

                contexto.Entry(producto).State = EntityState.Modified;

                paso = contexto.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }






        public bool Eliminar(int id)
        {
            bool paso = false;


            try
            {

                var adicionales = contexto.Productos.Find(id);
                if (adicionales != null)
                {


                    contexto.Productos.Remove(adicionales);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;


        }
        public bool EliminarEmpaquetado(int id)
        {
            bool paso = false;


            try
            {

                var adicionales = contexto.productospaquetes.Find(id);
                if (adicionales != null)
                {


                    contexto.productospaquetes.Remove(adicionales);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;


        }


        public bool Existes(int id)
        {


            bool encontrado = false;

            try
            {

                encontrado = contexto.Productos.Any(e => e.ProductoId == id);

            }
            catch (Exception)
            {
                throw;
            }

            return encontrado;

        }
         public List<Productoparaayuda> GetListAyuda(Expression<Func<Productoparaayuda, bool>> criterio)
        {

            List<Productoparaayuda> lista = new List<Productoparaayuda>();
            try
            {
                lista = contexto.Productoparaayuda.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
        public List<Productospaquete> GetListEmpaquetado(Expression<Func<Productospaquete, bool>> criterio)
        {

            List<Productospaquete> lista = new List<Productospaquete>();
            try
            {
                lista = contexto.productospaquetes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
        public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {

            List<Productos> lista = new List<Productos>();
            try
            {
                lista = contexto.Productos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
        /*    public List<Productosdetalle> GetListd(Expression<Func<Productosdetalle, bool>> criterio)
           {
               List<Productosdetalle> lista = new List<Productosdetalle>();
               try
               {
                   lista = contexto.ProductosDetalle.Where(criterio).ToList();
               }
               catch (Exception)
               {
                   throw;
               }

               return lista;
           } */
        public List<Productos> GeLista()
        {

            return contexto.Productos.ToList();



        }
        /*  public List<Productosdetalle> GeListad()
         {

             return contexto.ProductosDetalle.ToList();



         } */
        public List<Productospaquete> GeListapaquete()
        {

            return contexto.productospaquetes.ToList();



        }





    }

}