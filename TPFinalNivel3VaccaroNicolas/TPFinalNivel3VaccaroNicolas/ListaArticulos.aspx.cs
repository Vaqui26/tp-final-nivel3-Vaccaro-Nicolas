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
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioArticulo negocio = new NegocioArticulo();
                Session.Add("listaArticulos", negocio.ListarArticulos());
                dvgArticulos.DataSource = (List<Articulo>)Session["listaArticulos"];
                dvgArticulos.DataBind();

            }
        }

        protected void dvgArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dvgArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo?Id=" + id, false);

        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];
                dvgArticulos.DataSource = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dvgArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("erro", ex.Message);
                Response.Redirect("Error", false);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Text = "";
                dvgArticulos.DataSource = (List<Articulo>)Session["listaArticulos"];
                dvgArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("erro", ex.Message);
                Response.Redirect("Error", false);
            }
        }
    }
}