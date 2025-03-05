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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public string UrlImagen { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioArticulo negocioArticulo = new NegocioArticulo();
                NegocioMarca negocioMarca = new NegocioMarca();
                NegocioCategoria negocioCategoria = new NegocioCategoria();

                lblTitulo.Text = "Nuevo Producto";
                btnAceptar.Text = "Agregar";

                ddlMarca.DataSource = negocioMarca.listarMarca();
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                ddlCategoria.DataSource = negocioCategoria.listarCategoria();
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                if (id != "")
                {
                    Articulo articulo = (negocioArticulo.ListarArticulos(id))[0];
                    lblTitulo.Text = "Modificacion del articulo " + articulo.Nombre;
                    btnAceptar.Text = "Modificar";

                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtDescripcion.Text = articulo.Descripcion;
                    UrlImagen = articulo.UrlImagen;
                    txtImagen.Text = articulo.UrlImagen;
                    ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();  

                }

            }
        }
    }
}