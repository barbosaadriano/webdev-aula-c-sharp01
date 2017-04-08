using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adm_BarraEdicao : System.Web.UI.UserControl
{
    public Button BtNovo {
        get { return btNovo; }
        set { btNovo = value; }

    }
    public Button BtAlterar
    {
        get { return btAlterar; }
        set { btAlterar = value; }
    }

    public Button BtGravar
    {
        get { return btGravar; }
        set { btGravar = value; }
    }

    
    public Button BtCancelar
    {
        get { return btCancelar; }
        set { btCancelar = value; }
    }

    public Button BtExcluir { get{ return btExcluir;
    }
        private set { btExcluir = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
}