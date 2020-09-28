<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeguradoraDetalhe.aspx.cs" Inherits="GESCOM.SeguradoraDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div>
        <div style="display:inline-block">
            <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" /></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click" /></div>
            <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    
        <p/>

        <div>
            <div style="display:inline-block"><span>Detalhes da Seguradora</span></div>
        </div>
        
        <p/>
        
        <div>
            <asp:label runat="server" ID="lblCodigo" Text="Código" />
            <asp:TextBox runat="server" ID="txtCodigo" />

            <asp:label runat="server" ID="lblNome" Text="Descrição" />
            <asp:TextBox runat="server" ID="txtDescricao" />

            <asp:label runat="server" ID="lblCNPJ" Text="CNPJ" />
            <asp:TextBox runat="server" ID="txtCNPJ" />

            <asp:label runat="server" ID="lblEmail" Text="Email" />
            <asp:TextBox runat="server" ID="txtEmail" />
        </div>
        
    </div>

</asp:Content>
