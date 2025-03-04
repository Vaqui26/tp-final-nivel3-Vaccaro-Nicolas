using NegocioBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Objetos;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgAvatar.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToK4qEfbnd-RN82wdL2awn_PMviy_pelocqQ&s";
            if(!(Page is Login || Page is Registrarse || Page is Error || Page is _Default))
            {
                if (!Seguridad.sesionAbierta(Session["user"]))
                {
                    Response.Redirect("Login", false);
                }
            }
            if (Seguridad.sesionAbierta(Session["user"]))
            {
                User user = (User)Session["user"];
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    ImgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
            }
        }

        protected void btnDesloguearse_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("Login", false);
        }
    }
}