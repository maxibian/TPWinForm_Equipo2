using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Net;

namespace negocio
{
    public class ArticuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("SELECT Nombre, Descripcion, Precio from ARTICULOS");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    //aux.Id = (int)datos.Lector["Id"];
                    //aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //aux.IdMarca=(Marca)
                    //aux.Categoria=(Categoria)
                    //aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Nombre, Descripcion, Precio)values(1,1,1)");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET ....");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminar(Articulo art) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS Where Id =....");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
