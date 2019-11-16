using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.administrador
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {

        private Usuarios usuarios;
        private Publicos publicos;
        private SqlDataReader registro;
        private SqlDataReader regPublico;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.usuarios = new Usuarios();
            this.publicos = new Publicos();
            this.registro = this.usuarios.getUsuarios();
            this.regPublico = this.publicos.getPublicos();
        }

        public void CerrarCone()
        {
            publicos.CerrarConexion();
        }

        public void CerrarUsu()
        {
            usuarios.CerrarConexion();
        }

        public SqlDataReader getPublicos()
        {
            return this.regPublico; 
        }

        public SqlDataReader getRegistro()
        {
            return this.registro;
        }

        protected void editar_Click(object sender,EventArgs e)
        {
            Response.Redirect("/paginas/administrador/ControlUsuario.aspx");
        }

        protected void eliminar_Click(object sender, EventArgs e)
        {

        }
    }
}