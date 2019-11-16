using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.agente
{
    public partial class ResultadoRecorrido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/paginas/agente/VerRecorrido.aspx");
        }
    }
}