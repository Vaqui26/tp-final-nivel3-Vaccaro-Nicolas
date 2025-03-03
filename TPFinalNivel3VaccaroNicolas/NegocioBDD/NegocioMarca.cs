using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace NegocioBDD
{
    public class NegocioMarca
    {
        private List<Marca> lista = new List<Marca>();

        public List<Marca> listarMarca()
        {
            ManejoBDD accesoDatos = new ManejoBDD();

            try
            {
                accesoDatos.setearConsulta("Select Id, Descripcion From MARCAS");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marca marcaAux = new Marca();
                    marcaAux.Id = (int)accesoDatos.Lector["Id"];
                    if (!(accesoDatos.Lector["Descripcion"] is DBNull))
                        marcaAux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    lista.Add(marcaAux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
