using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.publico
{
    public partial class Favoritos : System.Web.UI.Page
    {

        private FavoritoEmpresa favoritoEmpresa;
        private FavoritoSitio favoritoSitio;
        private Publicos publicos;
        private SqlDataReader registroEmpresa;
        private SqlDataReader registroSitio;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            String Usuario = Request.QueryString["ID"];

            this.favoritoSitio = new FavoritoSitio();
            this.favoritoEmpresa = new FavoritoEmpresa();
            this.publicos = new Publicos();
            this.registro = this.publicos.getPublicoID(Usuario);
            
            if(getUsuario().Read())
            {
                String ID_User = getUsuario()["ID"].ToString();
                this.registroEmpresa = this.favoritoEmpresa.getFavoritosUsuario(ID_User);
                this.registroSitio = this.favoritoSitio.getFavoritosUsuario(ID_User);
            }

            
        }

        public SqlDataReader getTopSitio()
        {
            return this.registroSitio;
        }

        public SqlDataReader getUsuario()
        {
            return this.registro;
        }

        public SqlDataReader getTopEmpresa()
        {
            return this.registroEmpresa;
        }
    }
}