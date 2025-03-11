<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .cajaText {
            height: 210px;
        }
    </style>
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>

    <h2 class="h2 pt-2">Mis Articulos Favoritos</h2>
    <hr />
    <% if (!existenFavoritos)
        {%>
    <asp:Label runat="server" ID="lblEmpty" CssClass="h6">Agrega un Articulo para ver tu lista de Favoritos: </asp:Label>
    <a href="Default.aspx" class="btn btn-outline-primary">Regresar</a>
    <%}
        else
        {%>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <asp:GridView runat="server" ID="dvgArticulos" CssClass="table table-dark table-bordered text-center" AutoGenerateColumns="false"
                        DataKeyNames="Id" OnSelectedIndexChanged="dvgArticulos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Informacion" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-6">
                    <div class="mb-3">
                        <img src="<% = imgArticulo %>" alt="imagenAvatar" style="height: 320px; width: 100%;"
                            onerror="this.src ='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtVsPEPP89yxMYU0Mvt9zTNl1wDzJRCiIDuQ&s';" />
                        <asp:TextBox runat="server" ID="txtInfoArticulo" CssClass="form-control cajaText" TextMode="MultiLine"></asp:TextBox>
                        <div class="row">
                            <div class="col-3">
                                <asp:Button runat="server" ID="btnDesfavorito" CssClass="btn btn-danger mt-2" Text="Sacar de Favoritos" OnClick="btnDesfavorito_Click" />
                            </div>
                            <div class="col ms-4 p-1">
                                <asp:Label runat="server" ID="lblError" CssClass="h6" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%}%>
</asp:Content>
