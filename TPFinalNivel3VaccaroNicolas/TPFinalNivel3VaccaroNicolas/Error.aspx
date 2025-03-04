<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="h2 pt-2">Ups! Ocurrio un error</h2>
    <asp:label runat="server" ID="lblError" Text=""></asp:label>
    <a href="Default.aspx" class="btn btn-outline-info">Regresar</a>

</asp:Content>
