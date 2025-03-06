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
    public partial class InfoArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["Id"] != null)
            {
                
                NegocioArticulo negocio = new NegocioArticulo();    
                List<Articulo> lista = negocio.ListarArticulos();
                Articulo art = lista.Find(x => x.Id == int.Parse(Request.QueryString["Id"].ToString()));

                if (!(string.IsNullOrEmpty(art.UrlImagen))){
                    imgArticulo.ImageUrl = art.UrlImagen;
                }
                txtCodigo.Text = art.Codigo;
                txtCodigo.ReadOnly = true;  
                txtNombre.Text = art.Nombre;
                txtNombre.ReadOnly = true;  
                txtDescripcion.Text = art.Descripcion;
                txtDescripcion.ReadOnly = true; 
                txtMarca.Text = art.Marca.Descripcion;
                txtMarca.ReadOnly = true;
                txtCategoria.Text = art.Categoria.Descripcion;
                txtCategoria.ReadOnly = true;  
                lblPrecio.Text = "$" + art.Precio;

            }
          
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioFavorito negocio = new NegocioFavorito();
                User user = (User)Session["user"];
                int idArticulo = int.Parse(Request.QueryString["id"].ToString());
                if (!negocio.verificarFavorito(user.Id, idArticulo))
                {
                    negocio.agregarFavorito(user.Id, idArticulo);
                    lblFavorito.Text = "Articulo agregado con exito!!!";
                }
                else
                {
                    lblFavorito.Text = "Ya posees este Articulo en tus Favoritos!";
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error", false);
            }
        }
    }
}