<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgenciadorDetalhe.aspx.cs" Inherits="GESCOM.AgenciadorDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <div style="display:inline-block">
            <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" /></div>
            <div style="display:inline-block"><asp:Button runat="server" IDl="btnSavar" Text="Salvar" OnClick="btnSalvar_Click"/></div>
            <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    
        <p/>

        <div>
            <div style="display:inline-block"><span>Detalhes do Agenciador</span></div>
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
        <div>
            
        </div>
    </div>
</asp:Content>
