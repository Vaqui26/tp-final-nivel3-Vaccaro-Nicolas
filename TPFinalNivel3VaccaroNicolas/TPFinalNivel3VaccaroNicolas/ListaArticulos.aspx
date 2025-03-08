<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="h-2 pt-2">Lista de Articulos</h2>
    <hr />

    <div class="row">
        <div class="col-auto pt-1">
            <label class="form-label">Buscar por Nombre :</label>
        </div>
        <div class="col-auto mb-3">
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>
        <div class="col-auto mb-3">
            <asp:Button runat="server" ID="btnLimpiar" CssClass="btn btn-warning" Text="Limpiar" OnClick="btnLimpiar_Click" />
        </div>
        <div class="col"></div>
        <div class="col-3">
            <label class="form-label">Agregar Articulo :</label>
            <a href="FormularioArticulo.aspx" class="btn btn-outline-success">Nuevo</a>
        </div>
    </div>
    <asp:GridView runat="server" ID="dvgArticulos" CssClass="table table-dark table-bordered text-center" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dvgArticulos_SelectedIndexChanged" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField ShowSelectButton="true" SelectText="✍" HeaderText="Modificar" />
        </Columns>
    </asp:GridView>

</asp:Content>
