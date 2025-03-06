using NegocioBDD;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3VaccaroNicolas
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public string UrlImagen { get; set; }
        public bool Confirmacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.RedirigirAlHome();
                this.RedirigirSiNoEsAdmin();

                if (!IsPostBack)
                {
                    Confirmacion = false;
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

                    this.cargarArticulo(negocioArticulo);

                }

                
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error", false);
            }
        }

        private void RedirigirSiNoEsAdmin()
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("error", "Debe ser admin para entrar en esta pagina!");
                Response.Redirect("Error");
            }
        }

        private void RedirigirAlHome()
        {
            if (!Seguridad.sesionAbierta(Session["user"]))
            {
                Response.Redirect("Default");
            }
        }

        private void cargarArticulo(NegocioArticulo negocio)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
            if (id != "")
            {
                Articulo articulo = (negocio.ListarArticulos(id))[0];
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

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            UrlImagen = txtImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioArticulo negocio = new NegocioArticulo();
                Articulo articuloNuevo = new Articulo();

                articuloNuevo.Codigo = txtCodigo.Text;
                articuloNuevo.Nombre = txtNombre.Text;
                articuloNuevo.Descripcion = txtDescripcion.Text;
                articuloNuevo.Marca = new Marca();
                articuloNuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articuloNuevo.Categoria = new Categoria();
                articuloNuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articuloNuevo.UrlImagen = txtImagen.Text;
                articuloNuevo.Precio = decimal.Parse(txtPrecio.Text);

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                if (id == "")
                {
                    negocio.agregarNuevoArticulo(articuloNuevo);
                }
                else
                {
                    articuloNuevo.Id = int.Parse(id);
                    negocio.modificarArticulo(articuloNuevo);
                }
                Response.Redirect("Default", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Confirmacion = true;
        }

        protected void btnEliminarConfirmacion_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioArticulo negocio = new NegocioArticulo();    
                if (chkConfirmacion.Checked)
                {
                    negocio.borrarArticulo(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("Default", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Default", false);
            }
        }
    }
}