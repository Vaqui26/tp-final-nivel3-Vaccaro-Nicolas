using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace NegocioBDD
{
    public class NegocioCategoria
    {
        private List<Categoria> lista = new List<Categoria>();

        public List<Categoria> listarCategoria()
        {
            ManejoBDD accesoDatos = new ManejoBDD();

            try
            {
                accesoDatos.setearConsulta("Select Id, Descripcion From CATEGORIAS");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria categoriaAux = new Categoria();
                    categoriaAux.Id = (int)accesoDatos.Lector["Id"];
                    if(!(accesoDatos.Lector["Descripcion"] is DBNull))
                        categoriaAux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    lista.Add(categoriaAux);
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
