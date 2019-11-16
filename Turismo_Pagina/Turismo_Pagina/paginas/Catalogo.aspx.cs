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
    public partial class Catalogo : System.Web.UI.Page
    {

        private Sitios sitios;
        private Empresas empresas;
        private Foto_Sitio fotoSitio;
        private Foto_Empresa fotoEmpresa;
        private SqlDataReader regsitio;
        private SqlDataReader regempresa;
        private SqlDataReader regfotoSitio;
        private SqlDataReader regfotoEmpresa;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.fotoSitio = new Foto_Sitio();
            this.fotoEmpresa = new Foto_Empresa();
            this.sitios = new Sitios();
            this.empresas = new Empresas();                     

            if(!IsPostBack)
            {
                region.Items.Add("Todas las regiones");
                region.Items.Add("Norte");
                region.Items.Add("Sur");
                region.Items.Add("Este");
                region.Items.Add("Oeste");
            }

            if (region.SelectedIndex == 0)
            {
                //this.sitios.Cerrar();
                //this.empresas.Cerrar();
                this.fotoEmpresa.Cerrar();
                this.fotoSitio.Cerrar();
                this.empresas.Cerrar();
                this.sitios.Cerrar();

                this.regfotoSitio = this.fotoSitio.getFotoSitio();
                this.regfotoEmpresa = this.fotoEmpresa.getFotoEmpresa();
                this.regempresa = this.empresas.getEmpresas();
                this.regsitio = this.sitios.getSitios();
                
            }
            else if (region.SelectedIndex == 1)
            {
                this.fotoEmpresa.Cerrar();
                this.fotoSitio.Cerrar();
                this.empresas.Cerrar();
                this.sitios.Cerrar();

                this.regfotoSitio = this.fotoSitio.getFotoSitio();
                this.regfotoEmpresa = this.fotoEmpresa.getFotoEmpresa();
                this.regempresa = this.empresas.getEmpresaRegion("1");
                this.regsitio = this.sitios.getSitioRegion("1");
               
            }
            else if (region.SelectedIndex == 2)
            {
                this.fotoEmpresa.Cerrar();
                this.fotoSitio.Cerrar();
                this.empresas.Cerrar();
                this.sitios.Cerrar();

                this.regfotoSitio = this.fotoSitio.getFotoSitio();
                this.regfotoEmpresa = this.fotoEmpresa.getFotoEmpresa();
                this.regempresa = this.empresas.getEmpresaRegion("2");
                this.regsitio = this.sitios.getSitioRegion("2");
               
            }
            else if (region.SelectedIndex == 3)
            {
                this.fotoEmpresa.Cerrar();
                this.fotoSitio.Cerrar();
                this.empresas.Cerrar();
                this.sitios.Cerrar();

                this.regfotoSitio = this.fotoSitio.getFotoSitio();
                this.regfotoEmpresa = this.fotoEmpresa.getFotoEmpresa();
                this.regempresa = this.empresas.getEmpresaRegion("3");
                this.regsitio = this.sitios.getSitioRegion("3");
                
            }
            else
            {
                this.fotoEmpresa.Cerrar();
                this.fotoSitio.Cerrar();
                this.empresas.Cerrar();
                this.sitios.Cerrar();

                this.regfotoSitio = this.fotoSitio.getFotoSitio();
                this.regfotoEmpresa = this.fotoEmpresa.getFotoEmpresa();
                this.regempresa = this.empresas.getEmpresaRegion("4");
                this.regsitio = this.sitios.getSitioRegion("4");
                
            }

        }

        public SqlDataReader getFotoEmpresa()
        {
            return this.regfotoEmpresa;
        }

        public SqlDataReader getFotoSitio()
        {
            return this.regfotoSitio;
        }

        public SqlDataReader getSitio()
        {
            return this.regsitio;
        }

        public SqlDataReader getEmpresa()
        {
            return this.regempresa;
        }

        protected void region_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.fotoEmpresa.Cerrar();
            this.fotoSitio.Cerrar();
            this.empresas.Cerrar();
            this.sitios.Cerrar();

            this.regfotoSitio = this.fotoSitio.getFotoSitio();
            this.regfotoEmpresa = this.fotoEmpresa.getFotoEmpresa();
            this.regempresa = this.empresas.getEmpresaNombre(txtNombre.Text);
            this.regsitio = this.sitios.getSitioNombre(txtNombre.Text);
            
        }
    }
}