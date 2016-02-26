using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transportadoras
{
    public partial class Transportadoras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var usuario = (Usuario)Session["Usuario"];
                lnkNovo.Visible = usuario.Admin;
                Listar();
            }
        }

        private void Listar()
        {
            var usuario = (Usuario)Session["Usuario"];

            var repository = new Repository();
            gv.DataSource = repository.TransportadoraListagem(usuario.Id);
            gv.DataBind();

            foreach (var row in gv.Rows.Cast<GridViewRow>())
            {
                ((DropDownList)row.FindControl("lstNota")).SelectedValue = ((HiddenField)row.FindControl("hdfNota")).Value;
                ((LinkButton)row.FindControl("lnkExcluir")).Visible = usuario.Admin;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var b = (LinkButton)sender;

            var repository = new Repository();
            repository.TransportadoraExcluir(int.Parse(b.CommandArgument));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = (DropDownList)sender;

            var ddl = (DropDownList)sender;
            var row = (GridViewRow)ddl.Parent.Parent;
            var id = int.Parse(((HiddenField)row.FindControl("hdfId")).Value);

            var usuario = (Usuario)Session["Usuario"];

            var repository = new Repository();
            repository.SetarNota(id, usuario.Id, int.Parse(d.SelectedValue));
        }
    }
}