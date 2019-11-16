using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.publico
{
    public partial class ListaLugares : System.Web.UI.Page
    {

        private Sitios sitios;
        private Empresas empresas;
        private SqlDataReader regsitio;
        private SqlDataReader regempresa;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.sitios = new Sitios();
            this.empresas = new Empresas();
            this.regempresa = this.empresas.getEmpresas();
            this.regsitio = this.sitios.getSitios();

        }

        public SqlDataReader getSitio()
        {
            return this.regsitio;
        }

        public SqlDataReader getEmpresa()
        {
            return this.regempresa;
        }

    }
}