<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="h2">Lista de Usuarios</h2>
    <hr />
    <div class="row">
        <div class="col pb-2">
            <asp:Button runat="server" ID="btnTodos" CssClass="btn btn-success" Text="Todos" OnClick="btnTodos_Click"/>
            <asp:Button runat="server" ID="btnComun" CssClass="btn btn-primary me-2 ms-2" Text="Comunes" OnClick="btnComun_Click"/>
            <asp:Button runat="server" ID="btnAdmin" CssClass="btn btn-warning" Text="Admins" OnClick="btnAdmin_Click"/>
        </div>
    </div>
    <asp:GridView runat="server" ID="dvgUsuarios" CssClass="table table-info table-bordered text-center" AutoGenerateColumns="false"
        DataKeyNames="Id" OnSelectedIndexChanged="dvgUsuarios_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" NullDisplayText="---" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" NullDisplayText="---" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:CheckBoxField HeaderText="Admin" DataField="Admin" />
            <asp:CommandField ShowSelectButton="true" SelectText="✔️" HeaderText="Cambiar rol" />
        </Columns>
    </asp:GridView>
</asp:Content>
