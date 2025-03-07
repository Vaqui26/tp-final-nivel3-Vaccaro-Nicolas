using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioBDD
{
    public class NegocioFavorito
    {
        private List<Articulo> lista = new List<Articulo>();

        public List<Articulo> listaArticulosFavoritos(int id)
        {
            ManejoBDD accesoDatos = new ManejoBDD();
            try
            {
                accesoDatos.setearConsulta("  Select a.Id as ID,Codigo,a.Nombre,a.Descripcion as Desc_Articulo,IdMarca,m.descripcion as Desc_Marca,IdCategoria ,c.Descripcion as Desc_Categoria,ImagenUrl,Precio \r\n  From ARTICULOS as a Join MARCAS as m On IdMarca = m.Id Join CATEGORIAS as c On IdCategoria = c.Id\r\n  join FAVORITOS as f on f.IdArticulo = a.Id join USERS as u on f.IdUser = u.id where f.IdUser = @id;");
                accesoDatos.setearParametros("@id", id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    articuloAux.Id = (int)accesoDatos.Lector["ID"];
                    if (!(accesoDatos.Lector["Codigo"] is DBNull))
                        articuloAux.Codigo = (string)accesoDatos.Lector["Codigo"];
                    if (!(accesoDatos.Lector["Nombre"] is DBNull))
                        articuloAux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    if (!(accesoDatos.Lector["Desc_Articulo"] is DBNull))
                        articuloAux.Descripcion = (string)accesoDatos.Lector["Desc_Articulo"];
                    if (!(accesoDatos.Lector["ImagenUrl"] is DBNull))
                        articuloAux.UrlImagen = (string)accesoDatos.Lector["ImagenUrl"];
                    if (!(accesoDatos.Lector["Precio"] is DBNull))
                        articuloAux.Precio = (decimal)accesoDatos.Lector["Precio"];
                    articuloAux.Marca = new Marca();
                    if (!(accesoDatos.Lector["IdMarca"] is DBNull))
                        articuloAux.Marca.Id = (int)accesoDatos.Lector["IdMarca"];
                    articuloAux.Marca.Descripcion = (string)accesoDatos.Lector["Desc_Marca"];
                    articuloAux.Categoria = new Categoria();
                    if (!(accesoDatos.Lector["IdCategoria"] is DBNull))
                        articuloAux.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];
                    articuloAux.Categoria.Descripcion = (string)accesoDatos.Lector["Desc_Categoria"];

                    lista.Add(articuloAux);
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
        public void agregarFavorito(int idUser, int idArticulo)
        {
            ManejoBDD accesoDatos = new ManejoBDD();    

            try
            {
                accesoDatos.setearConsulta("insert into FAVORITOS values (@idUser,@idArticulo)");
                accesoDatos.setearParametros("@idUser", idUser);
                accesoDatos.setearParametros("@idArticulo", idArticulo);

                accesoDatos.ejecutarAccion();
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
        public bool verificarFavorito(int idUser, int idArticulo)
        {
            ManejoBDD accesoDatos = new ManejoBDD();

            try
            {
                accesoDatos.setearConsulta("Select f.id From FAVORITOS as f join ARTICULOS as a on f.IdArticulo = a.Id join USERS as u on f.IdUser = u.Id where f.IdUser = @idUser and f.IdArticulo = @idArticulo;");
                accesoDatos.setearParametros("@idUser", idUser);
                accesoDatos.setearParametros("@idArticulo", idArticulo);

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    return true;
                }
                return false;
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
        public void borrarFavorito(int idUser, int idArticulo)
        {
            ManejoBDD accesoDatos = new ManejoBDD();
            try
            {
                accesoDatos.setearConsulta("Delete From FAVORITOS where IdUser = @idUser and IdArticulo = @idArticulo;");
                accesoDatos.setearParametros("@idUser", idUser);
                accesoDatos.setearParametros("@idArticulo", idArticulo);

                accesoDatos.ejecutarAccion();
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
