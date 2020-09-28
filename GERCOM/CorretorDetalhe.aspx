<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CorretorDetalhe.aspx.cs" Inherits="GESCOM.CorretorDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style/style.css" rel="stylesheet" />
        <div style="width:600px;background-color:azure">
            <div style="display:inline-block">
                    <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" /></div>
                    <div style="display:inline-block"><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click"/></div>
                    <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click"  />
            </div>
    
            <p/>

            <div>
                <div style="display:inline-block"><span>Detalhes do Corretor</span></div>
            </div>

            <p/>

            <div style="width:600px;display:inline-flex">
                <div style="width:90px">
                    <asp:label runat="server" ID="lblNome" Text="Nome" CssClass="label" />
                </div>
                <div style="width:450px">
                    <asp:TextBox runat="server" ID="txtNome" style="width:350px" />
                </div>
                <span>&nbsp;</span>
            </div>


            <div style="width:600px;display:inline-flex;position:relative;top:10px;">
                <div style="width:90px">
                    <asp:label runat="server" ID="lblCPF_CNPJ" Text="CPF / CNPJ" CssClass="label"  />
                </div>
                <div style="width:90px;background-color:blue">
                    <asp:TextBox runat="server" ID="txtCPF_CNPJ" style="width:350px" />
                </div>
                <span>&nbsp;</span>
            </div>

            <div style="width:600px;display:inline-flex;position:relative;top:20px;">
                <div style="width:90px">
                    <asp:label runat="server" ID="lblCodigoSusep" Text="SUSEP" CssClass="label"  />
                </div>
                <div style="width:450px">
                    <asp:TextBox runat="server" ID="txtCodigoSUSEP" style="width:350px" />
                </div>
                
            </div>

            <div style="width:600px;display:inline-flex;position:relative;top:30px;">
                <div style="width:90px">
                    <asp:label runat="server" ID="lblEmail" Text="Email" CssClass="label"  />
                </div>
                <div style="width:450px">
                    <asp:TextBox runat="server" ID="txtEmail" style="width:350px" />
                </div>
            </div>
    </div>
</asp:Content>
