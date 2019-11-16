using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turismo_Pagina.paginas.administrador;

namespace Turismo_Pagina.paginas
{
    public partial class VerNoticia : System.Web.UI.Page
    {

        private Noticia noticia;
        private SqlDataReader registro;        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.noticia = new Noticia();
            String IDNoti = Request.QueryString["ID"];
            this.registro = this.noticia.getNoticiaID(IDNoti);

        }

        public SqlDataReader getNoticia()
        {
            return this.registro;
        }

    }    
}