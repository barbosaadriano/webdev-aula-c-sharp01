using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adm_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Funcoes.verUsuarioLogado(Session["Usuario"] as Usuario))
                Response.Redirect("~/Adm/Inicio.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ControleLogin cl = new ControleLogin();
        if (cl.logar(edLogin.Text, edSenha.Text))
        {
            Usuario usuario = new Usuario(edLogin.Text);
            Session["Usuario"] = usuario;
            Response.Redirect("~/Adm/Inicio.aspx");
        }
        else
        {
            Funcoes.showMessage(this, "Usuário ou Senha inválida");
        }
    }
}