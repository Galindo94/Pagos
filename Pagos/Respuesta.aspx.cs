using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagos
{
    public partial class Respuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IdTransaccion"] == null || Request.QueryString["Ruta"] == null)
                Response.Redirect("index.aspx");
            else
            {
                lblIdTransaccion.Text = Request.QueryString["IdTransaccion"];
                lblRuta.Text = Request.QueryString["Ruta"];
            }
        }

        protected void btnContinuarBanco_Click(object sender, EventArgs e)
        {
            Response.Redirect(lblRuta.Text);
        }
    }
}