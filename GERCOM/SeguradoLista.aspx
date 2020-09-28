<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeguradoLista.aspx.cs" Inherits="GESCOM.ClienteLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div>
            <div><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" /></div><p />
            <div><span>Lista de Clientes</span></div>
        </div>

        <p />

        <div>
            <asp:GridView ID="gvSegurado" runat="server" OnRowDataBound="gvSegurado_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:HyperLink id="lnkEditar" runat="server" Text="Código" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="pessoa_tb.nome" headerText="Nome" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
