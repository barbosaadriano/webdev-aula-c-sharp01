using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adm_Noticia : System.Web.UI.Page
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
    protected void btListagem_Click(object sender, EventArgs e)
    {
        MultiViewNoticia.ActiveViewIndex = 0;
    }
    protected void btCadastro_Click(object sender, EventArgs e)
    {
        MultiViewNoticia.ActiveViewIndex = 1;
    }
    protected void grdNoticia_SelectedIndexChanged(object sender, EventArgs e)
    {
        atualizarCampos(retornaIdSelecionado());
        btCadastro_Click(null, null);
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
        if (grdNoticia.SelectedDataKey != null)
            return int.Parse(grdNoticia.SelectedDataKey[0].ToString());
        else
            return 0;
    }
    private void atualizarCampos(int not_id)
    {
        if (not_id <= 0)
        {
            edtNotId.Text = "";
            edtNotTit.Text = "";
            edtNotTex.Text = "";
            edtNotData.Text = "";
            edtImagem.Text = "";
            edtCatId.Text = "";
        }
        else
        {
            Noticia not = new Noticia(not_id);
            edtNotId.Text =  not.Not_id.ToString();
            edtNotTit.Text = not.Not_titulo;
            edtNotTex.Text = not.Not_texto;
            edtNotData.Text = not.Not_data.ToShortDateString();
            edtImagem.Text = not.Not_imagem;
            edtCatId.Text = not.Categoria_.Cat_id.ToString();
        }
    }
    private void habilitarCampos(bool habilitar)
    {
        edtNotTit.Enabled = habilitar;
        edtNotTex.Enabled = habilitar;
        edtNotData.Enabled = habilitar;
        edtImagem.Enabled = habilitar;
        edtCatId.Enabled = habilitar;
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
        habilitarCampos(!string.IsNullOrEmpty(edtNotId.Text));
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        atualizarCampos(retornaIdSelecionado());
        habilitarCampos(false);
    }
    protected void btnGravar_Click(object sender, EventArgs e)
    {
        String retorno;
        Noticia not = new Noticia();
        if (string.IsNullOrEmpty(edtNotId.Text))
            retorno = not.inserir(edtNotTit.Text,edtNotTex.Text,new DateTime(2017,5,17),edtImagem.Text,int.Parse(edtCatId.Text));
        else
            retorno = not.editar(int.Parse(edtNotId.Text), edtNotTit.Text, edtNotTex.Text, new DateTime(2017,5,17), edtImagem.Text, int.Parse(edtCatId.Text));
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
        dsNoticia.DataBind();
        grdNoticia.DataBind();

    }
    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(edtNotId.Text))
            return;
        Noticia not = new Noticia();
        string retorno = not.excluir(int.Parse(edtNotId.Text));
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

}