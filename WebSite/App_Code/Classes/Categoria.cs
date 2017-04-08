using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Categoria
/// </summary>
public class Categoria
{
    #region Attr
    private int cat_id;
    private string cat_nome;

    public int Cat_id {
        get { return cat_id; }
    }
    public string Cat_nome {
        get { return cat_nome;  }
        set { cat_nome = value; }
    }

    #endregion
    #region Construtores
    public Categoria()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #endregion
}