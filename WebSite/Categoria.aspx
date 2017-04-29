<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categoria.aspx.cs" Inherits="Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:ListView ID="listNoticias" runat="server" DataSourceID="dsNoticias">
            <LayoutTemplate>
                <div runat="server" id="itemPlaceholder"></div>
            </LayoutTemplate>
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="linkCategoria" runat="server" Text='<%# Eval("cat_nome") %>' NavigateUrl='<%# Eval("cat_id","~/Noticia.aspx?cat={0}") %>' />
           </ItemTemplate>
        </asp:ListView>
    <asp:ObjectDataSource ID="dsNoticias" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DsGeralTableAdapters.TbCategoriaTableAdapter"></asp:ObjectDataSource>
    <p>
     <asp:DataPager ID="dataPager1" runat="server" PagedControlID="listNoticias" PageSize="4">   
        <Fields>
          <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="true" ShowLastPageButton="false" />
          <asp:NumericPagerField />
          <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true" ShowPreviousPageButton="false" ShowLastPageButton="true" />
        </Fields>
    </asp:DataPager>
    </p>
</asp:Content>

