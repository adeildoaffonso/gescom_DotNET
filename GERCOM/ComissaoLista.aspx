<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComissaoLista.aspx.cs" Inherits="GESCOM.ComissaoLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <div><span>Lista de Comissões</span></div>
        </div>

        <div>
            <asp:GridView ID="gvComissao" runat="server" 
                OnRowDataBound="gvComissao_RowDataBound"
                AutoGenerateColumns="true">

            </asp:GridView>
        </div>
    </div>
</asp:Content>
