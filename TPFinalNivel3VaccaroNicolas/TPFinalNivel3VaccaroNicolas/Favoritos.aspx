<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="h2 pt-2">Mis Articulos Favoritos</h2>
    <hr />
    <div class="row">
        <div class="col-6">
            <asp:GridView runat="server" ID="dvgArticulos" CssClass="table table-dark table-bordered text-center" AutoGenerateColumns="false"
                DataKeyNames="Id">
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
    </div>

</asp:Content>
