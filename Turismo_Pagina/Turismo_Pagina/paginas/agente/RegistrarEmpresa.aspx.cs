using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turismo_Pagina.paginas.administrador;

namespace Turismo_Pagina.paginas.agente
{
    public partial class RegistrarEmpresa : System.Web.UI.Page
    {

        private Empresas empresas;
        private Usuarios usuarios;
        private SqlDataReader RegistroEmpresas;
        private SqlDataReader RegistroUsuarios;
          

        protected void Page_Load(object sender, EventArgs e)
        {
            this.usuarios = new Usuarios();
            this.empresas = new Empresas();

            this.RegistroEmpresas = this.empresas.getEmpresas();
            this.RegistroUsuarios = this.usuarios.getUsuarios();


            while (getEmpresas().Read())
            {
                TableRow Linea = new TableRow();

                TableCell Nombre = new TableCell();
                TableCell Correo = new TableCell();
                TableCell Telefono = new TableCell();
                TableCell Region = new TableCell();
                TableCell NombreAgente = new TableCell();
                TableCell Estado = new TableCell();
                TableCell Acciones = new TableCell();

                Nombre.Text = getEmpresas()["Nombre"].ToString();
                Correo.Text = getEmpresas()["Correo"].ToString();
                Telefono.Text = getEmpresas()["Telefono"].ToString();
                Region.Text = getEmpresas()["Region"].ToString();               

              DropDownList listaUsuarios = new DropDownList();                 


                NombreAgente.Controls.Add(listaUsuarios);

                while (getUsuarios().Read())
                {
                    if (getUsuarios()["Tipo"].ToString() == "Técnico")
                    {
                        listaUsuarios.Items.Add(getUsuarios()["Nombre"].ToString());
                    }
                }

                Estado.Text = getEmpresas()["Estado"].ToString();

                Linea.Cells.Add(Nombre);
                Linea.Cells.Add(Correo);
                Linea.Cells.Add(Telefono);
                Linea.Cells.Add(Region);
                Linea.Cells.Add(NombreAgente);
                Linea.Cells.Add(Estado);

                if (getEmpresas()["Estado"].ToString() != "Prevaluación")
                {
                    Acciones.Text = "Sin Acciones";
                }
                else
                {
                    Button Registrar = new Button();
                    Registrar.Text = "Registrar";
                    Registrar.CssClass = "btn-success";

                    Acciones.Controls.Add(Registrar);
                }

                Linea.Cells.Add(Acciones);

                TablaEmpresas.Rows.Add(Linea);


            }

        }
        
        public void CerrarEmpresas()
        {
            this.empresas.CerrarConexion();
        }

        public void CerrarUsuarios()
        {
            this.usuarios.CerrarConexion();
        }

        public SqlDataReader getEmpresas()
        {
            return this.RegistroEmpresas;
        }

        public SqlDataReader getUsuarios()
        {
            CerrarUsuarios();
            return this.RegistroUsuarios;
        }

        protected void registrar_Click(object sender, EventArgs e)
        {

        }
    }
}