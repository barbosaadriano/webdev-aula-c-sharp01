using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    public static bool verUsuarioLogado(Usuario usuario)
    {
        return ((usuario != null) && (usuario.Usu_ativo)) ;
    }
    public static bool enviarEmail(string email, string assunto, string mensagem) {
        if (string.IsNullOrEmpty(email))
            return false;
        try
        {
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
            cliente.EnableSsl = true;
            MailAddress remetente = new MailAddress("exemplo@aexemplo.com.br","Adriano Barbosa");
            MailAddress destinatario = new MailAddress(email);
            MailMessage msg = new MailMessage(remetente, destinatario);
            msg.Subject = assunto;
            msg.Body = mensagem;
            msg.IsBodyHtml = true;
            NetworkCredential credential = new NetworkCredential("exemplo@exemplo.com.br", "123456");
            cliente.Credentials = credential;
            cliente.Send(msg);
            return true;

        }
        catch
        {
            return false;
        }
    }

}