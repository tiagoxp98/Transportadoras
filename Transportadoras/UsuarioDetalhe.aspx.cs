using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transportadoras
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    var id = int.Parse(Request.QueryString["Id"]);

                    var repository = new Repository();
                    var usuario = repository.UsuarioSelecionar(id);

                    lblCodigo.Text = usuario.Id.ToString();
                    txtUsuario.Text = usuario.Nome;
                    txtSenha.Text = usuario.Senha;
                    ckbAdmin.Checked = usuario.Admin;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var repository = new Repository();

            Usuario usuario;

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                var id = int.Parse(Request.QueryString["Id"]);
                usuario = repository.UsuarioSelecionar(id);
            }
            else
                usuario = new Usuario();

            usuario.Nome = txtUsuario.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Admin = ckbAdmin.Checked;

            repository.UsuarioSalvar(usuario);

            Response.Redirect("Usuarios.aspx");
        }
    }
}