<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="margin-top: 10px">Bienvenido a mi Web</h2>
    <hr />
    <h3>Lista de Productos</h3>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("UrlImagen")%>" class="card-img-top" alt="articulo.png" onerror="this.src='<%: this.ImagenNoEncontrada %>';">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre")%></h5>
                            <p class="card-text"><%# Eval("Descripcion")%></p>
                            <asp:Button runat="server" ID="btnModificar" Text="Info" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId"
                                CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
