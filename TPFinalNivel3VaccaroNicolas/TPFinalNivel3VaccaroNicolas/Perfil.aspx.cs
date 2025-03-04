using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Objetos;
using NegocioBDD;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionAbierta(Session["user"]) && !IsPostBack)
            {
                User user = (User)Session["user"];
                txtId.Text = user.Id.ToString();
                txtId.Enabled = false;
                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;

                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    ImgPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
                else
                {
                    ImgPerfil.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png?20210521171500";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioUsers negocio = new NegocioUsers();
                User user = (User)Session["user"];
                
                if (txtImagenUrl.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    string url = ruta + "perfil-" + user.Id + ".jpg";
                    txtImagenUrl.PostedFile.SaveAs(url);
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text != "" ? txtNombre.Text : null;
                user.Apellido = txtApellido.Text != "" ? txtApellido.Text : null;

                negocio.actualizarUser(user);
                Response.Redirect("Default", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error", false);
            }
        }
    }
}