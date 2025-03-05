using NegocioBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioArticulo negocio = new NegocioArticulo();
                dvgArticulos.DataSource = negocio.ListarArticulos();
                dvgArticulos.DataBind();

            }
        }

        protected void dvgArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dvgArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo?Id=" + id, false);

        }
    }
}