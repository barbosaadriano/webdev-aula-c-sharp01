using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adm_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Funcoes.verUsuarioLogado(Session["Usuario"] as Usuario))
            Response.Redirect("~/Adm");
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Adm");
    }
}
