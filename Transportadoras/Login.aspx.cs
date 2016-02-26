using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transportadoras
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var repository = new Repository();
            var usuario = repository.Login(txtUsuario.Text, txtSenha.Text);
            if (usuario == null)
                lblErro.Text = "Usuário ou senha incorreta!";
            else
            {
                Session.Add("Usuario", usuario);
                Response.Redirect("Default.aspx");
            }
        }
    }
}