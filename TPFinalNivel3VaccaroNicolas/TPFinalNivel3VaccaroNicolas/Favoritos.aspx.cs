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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Seguridad.sesionAbierta(Session["user"]))
            {
                User user = (User)Session["user"];
                NegocioFavorito negocio = new NegocioFavorito();
                dvgArticulos.DataSource = negocio.listaArticulosFavoritos(user.Id);
                dvgArticulos.DataBind();

            }
        }
    }
}