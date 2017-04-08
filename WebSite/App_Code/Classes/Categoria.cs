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
    private DsGeralTableAdapters.TbCategoriaTableAdapter dsCategoria = new DsGeralTableAdapters.TbCategoriaTableAdapter();
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
        
    }
    public Categoria(int cat_id) {
        DsGeral.TbCategoriaDataTable tbCategoria = new DsGeral.TbCategoriaDataTable();
        this.dsCategoria.FillByCatId(tbCategoria,cat_id);
        if (tbCategoria.Rows.Count > 0)
        {
            DsGeral.TbCategoriaRow regCategoria = (DsGeral.TbCategoriaRow)tbCategoria.Rows[0];
            this.cat_id = regCategoria.cat_id;
            this.cat_nome = regCategoria.cat_nome;
        }
    }
    #endregion

    #region Manipulação dados
    public string inserir(string cat_nome)
    {
        string retorno = validar(cat_nome);
        if (!String.IsNullOrEmpty(retorno))
            return retorno;
        try
        {
            this.dsCategoria.Insert(cat_nome);
        }
        catch (Exception e)
        {
            return "Erro ao inserir a categoria: " + e.Message;
        }
        return "";
    }
    public string editar(int cat_id, string cat_nome)
    {
        string retorno = validar(cat_nome);
        if (!String.IsNullOrEmpty(retorno))
            return retorno;
        try
        {
            this.dsCategoria.Update(cat_nome,cat_id);
        }
        catch (Exception e)
        {
            return "Erro ao atualizar a categoria: " + e.Message;
        }
        return "";
    }
    public string excluir(int cat_id)
    {
        try
        {
            this.dsCategoria.Delete(cat_id);
        }
        catch (Exception e)
        {
            return "Erro ao atualizar a categoria: " + e.Message;
        }
        return "";
    }
    private string validar(string cat_nome) {
        if (String.IsNullOrEmpty(cat_nome)) 
            return "O nome da categoria deve ser informado!";
        return "";
    }
    #endregion
}