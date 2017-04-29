using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ControleLogin
{
	public ControleLogin()
	{

    }

    private bool buscarUsuario(String usuario, String senha)
    {
        if ((string.IsNullOrEmpty(usuario))||(string.IsNullOrEmpty(senha)))
            return false;
        DsGeral.TbUsuarioDataTable tbUsuario = new DsGeral.TbUsuarioDataTable();
        DsGeralTableAdapters.TbUsuarioTableAdapter dsUsuario = new DsGeralTableAdapters.TbUsuarioTableAdapter();
        dsUsuario.FillByLoginSenha(tbUsuario, usuario, senha);
        return (tbUsuario.Rows.Count > 0);
    }


}