using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adm_Usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            btnListagem_Click(null, null);
        BarraEdicao.BtNovo.Click += btnNovo_Click;
        BarraEdicao.BtAlterar.Click += btnAlterar_Click;
        BarraEdicao.BtGravar.Click += btnGravar_Click;
        BarraEdicao.BtCancelar.Click += btnCancelar_Click;
        BarraEdicao.BtExcluir.Click += btnExcluir_Click;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            habilitarCampos(false);
        }
    }
    private int retornaIdSelecionado()
    {
        if (grdUsuario.SelectedDataKey != null)
            //return (int) grdCategoria.SelectedDataKey[0];
            return int.Parse(grdUsuario.SelectedDataKey[0].ToString());
        else
            return 0;
    }    
    private void atualizarCampos(int usu_id)
    {
        if (usu_id <= 0)
        {
            edtUsuId.Text = "";
            edtUsuNome.Text = "";
            edtUsuLogin.Text = "";
            edtUsuSenha.Text = "";
            chkUsuAtivo.Checked = true;
        }
        else
        {
            Usuario usu = new Usuario(usu_id);
            edtUsuId.Text = usu.Usu_id.ToString();
            edtUsuNome.Text = usu.Usu_nome;
            edtUsuLogin.Text = usu.Usu_login;
            edtUsuSenha.Text = usu.Usu_senha;
            chkUsuAtivo.Checked = usu.Usu_ativo;
        }
    }
    private void habilitarCampos(bool habilitar)
    {
        edtUsuNome.Enabled = habilitar;
        edtUsuLogin.Enabled = habilitar;
        edtUsuSenha.Enabled = habilitar;
        chkUsuAtivo.Enabled = habilitar;
        BarraEdicao.BtGravar.Enabled = habilitar;
        BarraEdicao.BtCancelar.Enabled = habilitar;
        BarraEdicao.BtNovo.Enabled = !habilitar;
        BarraEdicao.BtAlterar.Enabled = !habilitar;
        BarraEdicao.BtExcluir.Enabled = !habilitar;
    }
    protected void btnNovo_Click(object sender, EventArgs e)
    {
        atualizarCampos(0);
        habilitarCampos(true);
    }
    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        habilitarCampos(!string.IsNullOrEmpty(edtUsuId.Text));
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        atualizarCampos(retornaIdSelecionado());
        habilitarCampos(false);
    }
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        String retorno;
        Usuario usu = new Usuario();
        if (string.IsNullOrEmpty(edtUsuId.Text))
            retorno = usu.salvar(0,edtUsuNome.Text,edtUsuLogin.Text,edtUsuSenha.Text,chkUsuAtivo.Checked);
        else
            retorno = usu.salvar(Int32.Parse(edtUsuId.Text),edtUsuNome.Text,edtUsuLogin.Text,edtUsuSenha.Text,chkUsuAtivo.Checked);
        if (!string.IsNullOrEmpty(retorno))
        {
            Funcoes.showMessage(this, retorno);
            return;
        }
        else
        {
            Funcoes.showMessage(this, "Registro Salvo com Sucesso");
        }
        habilitarCampos(false);
        atualizarDados();
    }
    private void atualizarDados()
    {
        DsUsuario.DataBind();
        grdUsuario.DataBind();

    }
    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(edtUsuId.Text))
            return;
        Usuario usu = new Usuario();
        string retorno = usu.excluir(int.Parse(edtUsuId.Text));
        if (!string.IsNullOrEmpty(retorno))
        {
            Funcoes.showMessage(this, retorno);
            return;
        }
        else
        {
            Funcoes.showMessage(this, "Registro excluido com sucesso!");
        }
        atualizarCampos(0);
        atualizarDados();
    }

    protected void grdUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        atualizarCampos(retornaIdSelecionado());
        btnCadastro_Click(null, null);
    }
    protected void btnListagem_Click(object sender, EventArgs e)
    {
        multiViewUsuario.ActiveViewIndex = 0;
    }
    protected void btnCadastro_Click(object sender, EventArgs e)
    {
        multiViewUsuario.ActiveViewIndex = 1;
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }
}