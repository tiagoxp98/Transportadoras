using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transportadoras
{
    public partial class TransportadoraDetalhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    var id = int.Parse(Request.QueryString["Id"]);

                    var repository = new Repository();
                    var usuario = repository.TransportadoraSelecionar(id);

                    lblCodigo.Text = usuario.Id.ToString();
                    txtNome.Text = usuario.Nome;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var repository = new Repository();

            Transportadora transportadora;

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                var id = int.Parse(Request.QueryString["Id"]);
                transportadora = repository.TransportadoraSelecionar(id);
            }
            else
                transportadora = new Transportadora();

            transportadora.Nome = txtNome.Text;

            repository.TransportadoraSalvar(transportadora);

            Response.Redirect("Transportadoras.aspx");
        }
    }
}