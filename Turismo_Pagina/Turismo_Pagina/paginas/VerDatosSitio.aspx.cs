using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turismo_Pagina.paginas.agente;

namespace Turismo_Pagina.paginas
{
    public partial class VerDatosSitio : System.Web.UI.Page
    {

        private Sitios sitios;
        private Foto_Sitio foto_Sitio;
        private SqlDataReader registro;
        private SqlDataReader foto;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.sitios = new Sitios();
            this.foto_Sitio = new Foto_Sitio();
            String IDSitio = Request.QueryString["ID"];
            this.registro = this.sitios.getSitioID(IDSitio);
            this.foto = this.foto_Sitio.getFotoSitioID(IDSitio);
        }

        public SqlDataReader getFoto()
        {
            return this.foto;
        }

        public  SqlDataReader getSitio()
        {
            return this.registro;
        }
    }
}