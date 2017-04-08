<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraEdicao.ascx.cs" Inherits="Adm_BarraEdicao" %>
<asp:Button ID="btNovo" CssClass="btn btn-success btn-lg" runat="server" Text="Novo" />
<asp:Button ID="btGravar" CssClass="btn btn-primary" runat="server" Text="Gravar" />
<asp:Button ID="btAlterar" CssClass="btn btn-info" runat="server" Text="Alterar" />
<asp:Button ID="btCancelar" CssClass="btn btn-warning" runat="server" Text="Cancelar" />
<asp:Button ID="btExcluir" CssClass="btn btn-danger" runat="server" Text="Excluir" OnClientClick="return confirm('Deseja realmente excluir este registro?');"/>
<asp:Panel runat="server" ID="viewModal">

</asp:Panel>