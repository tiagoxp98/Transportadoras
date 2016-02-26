<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioDetalhe.aspx.cs" Inherits="Transportadoras.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <table style="width:100%;">
            <tr>
                <td>Código</td>
                <td>
                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Usuário</td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Senha</td>
                <td>
                    <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:CheckBox ID="ckbAdmin" runat="server" Text="Administrador" />
                </td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td>
                    
                    <asp:Button ID="Button1" runat="server" Text="Salvar" OnClick="Button1_Click" />
                    
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
