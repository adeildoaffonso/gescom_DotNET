<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PropostaDetalhe.aspx.cs" Inherits="GESCOM.PropostaDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <div style="display:inline-block">
            <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click"/></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick ="btnSalvar_Click"/></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnComissao" Text="Gerar Comissão" OnClick ="btnComissao_Click"/></div>
            <div style="display:inline-block">
                <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
        </div>
    
        <p/>

        <div>
            <div style="display:inline-block"><span>Detalhes da Proposta</span></div>
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
                <asp:label runat="server" ID="lblPremio" Text="Prêmio Liquido" />
            </div>
            <div style="display:inline;width:450px;position:absolute;">
                <asp:TextBox runat="server" ID="txtPremio" />
            </div>
            <P/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblDataProposta" Text="Data Proposta" />
            </div>
            <div style="display:inline">
                <asp:TextBox runat="server" ID="txtDataProposta" />
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblDataEmissao" Text="Data Emissão" />
            </div>
            <div style="display:inline-block">
                <asp:TextBox runat="server" ID="txtDataEmissao" />
            </div>
            <P/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblParcelamento" Text="Parcelamento" />
            </div>
            <div style="display:inline">
                <asp:TextBox runat="server" ID="txtParcelamento" />
            </div>
            <p/>
            <P/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblAgenciamento" Text="Agenciamento" />
            </div>
            <div style="display:inline">
                <asp:CheckBox runat="server" ID="chkAgenciamento" />
            </div>

        </div>
    </div>
</asp:Content>
