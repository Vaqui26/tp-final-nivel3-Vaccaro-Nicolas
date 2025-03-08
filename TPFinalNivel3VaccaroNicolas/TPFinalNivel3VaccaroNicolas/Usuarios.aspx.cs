using System;
using NegocioBDD;
using Objetos;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!Seguridad.esAdmin(Session["user"]))
                {
                    Session.Add("error", "Debe ser admin para ingresar a esta pagina!");
                    Response.Redirect("Error");
                }
                if (!IsPostBack)
                {
                    NegocioUsers negocio = new NegocioUsers();
                    User admin = (User)Session["user"];
                    Session.Add("listaUsuarios", negocio.listaUsuarios(admin.Id));
                    dvgUsuarios.DataSource = (List<User>)Session["listaUsuarios"];
                    dvgUsuarios.DataBind();

                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Default", false);
            }
        }

        protected void dvgUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dvgUsuarios.SelectedDataKey.Value.ToString();
            try
            {
                NegocioUsers negocio = new NegocioUsers();
                User user = this.buscarUser(id);
                negocio.cambiarRolAdmin(user);

                Response.Redirect("Default", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Default", false);
            }
        }
        private User buscarUser(string id)
        {
            List<User> lista = (List<User>)Session["listaUsuarios"];
            return lista.Find(x => x.Id == int.Parse(id));
            
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            dvgUsuarios.DataSource = (List<User>)Session["listaUsuarios"];
            dvgUsuarios.DataBind();
        }

        protected void btnComun_Click(object sender, EventArgs e)
        {
            List<User> lista = (List<User>)Session["listaUsuarios"];
            dvgUsuarios.DataSource = lista.FindAll(x => !x.Admin);
            dvgUsuarios.DataBind();
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            List<User> lista = (List<User>)Session["listaUsuarios"];
            dvgUsuarios.DataSource = lista.FindAll(x => x.Admin);
            dvgUsuarios.DataBind();
        }
    }
}