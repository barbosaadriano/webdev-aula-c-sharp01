<%@ Page Title="" Language="C#" MasterPageFile="~/Adm/MasterPage.master" AutoEventWireup="true" CodeFile="Usuario.aspx.cs" Inherits="Adm_Usuario" %>
<%@ Register Src="~/Adm/BarraEdicao.ascx" TagPrefix="uc1" TagName="BarraEdicao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ContentTemplate>
        <h1>Usuário
        </h1>
        <p>
            <asp:Button ID="btnListagem" runat="server" Text="Listagem" 
                CssClass="btn-default btn" onclick="btnListagem_Click"  />
            <asp:Button ID="btnCadastro" runat="server" Text="Cadastro" 
                CssClass="btn-default btn" onclick="btnCadastro_Click" />
        </p>
        <asp:MultiView ID="multiViewUsuario" runat="server">
            <asp:View ID="tabListagem" runat="server">
                <div class="row">
                    <div class="col-lg-12">
                        <asp:Panel ID="pnlBusca" runat="server" DefaultButton="btnBuscar">
                            <div class="row">
                            <div class="col-lg-1"><h4>Buscar:</h4></div>
                            <div class="col-lg-9"> 
                                <asp:TextBox ID="edtBusca" CssClass="form-control" runat="server"/>
                            </div>
                            <div class="col-lg-2">
                                <asp:LinkButton ID="btnBuscar" runat="server" 
                                    CssClass="btn btn-info btn-block"  Text="Buscar" onclick="btnBuscar_Click">
                                    <i class="glyphicon glyphicon-search"></i>&nbsp;Buscar
                                </asp:LinkButton>
                             </div>
                           </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="row">
                      <h2>Listagem</h2>
                    <div class="col-lg-12">
                        <asp:GridView ID="grdUsuario" CssClass="table-bordered table table-striped"
                        OnSelectedIndexChanged="grdUsuario_SelectedIndexChanged"
                         runat="server" AutoGenerateColumns="False" DataKeyNames="usu_id" AllowSorting="true" DataSourceID="DsUsuario">
                            <Columns>
                                <asp:BoundField DataField="usu_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="usu_id" />
                                <asp:BoundField DataField="usu_nome" HeaderText="Nome" SortExpression="usu_nome" />
                                <asp:BoundField DataField="usu_login" HeaderText="Login" SortExpression="usu_login" />
                                <asp:CheckBoxField DataField="usu_ativo" HeaderText="Ativo" SortExpression="usu_ativo" />
                                <asp:CommandField HeaderText="Selecionar" SelectText="Selecionar" ButtonType="Link" ShowSelectButton="true" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="DsUsuario" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DsGeralTableAdapters.TbUsuarioTableAdapter"></asp:ObjectDataSource>
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
                        <asp:TextBox ID="edtUsuId" runat="server" Visible="false" />
                        <div class="col-lg-4">
                            <asp:Label ID="Label1" Text="Nome:" runat="server" />
                            <asp:TextBox ID="edtUsuNome" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="col-lg-3">
                            <asp:Label ID="Label2" Text="Login:" runat="server" />
                            <asp:TextBox ID="edtUsuLogin" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <asp:Label ID="Label3" Text="Senha:" runat="server" />
                            <asp:TextBox ID="edtUsuSenha" runat="server" CssClass="form-control"></asp:TextBox>
                        </div><div class="clearfix"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                            <asp:Label ID="Label4" Text="Ativo:" runat="server" />
                            <asp:CheckBox ID="chkUsuAtivo" runat="server" CssClass="form-control" Text="Ativo"></asp:CheckBox>
                        </div>
                    </div>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
</asp:Content>

