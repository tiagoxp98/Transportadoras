<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransportadoraDetalhe.aspx.cs" Inherits="Transportadoras.TransportadoraDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>Código</td>
            <td>
                <asp:Label ID="lblCodigo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Transportadora</td>
            <td>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Salvar" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
