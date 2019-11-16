using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.publico
{
    public partial class Like : System.Web.UI.Page
    {

        private MeGusta meGusta;
        private GustaSitio gustaSitio;
        private Publicos publicos;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            String Tipo = Request.QueryString["TIPO"];
            String Usuario = Request.QueryString["USER"];
            String ID = Request.QueryString["ID"];
            int IDObtenido = Convert.ToInt32(ID);

            this.meGusta = new MeGusta();
            this.gustaSitio = new GustaSitio();
            this.publicos = new Publicos();
            this.registro = this.publicos.getPublicoID(Usuario);


            if(Tipo=="Sitio")
            {
                try
                {
                    if(getUsuario().Read())
                    {
                        int IDUsuario = Convert.ToInt32(getUsuario()["ID"].ToString());
                        this.gustaSitio.Insertar(IDObtenido, IDUsuario);                        
                    }
                    Response.Redirect("ListaLugares.aspx?id=" + Usuario);
                }
                catch
                {
                    Response.Redirect("ListaLugares.aspx?id=" + Usuario);
                }

            }
            else if(Tipo=="Empresa")
            {
                try
                {
                    if (getUsuario().Read())
                    {
                        int IDUsuario = Convert.ToInt32(getUsuario()["ID"].ToString());
                        this.meGusta.Insertar(IDObtenido, IDUsuario);                        
                    }
                    Response.Redirect("ListaLugares.aspx?id=" + Usuario);
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