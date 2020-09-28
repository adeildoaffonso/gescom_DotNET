<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComissaoDetalhe.aspx.cs" Inherits="GESCOM.ComissaoDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div style="display:inline-block">
            <div style="display:inline-block"><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click"/></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick ="btnSalvar_Click"/></div>
            <div style="display:inline-block"><asp:Button runat="server" ID="btnComissao" Text="Gerar Comissão" OnClick ="btnComissao_Click"/></div>
            <div style="display:inline-block">
                <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
        </div>
    
        <p/>

    <div style="display:inline-block;width:900px;">
        <div style="width:350px;float:left;"> <!-- *** COMISSÃO *** -->
            <div style="display:inline-block"><span>Detalhes Comissão</span></div>
            <P/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblImposto" Text="Imposto" />
            </div>
            <div style="display:inline">
                <asp:TextBox runat="server" ID="txtImposto" />
            </div>
            <P/>

            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblComissaoProposta" Text="Comissao Proposta" />
            </div>
            <div style="display:inline">
                <asp:TextBox runat="server" ID="txtComissaoProposta" />
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblValorBruto" Text="Valor Bruto" />
            </div>
            <div style="display:inline;width:450px;position:absolute;">
                <asp:TextBox runat="server" ID="txtValorBruto" />
            </div>
            <p/>
            <div style="display:inline-block;width:100px;">
                <asp:label runat="server" ID="lblValorLiquido" Text="Valor Liquido" />
            </div>
            <div style="display:inline-block">
                <asp:TextBox runat="server" ID="txtValorLiquido"  />
            </div>
        </div>
        <p/>
        <div style="display:block;float:right">
            <div style="width:500px;float:left;">  <!-- *** COMISSIONAMENTO *** -->
                <div style="display:inline-block"><span>Detalhes Comissionamento</span></div>
                            <P/>

                <div style="display:inline-block;width:100px;">
                    <asp:label runat="server" ID="lblCorretor" Text="Corretor" />
                </div>

                <div style="display:inline-block;width:100px;">
                    <asp:DropDownList runat="server" ID="ddlCorretor" Width="350px"/>
                </div>
                <p/>
                <div style="display:inline-block;width:100px;">
                    <asp:label runat="server" ID="lblComissionamento" Text="Comissionamento" />
                </div>
                <div style="display:inline">
                    <asp:TextBox runat="server" ID="txtComissionamento" />
                </div>
            </div>

            <div style="width:500px;">  <!-- *** AGENCIAMENTO *** -->
                <div style="display:inline-block"><span>Detalhes Agenciamento</span></div>
                <p/>

                <div style="display:inline-block;width:100px;">
                    <asp:label runat="server" ID="lblAgenciador" Text="Agenciador" />
                </div>
            
                <div style="display:inline-block;width:100px;">
                    <asp:DropDownList runat="server" ID="ddlAgenciador" Width="350px"/>
                </div>
                <p/>

                <div style="display:inline-block;width:100px;">
                    <asp:label runat="server" ID="lblAgenciamento" Text="Agenciamento" />
                </div>
                <div style="display:inline">
                    <asp:TextBox runat="server" ID="txtAgenciamento" />
                </div>
            </div>
        </div>

    </div>
    <p/>
    <div style="display:inline-block">
        <div style="background-color:aqua;float:left">
            <asp:GridView ID="grdCorretor" runat="server" AutoGenerateColumns="false">
<%--                <Columns>
                     <asp:BoundField DataField="pessoa_tb.nome" headerText="Nome" />
                </Columns>--%>
            </asp:GridView>
        </div>
        <div style="background-color:goldenrod;float:right">
            <asp:GridView ID="grdAgenciador" runat="server" AutoGenerateColumns="false">
<%--                <Columns>
                    <asp:BoundField DataField="pessoa_tb.nome" headerText="Nome" />
                </Columns>--%>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
