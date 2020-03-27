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
    public class CategoriasBLL
    {
        public static bool Guardar(Categorias categorias)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Categorias.Add(categorias) != null)
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

        public static bool Modificar(Categorias categorias)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(categorias).State = EntityState.Modified;
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
                var eliminar = db.Categorias.Find(id);
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

        public static Categorias Buscar(int id)
        {
            Categorias categorias = new Categorias();
            Contexto db = new Contexto();
            try
            {
                categorias = db.Categorias.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return categorias;
        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> categorias)
        {
            List<Categorias> lista = new List<Categorias>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Categorias.Where(categorias).ToList();
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
