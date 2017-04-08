using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adm_Categoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            btListagem_Click(null, null);
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
        if (grdCategoria.SelectedDataKey != null)
            //return (int) grdCategoria.SelectedDataKey[0];
            return int.Parse(grdCategoria.SelectedDataKey[0].ToString());
        else
            return 0;
    }
    protected void btListagem_Click(object sender, EventArgs e)
    {
        MultiViewCategoria.ActiveViewIndex = 0;
    }
    protected void btCadastro_Click(object sender, EventArgs e)
    {
        MultiViewCategoria.ActiveViewIndex = 1;
    }
    private void atualizarCampos(int cat_id)
    {
        if (cat_id <= 0)
        {
            edtCatId.Text = "";
            edtCatNome.Text = "";
        }
        else
        {
            Categoria cat = new Categoria(cat_id);
            edtCatId.Text = cat.Cat_id.ToString();
            edtCatNome.Text = cat.Cat_nome;
        }
    }
    private void habilitarCampos(bool habilitar)
    {
        edtCatNome.Enabled = habilitar;
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
        habilitarCampos(!string.IsNullOrEmpty(edtCatId.Text));
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        atualizarCampos(retornaIdSelecionado());
        habilitarCampos(false);
    }
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        String retorno;
        Categoria cat = new Categoria();
        if (string.IsNullOrEmpty(edtCatId.Text))
            retorno = cat.inserir(edtCatNome.Text);
        else
            retorno = cat.editar(int.Parse(edtCatId.Text), edtCatNome.Text);
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
        dsCategoria.DataBind();
        grdCategoria.DataBind();

    }
    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(edtCatId.Text))
            return;
        Categoria cat = new Categoria();
        string retorno = cat.excluir(int.Parse(edtCatId.Text));
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

    protected void grdCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        atualizarCampos(retornaIdSelecionado());
        btCadastro_Click(null, null);
    }
}