<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .validator {
            color: red;
            font-size: 15px;
            font-weight: 500;
            padding-left: 4px;
        }
    </style>

    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>

    <asp:Label runat="server" ID="lblTitulo" CssClass="h2"></asp:Label>
    <hr />
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe Completar este Campo!!" ControlToValidate="txtCodigo" runat="server" CssClass="validator"/>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe Completar este Campo!!" ControlToValidate="txtNombre" runat="server" CssClass="validator"/>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe Completar este Campo!!" ControlToValidate="txtPrecio" runat="server" CssClass="validator"/>
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
                <asp:Button runat="server" ID="btnAceptar" CssClass="btn btn-success me-2" OnClick="btnAceptar_Click" />
                <a href="Default.aspx" class="btn btn-outline-dark">Regresar al home</a>
                <% if (Request.QueryString["id"] != null)
                    { %>
                <asp:UpdatePanel runat="server" ID="updatePanerl1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger mt-2" OnClick="btnEliminar_Click" />
                        <% if (Confirmacion)
                            { %>
                        <div class="mb-3 mt-2">
                            <asp:CheckBox runat="server" ID="chkConfirmacion" Text="Confimar Eliminacion" CssClass="form-check-input" />
                            <asp:Button runat="server" ID="btnEliminarConfirmacion" CssClass="btn btn-outline-danger" Text="Eliminar" OnClick="btnEliminarConfirmacion_Click" />
                        </div>
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <% } %>
            </div>
        </div>
        <div class="col-1"></div>
        <div class="col-4">
            <asp:UpdatePanel runat="server" ID="updatePanerl2" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label">Imagen de Articulo</label>
                        <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged"></asp:TextBox>
                        <img src="<% = UrlImagen %>" alt="imagenArticulo" style="height: 250px; width: 100%;"
                            onerror="this.src ='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtVsPEPP89yxMYU0Mvt9zTNl1wDzJRCiIDuQ&s';" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <asp:Label runat="server" ID="lblError" CssClass="validator" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
