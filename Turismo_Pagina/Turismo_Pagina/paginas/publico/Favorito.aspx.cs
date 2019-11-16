using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.publico
{
    public partial class Favorito : System.Web.UI.Page
    {

        private FavoritoSitio favoritoSitio;
        private FavoritoEmpresa favoritoEmpresa;
        private Publicos publicos;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            String Tipo = Request.QueryString["TIPO"];
            String Usuario = Request.QueryString["USER"];
            String ID = Request.QueryString["ID"];
            int IDObtenido = Convert.ToInt32(ID);

            this.favoritoEmpresa = new FavoritoEmpresa();
            this.favoritoSitio = new FavoritoSitio();
            this.publicos = new Publicos();
            this.registro = this.publicos.getPublicoID(Usuario);

            if (Tipo == "Sitio")
            {
                try
                {
                    if (getUsuario().Read())
                    {
                        int IDUsuario = Convert.ToInt32(getUsuario()["ID"].ToString());
                        this.favoritoSitio.Insertar(IDObtenido, IDUsuario);
                        Response.Redirect("ListaLugares.aspx?id=" + Usuario);
                    }
                }
                catch
                {
                    Response.Redirect("ListaLugares.aspx?id=" + Usuario);
                }

            }
            else if (Tipo == "Empresa")
            {
                try
                {
                    if (getUsuario().Read())
                    {
                        int IDUsuario = Convert.ToInt32(getUsuario()["ID"].ToString());
                        this.favoritoEmpresa.Insertar(IDObtenido, IDUsuario);
                        Response.Redirect("ListaLugares.aspx?id=" + Usuario);
                    }
                }
                catch
                {
                    Response.Redirect("ListaLugares.aspx?id=" + Usuario);
                }
            }
            else
            {
                Response.Redirect("ListaLugares.aspx?id=" + Usuario);
            }           

        }

        public SqlDataReader getUsuario()
        {
            return this.registro;
        }
    }
}