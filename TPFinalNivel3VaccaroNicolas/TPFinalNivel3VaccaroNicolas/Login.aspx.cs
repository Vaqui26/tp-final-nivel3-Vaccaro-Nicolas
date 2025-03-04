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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioUsers negocio = new NegocioUsers();
                User user = new User(txtEmail.Text,txtPass.Text);
                if (negocio.loginUser(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Default", false);
                }
                else
                {
                    Session.Add("error", "Email o Contraseña incorrectas!");
                    Response.Redirect("error", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error", false);
            }
        }
    }
}