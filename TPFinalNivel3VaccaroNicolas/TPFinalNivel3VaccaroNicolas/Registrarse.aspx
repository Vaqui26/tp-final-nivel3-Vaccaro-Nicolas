<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .validator {
            color: red;
            font-size: 15px;
            font-weight: 500;
            padding-left: 4px;
        }
    </style>
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <h2 class="h2 pt-2">Registro para la Web</h2>
            <hr />
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe llenar este campo!" ControlToValidate="txtEmail" runat="server" CssClass="validator" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe escribir una contraseña!" ControlToValidate="txtPass" runat="server" CssClass="validator" />
            </div>
            <div class="mb-4">
                <asp:Button runat="server" ID="btnRegistrar" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrar_Click" />
            </div>
        </div>
        <div class="col-4"></div>
    </div>

</asp:Content>
