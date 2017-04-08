using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
    #region Attr
    private DsGeralTableAdapters.TbUsuarioTableAdapter dsUsuario = new DsGeralTableAdapters.TbUsuarioTableAdapter();
    private int usu_id;
    private string usu_nome;
    private string usu_login;
    private string usu_senha;
    private bool usu_ativo;

    public int Usu_id
    {
        get { return usu_id; }
    }
    public string Usu_nome
    {
        get { return usu_nome; }
        set { usu_nome = value; }
    }
    public string Usu_login
    {
        get { return usu_login; }
        set { usu_login = value; }
    }
    public string Usu_senha
    {
        get { return usu_senha; }
        set { usu_senha = value; }
    }
    public bool Usu_ativo
    {
        get { return usu_ativo; }
        set { usu_ativo = value; }
    }
    #endregion
    #region Construtores
    public Usuario()
    {

    }
    public Usuario(int usu_id)
    {
        DsGeral.TbUsuarioDataTable tbUsuario = new DsGeral.TbUsuarioDataTable();
        this.dsUsuario.FillByUsuId(tbUsuario, usu_id);
        if (tbUsuario.Rows.Count > 0)
        {
            DsGeral.TbUsuarioRow regUsuario = (DsGeral.TbUsuarioRow)tbUsuario.Rows[0];
            this.usu_id = regUsuario.usu_id;
            this.usu_nome = regUsuario.usu_nome;
            this.usu_login = regUsuario.usu_login;
            this.usu_senha = regUsuario.usu_senha;
            this.usu_ativo = regUsuario.usu_ativo;
        }
    }
    #endregion
    #region Manipulação dados
    public string inserir(string usu_nome,string usu_login, string usu_senha, bool usu_ativo)
    {
        string retorno = validar(usu_nome,usu_login, usu_senha);
        if (!String.IsNullOrEmpty(retorno))
            return retorno;
        try
        {
            this.dsUsuario.Insert(usu_nome,usu_login,usu_senha,usu_ativo);
        }
        catch (Exception e)
        {
            return "Erro ao inserir o usuario: " + e.Message;
        }
        return "";
    }
    public string editar(int usu_id, string usu_nome, string usu_login, string usu_senha, bool usu_ativo)
    {
        string retorno = validar(usu_nome, usu_login, usu_senha);
        if (!String.IsNullOrEmpty(retorno))
            return retorno;
        try
        {
            this.dsUsuario.Update(usu_nome,usu_login, usu_senha, usu_ativo, usu_id);
        }
        catch (Exception e)
        {
            return "Erro ao atualizar o usuario: " + e.Message;
        }
        return "";
    }
    public string excluir(int usu_id)
    {
        try
        {
            this.dsUsuario.Delete(usu_id);
        }
        catch (Exception e)
        {
            return "Erro ao atualizar o usuario: " + e.Message;
        }
        return "";
    }
    private string validar(string usu_nome, string usu_login, string usu_senha)
    {
        if (String.IsNullOrEmpty(usu_nome))
            return "O Nome do usuário é obrigatório!";   
        if (String.IsNullOrEmpty(usu_login))
            return "O login do usuário é obrigatório!";
        if (String.IsNullOrEmpty(usu_senha))
            return "A senha do usuário é obrigatório!";
        return "";
    }
    #endregion
}