using Microsoft.Ajax.Utilities;
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
        public string imgArticulo { get; set; }
        public bool existenFavoritos {  get; set; } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionAbierta(Session["user"]))
            {
                existenFavoritos = false;    
                User user = (User)Session["user"];
                NegocioFavorito negocio = new NegocioFavorito();
                List<Articulo> articulosFavoritos = negocio.listaArticulosFavoritos(user.Id);
                if (articulosFavoritos.Count() != 0)
                {
                    Session.Add("favoritos", articulosFavoritos);
                    dvgArticulos.DataSource = articulosFavoritos;
                    dvgArticulos.DataBind();
                    Articulo articulo = articulosFavoritos[0];
                    cargarArticulo(articulo.Id);
                    existenFavoritos = true;
                }

            }
        }

        protected void dvgArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dvgArticulos.SelectedDataKey.Value.ToString();
            lblError.Text = "";
            cargarArticulo(int.Parse(id));

        }

        private void cargarArticulo(int id)
        {
            Articulo articulo = ((List<Articulo>)Session["favoritos"]).Find(x => x.Id == id);
            txtInfoArticulo.Text = "Descripcion Completa del Articulo : " + "\r\nID Articulo : " + articulo.Id + "\r\nCodigo Articulo : " + articulo.Codigo + "\r\nNombre Articulo : " + articulo.Nombre + "\r\nMarca : " + articulo.Marca.Descripcion + "\r\nCategoria : " + articulo.Categoria.Descripcion + "\r\nPrecio : " + articulo.Precio + "\r\nDescripcion Articulo : " + articulo.Descripcion;
            txtInfoArticulo.ReadOnly = true;    
            imgArticulo = articulo.UrlImagen;
        }

        protected void btnDesfavorito_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioFavorito negocio = new NegocioFavorito();
                User user = (User)Session["user"];
                if(dvgArticulos.SelectedDataKey != null)
                {
                    int id = int.Parse(dvgArticulos.SelectedDataKey.Value.ToString());

                    negocio.borrarFavorito(user.Id, id);
                    Response.Redirect("Default", false);
                }
                else
                {
                    lblError.Text = "Debe seleccionar un articulo para borrar porfavor!\r\n" + "Presione en seleccionar en la tabla para borrar.";
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