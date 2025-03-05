<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="margin-top: 10px">Bienvenido a mi Web</h2>
    <hr />
    <h3>Lista de Productos</h3>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <label for="ddlCampo" class="form-label">Campo</label>
                <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre"></asp:ListItem>
                    <asp:ListItem Text="Marca"></asp:ListItem>
                    <asp:ListItem Text="Categoria"></asp:ListItem>
                    <asp:ListItem Text="Precio"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <label for="ddlCriterio" class="form-label">Criterio</label>
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-select"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <label for="txtFiltro" class="form-label">Filtro</label>
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-3">
            <div class="mb-3 pt-4">
                <label class="form-label">Filtrar :</label>
                <asp:Button runat="server" ID="btnFiltro" CssClass="btn btn-success" Text="Buscar" OnClick="btnFiltro_Click" />
            </div>
        </div>
    </div>
    <% if (filtroCampo)
        { %>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <label for="ddlCampo1" class="form-label">Campo</label>
                <asp:DropDownList runat="server" ID="ddlCampoAlt" CssClass="form-select">
                    <asp:ListItem Text="Samsung"></asp:ListItem>
                    <asp:ListItem Text="Apple"></asp:ListItem>
                    <asp:ListItem Text="Sony"></asp:ListItem>
                    <asp:ListItem Text="Huawei"></asp:ListItem>
                    <asp:ListItem Text="Motorola"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <label for="ddlCategoria1" class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoriaAlt" CssClass="form-select">
                    <asp:ListItem Text="Celulares"></asp:ListItem>
                    <asp:ListItem Text="Televisores"></asp:ListItem>
                    <asp:ListItem Text="Media"></asp:ListItem>
                    <asp:ListItem Text="Audio"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3 pt-4">
                <label class="form-label">Filtrar :</label>
                <asp:Button runat="server" ID="btnFiltroAlt" CssClass="btn btn-success" Text="Buscar" OnClick="btnFiltroAlt_Click" />
            </div>
        </div>
    </div>

    <%}%>
    <asp:Button runat="server" ID="btnLimpiar" CssClass="btn btn-warning mb-2" Text="Limpiar" OnClick="btnLimpiar_Click" />
    <asp:CheckBox runat="server" ID="chkFiltro" Text="Filtrar por Campos" AutoPostBack="true" OnCheckedChanged="chkFiltro_CheckedChanged" />

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("UrlImagen")%>" class="card-img-top" alt="articulo.png" onerror="this.src='<%: this.ImagenNoEncontrada %>';" style="height: 414px">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre")%></h5>
                            <p class="card-text"><%# Eval("Descripcion")%></p>
                            <asp:Button runat="server" ID="btnInfo" Text="Informacion del Articulo" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId"
                                CssClass="btn btn-primary" OnClick="btnInfo_Click" />
                            <%if (NegocioBDD.Seguridad.esAdmin(Session["user"]))
                                { %>
                            <asp:Button runat="server" ID="btnModificar" Text="Modificar" CssClass="btn btn-success" />
                               <% } %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
