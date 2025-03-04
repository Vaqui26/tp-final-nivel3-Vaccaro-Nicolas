using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioBDD
{
	public class NegocioUsers
	{

        public bool loginUser(User user)
		{
			ManejoBDD accesoDatos = new ManejoBDD();
			try
			{
				accesoDatos.setearConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin From USERS where email=@email AND pass=@pass;");
				accesoDatos.setearParametros("email", user.Email);
				accesoDatos.setearParametros("pass", user.Pass);
				accesoDatos.ejecutarLectura();

				if (accesoDatos.Lector.Read())
				{
					user.Id = int.Parse(accesoDatos.Lector["Id"].ToString());
					if (!(accesoDatos.Lector["nombre"] is DBNull))
						user.Nombre = (string)accesoDatos.Lector["nombre"];
                    if (!(accesoDatos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)accesoDatos.Lector["apellido"];
                    if (!(accesoDatos.Lector["urlImagenPerfil"] is DBNull))
                        user.ImagenPerfil = (string)accesoDatos.Lector["urlImagenPerfil"];
					user.Admin = bool.Parse(accesoDatos.Lector["admin"].ToString());

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
        public void actualizarUser(User user)
        {
			ManejoBDD accesoDatos = new ManejoBDD();
			try
			{
				accesoDatos.setearConsulta("Update USERS set nombre=@nombre, apellido=@apellido, urlImagenPerfil=@imagen where Id=@id;");
				accesoDatos.setearParametros("@nombre", (object)user.Nombre ?? DBNull.Value);
				accesoDatos.setearParametros("@apellido", (object)user.Apellido ?? DBNull.Value);
                accesoDatos.setearParametros("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
				accesoDatos.setearParametros("@id", user.Id);

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
