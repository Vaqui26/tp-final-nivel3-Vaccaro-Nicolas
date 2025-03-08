using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
		public int registrarUser(User user)
		{
			ManejoBDD accesoDatos = new ManejoBDD();

			try
			{
				accesoDatos.setearConsulta("Insert into USERS (email, pass) output inserted.Id values (@email, @pass);");
				accesoDatos.setearParametros("@email", user.Email);
				accesoDatos.setearParametros("@pass", user.Pass);

				return accesoDatos.ejecutarAccionScalar();
				
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

		public List<User> listaUsuarios(int id)
		{
			ManejoBDD accesoDatos = new ManejoBDD();
			List<User> lista = new List<User>();
			try
			{
				accesoDatos.setearConsulta("Select id, email, nombre, apellido, admin From USERS where id != @id;");
				accesoDatos.setearParametros("@id", id);
				accesoDatos.ejecutarLectura();

                while(accesoDatos.Lector.Read())
                {
					User user = new User();
                    user.Id = int.Parse(accesoDatos.Lector["Id"].ToString());
					user.Email = accesoDatos.Lector["email"].ToString();
                    if (!(accesoDatos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)accesoDatos.Lector["nombre"];
                    if (!(accesoDatos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)accesoDatos.Lector["apellido"];
                    user.Admin = bool.Parse(accesoDatos.Lector["admin"].ToString());

					lista.Add(user);	
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
