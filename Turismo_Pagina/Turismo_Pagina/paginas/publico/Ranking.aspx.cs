using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.publico
{
    public partial class Ranking : System.Web.UI.Page
    {

       private MeGusta meGusta;
        private GustaSitio gustaSitio;
        private SqlDataReader regsitio;
        private SqlDataReader regempresa;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gustaSitio = new GustaSitio();
            this.meGusta = new MeGusta();
            this.regsitio = this.gustaSitio.getTop();
            this.regempresa = this.meGusta.getTop();
        }

        public SqlDataReader getTopSitio()
        {
            return this.regsitio;
        }

        public SqlDataReader getTopEmpresa()
        {
            return this.regempresa;
        }

    }
}