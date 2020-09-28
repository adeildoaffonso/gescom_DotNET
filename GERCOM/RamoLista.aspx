<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RamoLista.aspx.cs" Inherits="GESCOM.RamoLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <div>
        <div>
            <div><asp:Button runat="server" ID="btnNovo" Text="Novo" OnClick="btnNovo_Click" /></div><p />
            <div><span>Lista de Ramos</span></div>
        </div>

        <p />

        <div>
            <asp:GridView ID="gvRamo" runat="server" OnRowDataBound="gvRamo_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:HyperLink id="lnkEditar" runat="server" Text="Código" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="descricao" headerText="Descrição" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
