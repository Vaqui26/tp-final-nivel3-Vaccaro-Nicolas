<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3VaccaroNicolas.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="h2 pt-2">Mi Perfil de Usuario</h2>
    <hr />

    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-outline-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                <a href="Default.aspx" class="btn btn-outline-danger">Regresar</a>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-4">
            <div class="mb-3">
                <label for="txtImagen" class="form-label">Imagen Perfil</label>
                <input runat="server" id="txtImagenUrl" type="file" class="form-control" />
                <div class="pt-2 container" style="display: flex; justify-content: center;">
                    <asp:Image runat="server" ID="ImgPerfil" Style="height: 250px; width: 100%;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
