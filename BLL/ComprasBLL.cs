using Microsoft.EntityFrameworkCore;
using ProyectoFinal_PA1.DAL;
using ProyectoFinal_PA1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProyectoFinal_PA1.BLL
{
    public class ComprasBLL
    {
        public static bool Guardar(Compras compra)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Compras.Add(compra) != null)
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

        public static bool Modificar(Compras compra)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                db.Database.ExecuteSqlRaw($"Delete FROM ComprasDetelle where CompraId = {compra.CompraId}");
                foreach (var item in compra.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(compra).State = EntityState.Modified;
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
                var eliminar = db.Compras.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
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

        public static Compras Buscar(int id)
        {
            Compras venta = new Compras();
            Contexto db = new Contexto();

            try
            {
                venta = db.Compras.Where(x => x.CompraId == id).
                     Include(y => y.Detalle).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return venta;
        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> compra)
        {
            List<Compras> lista = new List<Compras>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Compras.Where(compra).ToList();
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
    }
}
