using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NegocioBDD
{
    public class ManejoBDD
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public ManejoBDD()
        {   //Prop: constructor nuevo, conecta directamene a la base de datos.
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {   // Prop: deja la consulta lista para ejercutar.
            
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
            
        }
        public void ejecutarLectura()
        {   //Prop : se conecta a la conexion a la base de datos y guardar la tabla en 
            // nuestro lector.

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
        public void cerrarConexion()
        {   //Prop : cierra tanto el lector, en caso de que se hiso un lectura, y la 
            // conexion.

            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setearParametros(string nombre,object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}
