using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas
{
    public partial class VerDatosTurismo : System.Web.UI.Page
    {
                
        private Empresas empresas;
        private Foto_Empresa foto_Empresa;
        private Servicio_Empresa servicio_Empresa;
        private Platillo_Empresa platillo_Empresa;        
        private SqlDataReader regempresa;
        private SqlDataReader foto;
        private SqlDataReader servicios;
        private SqlDataReader platillos;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.empresas = new Empresas();
            this.foto_Empresa = new Foto_Empresa();
            this.servicio_Empresa = new Servicio_Empresa();
            this.platillo_Empresa = new Platillo_Empresa();
            String IDEmpresa = Request.QueryString["ID"];
            this.regempresa = this.empresas.getEmpresaID(IDEmpresa);
            this.foto = this.foto_Empresa.getFotoEmpresaID(IDEmpresa);
            this.servicios = this.servicio_Empresa.getServicioID(IDEmpresa);
            this.platillos = this.platillo_Empresa.getPlatilloID(IDEmpresa);
        }

        public SqlDataReader getPlatillos()
        {
            return this.platillos;
        }

        public SqlDataReader getServicios()
        {
            return this.servicios;
        }

        public SqlDataReader getEmpresa()
        {
            return this.regempresa;
        }

        public SqlDataReader getFoto()
        {
            return this.foto;
        }
    }
}