using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transportadoras
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        private void Listar()
        {
            var repository = new Repository();
            gv.DataSource = repository.UsuariosListagem();
            gv.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var b = (LinkButton) sender;

            var repository = new Repository();
            repository.UsuarioExcluir(int.Parse(b.CommandArgument));
        }
    }
}