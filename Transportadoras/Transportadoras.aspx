<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transportadoras.aspx.cs" Inherits="Transportadoras.Transportadoras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="lnkNovo" NavigateUrl="TransportadoraDetalhe.aspx" runat="server">Transportadora</asp:HyperLink>
    
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <%--<asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Bind("Nome") %>' PostBackUrl='UsuarioDetalhe.aspx?Id=<%# Eval("Id") %>'></asp:LinkButton>--%><a href='TransportadoraDetalhe.aspx?Id=<%# Eval("Id") %>'><%# Eval("Nome") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nota">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="lstNota" runat="server" Height="25px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="64px" 
                        CommandArgument='<%# Eval("Id") %>'   AutoPostBack="True">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Eval("Id") %>' />
                    <asp:HiddenField ID="hdfNota" runat="server" Value='<%# Eval("Nota") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Media" HeaderText="Média" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkExcluir" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' OnClick="LinkButton1_Click" Text="Excluir"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
