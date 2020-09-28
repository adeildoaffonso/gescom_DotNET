<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeguradoDetalhe.aspx.cs" Inherits="GESCOM.SeguradoDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div style="display:inline-block">
                <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" /></div>
                <div style="display:inline-block"><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click"/></div>
                <asp:Button runat="server" ID="Button1" Text="Voltar" OnClick="btnVoltar_Click"  />
        </div>
    
        <p/>

        <div>
            <div style="display:inline-block"><span>Detalhes do Segurado</span></div>
        </div>

        <p/>

        <div>
            <asp:label runat="server" ID="lblNome" Text="Nome" />
            <asp:TextBox runat="server" ID="txtNome" />

            <asp:label runat="server" ID="lblCPF_CNPJ" Text="CPF / CNPJ" />
            <asp:TextBox runat="server" ID="txtCPF_CNPJ" />

            <asp:label runat="server" ID="lblEmail" Text="Email" />
            <asp:TextBox runat="server" ID="txtEmail" />
        </div>
    </div>
</asp:Content>
