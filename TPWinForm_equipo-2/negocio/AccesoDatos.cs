using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos(string acceso)
        {
            conexion = new SqlConnection(acceso);
            comando = new SqlCommand();
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection(/*"server=localhost,1433; database=CATALOGO_P3_DB; user=sa; password=BaseDatos#2"*/);
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                //lector = comando.ExecuteReader();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarConsulta()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                object resultado = comando.ExecuteScalar();

                if (resultado != null) return 1;

                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if(lector != null)
               lector.Close();
            conexion.Close();
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}
