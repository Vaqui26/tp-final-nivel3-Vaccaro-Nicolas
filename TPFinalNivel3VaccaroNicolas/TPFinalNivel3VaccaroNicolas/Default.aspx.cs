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
    }
}