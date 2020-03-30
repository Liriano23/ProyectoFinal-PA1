using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA1.DAL;
using ProyectoFinal_PA1.Entidades;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal_PA1.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Productos.Add(producto) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Productos producto)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(producto).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Productos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Productos Buscar(int id)
        {
            Productos producto = new Productos();
            Contexto db = new Contexto();
            try
            {
                producto = db.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return producto;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> producto)
        {
            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Productos.Where(producto).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }

        //Metodo para disminuir del inventario cuando se realice una venta
        public static bool DisminuirInventario(int id, int cantidad) 
        {
            bool paso = false;
            Contexto db = new Contexto();
            Productos producto = new Productos();
            producto = db.Productos.Find(id);

            if (producto != null)
            {
                try
                {
                    if (producto.Inventario > 0)
                        producto.Inventario = (producto.Inventario - cantidad);


                    db.Entry(producto).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
            }

            return paso;


        }

        //Metodo para Aumentar del inventario cuando se realice una venta
        public static bool AumentarInventario(int id, int cantidad) 
        {
            bool paso = false;
            Contexto db = new Contexto();
            Productos producto = new Productos();
            producto = db.Productos.Find(id);

            if (producto != null)
            {
                try
                {
                        producto.Inventario = (producto.Inventario + cantidad);


                    db.Entry(producto).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
            }

            return paso;


        }
    }
}
