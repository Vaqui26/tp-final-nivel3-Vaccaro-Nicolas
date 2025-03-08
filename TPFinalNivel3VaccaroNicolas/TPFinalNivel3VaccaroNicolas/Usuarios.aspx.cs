using System;
using NegocioBDD;
using Objetos;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if(!IsPostBack && Seguridad.esAdmin(Session["user"]))
				{
				NegocioUsers negocio = new NegocioUsers();
				User admin = (User)Session["user"];
				dvgUsuarios.DataSource = negocio.listaUsuarios(admin.Id);
				dvgUsuarios.DataBind();

				}
				else
				{
					Session.Add("error", "Debe ser admin para ingresar a esta pagina!");
					Response.Redirect("Error", false);
				}
			}
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
			{

				Session.Add("error", ex.Message);
				Response.Redirect("Default", false);
			}
        }
    }
}