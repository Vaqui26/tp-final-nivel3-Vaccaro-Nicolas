<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="h2">Lista de Usuarios</h2>
    <hr />

    <asp:GridView runat="server" ID="dvgUsuarios" CssClass="table table-dark table-bordered text-center" AutoGenerateColumns="false"
        DataKeyNames="Id">
         <Columns>
             <asp:BoundField HeaderText="Nombre" DataField="Nombre" NullDisplayText="---"/>
             <asp:BoundField HeaderText="Apellido" DataField="Apellido" NullDisplayText="---"/>
             <asp:BoundField HeaderText="Email" DataField="Email" />
             <asp:CheckBoxField HeaderText="Admin" DataField="Admin" />
             <asp:CommandField ShowSelectButton="true" SelectText="✔️" HeaderText="Cambiar rol" />
         </Columns>
    </asp:GridView>
</asp:Content>
