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
				accesoDatos.setearConsulta("Select Id, email, pass From USERS where email=@email AND pass=@pass;");
				accesoDatos.setearParametros("email", user.Email);
				accesoDatos.setearParametros("pass", user.Pass);
				accesoDatos.ejecutarLectura();

				if (accesoDatos.Lector.Read())
				{
					user.Id = int.Parse(accesoDatos.Lector["Id"].ToString());
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
	}
}
