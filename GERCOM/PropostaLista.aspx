<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PropostaLista.aspx.cs" Inherits="GESCOM.PropostaLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <div>
            <div><span>Lista de Propostas</span></div>
        </div>

        <div>
            <asp:GridView ID="gvProposta" runat="server" OnRowDataBound="gvProposta_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:HyperLink id="lnkEditar" runat="server" Text="Código" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cotacao_tb.premio" headerText="Prêmio" />
                    <asp:BoundField DataField="premio_liquido" headerText="Prêmio Líquido" />
                    <asp:BoundField DataField="data_emissao" headerText="Data Emissão" />
                    <asp:BoundField DataField="parcelamento" headerText="Parcelamento" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
