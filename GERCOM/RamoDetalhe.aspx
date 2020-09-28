<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RamoDetalhe.aspx.cs" Inherits="GESCOM.RamoDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="display:inline-block">
            <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" /></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click" /></div>
            <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    
        <p/>

        <div>
            <div style="display:inline-block"><span>Detalhes do Ramo</span></div>
        </div>
        
        <p/>
        
        <div>
            <asp:label runat="server" ID="lblCodigo" Text="Código" />
            <asp:TextBox runat="server" ID="txtCodigo" />
            <asp:label runat="server" ID="lblDescricao" Text="Descrição" />
            <asp:TextBox runat="server" ID="txtDescricao" />
        </div>
        
    </div>
</asp:Content>
