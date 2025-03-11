<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoArticulo.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.InfoArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>

    <h2 class="pt-2">Info del Articulo</h2>
    <hr />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-check">Imagen</label>
                <asp:Image runat="server" ID="imgArticulo" Style="width: 414px; height: 414px; margin-left: 10%;" />
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Descripcion</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Marca</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtMarca"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Categoria</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCategoria"></asp:TextBox>
            </div>
            <div class="mb-3 d-grid">
                <label for="lblPrecio" class="form-label fs-5">Precio</label>
                <asp:Label runat="server" ID="lblPrecio" CssClass="fs-1"></asp:Label>
            </div>
            <div class="mb-3 pt-3">
                <a href="Default.aspx" class="btn btn-outline-primary">Regresar</a>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <%if (NegocioBDD.Seguridad.sesionAbierta(Session["user"]))
                            { %>
                        <asp:Button runat="server" ID="btnFavorito" Text="Agregar a Favoritos" CssClass="btn btn-success mt-2" OnClick="btnFavorito_Click"/>
                        <asp:Label runat="server" ID="lblFavorito" CssClass="h5"></asp:Label>
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
