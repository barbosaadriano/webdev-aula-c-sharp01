using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Funcoes
{
	public Funcoes()
	{

	}
    public static void showMessage(Page pagina, string mensagem)
    {
        ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), Guid.NewGuid().ToString() , "alert('" + mensagem + "');", true);
    }

}