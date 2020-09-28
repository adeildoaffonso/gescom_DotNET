
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CotacaoDetalhe.aspx.cs" Inherits="GESCOM.CotacaoDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <div style="display:inline-block">
            <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click"/></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick ="btnSalvar_Click"/></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnProposta" Text="Gerar Proposta" OnClick ="btnProposta_Click"/></div>
            <div style="display:inline-block">
                <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
        </div>
    
        <p/>

        <div>
            <div style="display:inline-block"><span>Detalhes da Cotação</span></div>
        </div>
        
        <p/>

        <div style="display:inline-block;width:750px">
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblCodigo" Text="Código" />
            </div>
            <div style="display:inline;width:450px;position:absolute;">
                <asp:TextBox runat="server" ID="txtCodigo" />
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblSegurado" Text="Segurado" />
            </div>
            <div style="display:inline">
                <asp:DropDownList ID="ddlSegurado" runat="server"></asp:DropDownList>
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblCorretor" Text="Corretor" />
            </div>
            <div style="display:inline">
                <asp:DropDownList ID="ddlCorretor" runat="server"></asp:DropDownList>
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblSeguradora" Text="Seguradora" />
            </div>
            <div style="display:inline">
                <asp:DropDownList ID="ddlSeguradora" runat="server"></asp:DropDownList>
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblRamo" Text="Ramo" />
            </div>
            <div style="display:inline">
                <asp:DropDownList ID="ddlRamo" runat="server"></asp:DropDownList>
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblPremio" Text="Prêmio" />
            </div>
            <div style="display:inline;width:450px;position:absolute;">
                <asp:TextBox runat="server" ID="txtPremio" />
            </div>
            <P/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblDataCotacao" Text="Data Cotação" />
            </div>
            <div style="display:inline">
                <asp:TextBox runat="server" ID="txtDataCotacao" />
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblInicioVigencia" Text="Inicio Vigência" />
            </div>
            <div style="display:inline-block">
                <asp:TextBox runat="server" ID="txtInicioVigencia" />
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblFimVigencia" Text="Fim Vigência" />
            </div>
            <div style="display:inline">
                <asp:TextBox runat="server" ID="txtFimVigencia" />
            </div>

        </div>
    </div>
    
</asp:Content>
