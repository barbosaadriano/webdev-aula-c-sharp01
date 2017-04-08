<%@ Page Title="" Language="C#" MasterPageFile="~/Adm/MasterPage.master" AutoEventWireup="true" CodeFile="Categoria.aspx.cs" Inherits="Adm_Categoria" %>

<%@ Register Src="~/Adm/BarraEdicao.ascx" TagPrefix="uc1" TagName="BarraEdicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanelCategoria" runat="server">
        <ContentTemplate>
            <h1>Categorias
            </h1>
            <p>
                <asp:Button ID="btListagem" runat="server" OnClick="btListagem_Click" CssClass="btn-default btn" Text="Listagem" />
                <asp:Button ID="btCadastro" runat="server" OnClick="btCadastro_Click" CssClass="btn-default btn" Text="Cadastro" />
            </p>
            <asp:MultiView ID="MultiViewCategoria" runat="server">
                <asp:View ID="tabListagem" runat="server">
                    <h2>Listagem</h2>
                    <div class="row">

                        <div class="col-lg-6">
                            <asp:GridView CssClass="table-bordered table table-striped" ID="grdCategoria" runat="server"
                                 AutoGenerateColumns="False" DataKeyNames="cat_id" DataSourceID="dsCategoria"
                                OnSelectedIndexChanged="grdCategoria_SelectedIndexChanged" AllowSorting="true">
                                <Columns>
                                    <asp:BoundField DataField="cat_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="cat_id" />
                                    <asp:BoundField DataField="cat_nome" HeaderText="Nome da Categoria" SortExpression="cat_nome" />
                                    <asp:CommandField HeaderText="Selecionar" SelectText="Selecionar" ButtonType="Button" ControlStyle-CssClass="btn btn-info" ShowSelectButton="true"/>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="dsCategoria" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
                                TypeName="DsGeralTableAdapters.TbCategoriaTableAdapter"></asp:ObjectDataSource>
                        </div>

                    </div>
                </asp:View>
                <asp:View ID="tabCadastro" runat="server">
                    <h2>Cadastro</h2>
                    <div class="row">
                        <div class="col-lg-12">
                            <uc1:BarraEdicao runat="server" ID="BarraEdicao" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <asp:TextBox ID="edtCatId" runat="server" Visible="false" />
                        <div class="col-lg-6">
                            <asp:Label Text="Nome:" runat="server" />
                            <asp:TextBox ID="edtCatNome" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
