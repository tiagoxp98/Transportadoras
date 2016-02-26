<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Transportadoras.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Usuarios</h1>
    </hgroup>

    <article>
        <p>        
            <a href="UsuarioDetalhe.aspx">Novo Usuário</a></p>
        <p>        
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <%--<EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Nome") %>'></asp:TextBox>
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Bind("Nome") %>' PostBackUrl='UsuarioDetalhe.aspx?Id=<%# Eval("Id") %>'></asp:LinkButton>--%>
                            <a href='UsuarioDetalhe.aspx?Id=<%# Eval("Id") %>'><%# Eval("Nome") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Id") %>' OnClick="LinkButton1_Click" Text="Excluir"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </p>

    </article>

    </asp:Content>