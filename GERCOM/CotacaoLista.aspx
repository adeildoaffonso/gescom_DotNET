<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CotacaoLista.aspx.cs" Inherits="GESCOM.CotacaoLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <div>
            <div><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click"/></div><p />
            <div><span>Lista de Cotações</span></div>
        </div>

        <div>
            <asp:GridView ID="gvCotacao" runat="server" OnRowDataBound="gvCotacao_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:HyperLink id="lnkEditar" runat="server" Text="Código" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="segurado_tb.pessoa_tb.nome" headerText="Segurado" />
                    <asp:BoundField DataField="ramo_tb.descricao" headerText="Ramo" />
                    <asp:BoundField DataField="data_cotacao" headerText="Data Cotação" />
                    <asp:BoundField DataField="corretor_tb.pessoa_tb.nome" headerText="Corretor" />
                    <asp:BoundField DataField="seguradora_tb.pessoa_tb.nome" headerText="Seguradora" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
