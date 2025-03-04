using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioBDD;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class _Default : Page
    {
        public string ImagenNoEncontrada = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtVsPEPP89yxMYU0Mvt9zTNl1wDzJRCiIDuQ&s";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioArticulo negocio = new NegocioArticulo();
                repRepetidor.DataSource = negocio.ListarArticulos();
                repRepetidor.DataBind();
            }
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            var Id = ((Button)sender).CommandArgument;
            Response.Redirect("InfoArticulo?Id=" + Id, false);
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedValue.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioArticulo negocio = new NegocioArticulo();
                repRepetidor.DataSource = negocio.filtrarArticulos(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(),
                    txtFiltro.Text);
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();
            repRepetidor.DataSource = negocio.ListarArticulos();
            repRepetidor.DataBind();

            txtFiltro.Text = "";
            ddlCriterio.Items.Clear();
            ddlCampo.SelectedIndex = 0;
        }
    }
}