<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CorretorLista.aspx.cs" Inherits="GESCOM.CorretorLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div>
        <div>
            <div><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" /></div><p />
            <div><span>Lista de Corretores</span></div>
        </div>

        <p />

        <div>
            <asp:GridView ID="gvCorretor" runat="server" OnRowDataBound="gvCorretor_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Código SUSEP">
                        <ItemTemplate>
                            <asp:HyperLink id="lnkEditar" runat="server" Text="Código SUSEP" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="pessoa_tb.nome" headerText="Nome" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
