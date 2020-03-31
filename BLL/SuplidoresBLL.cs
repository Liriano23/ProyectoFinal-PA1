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
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Suplidores.Add(suplidores) != null)
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

        public static bool Modificar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(suplidores).State = EntityState.Modified;
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
                var eliminar = db.Suplidores.Find(id);
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

        public static Suplidores Buscar(int id)
        {
            Suplidores suplidores = new Suplidores();
            Contexto db = new Contexto();
            try
            {
                suplidores = db.Suplidores.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return suplidores;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidores)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Suplidores.Where(suplidores).ToList();
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
