using NegocioBDD;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioUsers negocio = new NegocioUsers();
                User user = new User(txtEmail.Text, txtPass.Text);
                user.Id = negocio.registrarUser(user);

                Session.Add("user", user);
                Response.Redirect("Perfil", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error", false);
            }
        }
    }
}