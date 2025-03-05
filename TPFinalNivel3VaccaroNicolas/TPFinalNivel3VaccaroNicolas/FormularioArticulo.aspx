<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="lblTitulo" CssClass="h2"></asp:Label>
    <hr />
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row">
                <div class="col">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMarca"></asp:DropDownList>
                </div>
                <div class="col">
                    <label for="ddlCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCategoria"></asp:DropDownList>
                </div>
            </div>
            <div class="mb-3 pt-4">
                <asp:Button runat="server" ID="btnAceptar" CssClass="btn btn-success" />
            </div>
        </div>
        <div class="col-1"></div>
        <div class="col-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Articulo</label>
                <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control"></asp:TextBox>
                <img src="<% = UrlImagen %>" alt="imagenArticulo" style="height: 250px; width: 100%;"
                    onerror="this.src ='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtVsPEPP89yxMYU0Mvt9zTNl1wDzJRCiIDuQ&s';" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
