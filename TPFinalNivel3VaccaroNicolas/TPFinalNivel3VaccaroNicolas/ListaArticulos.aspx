<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="h-2 pt-2">Lista de Articulos</h2>
    <hr />

    <%if (NegocioBDD.Seguridad.esAdmin(Session["user"])) 
      { %>
    <div class="mb-3">
        <label class="form-label">Agregar Articulo :</label>
        <a href="FormularioArticulo.aspx" class="btn btn-outline-success">Nuevo</a>
    </div>
    <% }%>
    <asp:GridView runat="server" ID="dvgArticulos" CssClass="table table-dark table-bordered text-center" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dvgArticulos_SelectedIndexChanged" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Informacion" />
        </Columns>
    </asp:GridView>

</asp:Content>
