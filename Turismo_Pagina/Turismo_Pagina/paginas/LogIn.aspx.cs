using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turismo_Pagina.paginas.administrador;

namespace Turismo_Pagina.paginas
{
    public partial class LogIn : System.Web.UI.Page
    {
        
        private Publicos publicos;
        private Usuarios usuarios;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.publicos = new Publicos();
            this.usuarios = new Usuarios();            
        }     

        protected void boton_Click(object sender, EventArgs e)
        {

            String user = usuario.Text;
            String contraseña = clave.Text;

            if (this.usuarios.VerificarCredenciales(user,contraseña))
            {
                this.registro = this.usuarios.getUsuarios();
                while (getDatos().Read())
                {
                    Object usuariob = getDatos()["Usuario"];
                    string usuariocomparar = usuariob.ToString();
                    if (usuariocomparar == user)
                    {
                        Object TipoB = getDatos()["Tipo"];
                        string TipoComparar = TipoB.ToString();
                        if(TipoComparar == "Agente")
                        {
                            Response.Redirect("agente/InicioAgente.aspx");
                        }
                        else if(TipoComparar=="Técnico")
                        {
                            Response.Redirect("tecnico/InicioTecnico.aspx");
                        }
                        else if(TipoComparar=="Administrador")
                        {
                            Response.Redirect("administrador/InicioAdministrador.aspx");
                        }
                    }
                }
            }
            else if (this.publicos.VerificarCredenciales(user,contraseña))
            {                
                Response.Redirect("publico/InicioPublico.aspx?id="+user);
            }
            else if (user == "" || clave.Text == "")
            {
                mensaje.Text = "No has ingresado todos los datos";
            }
            else
            {
                usuario.Text = "";
                mensaje.Text = "Datos incorrectos";
            }
        }

        public SqlDataReader getDatos()
        {
            return this.registro;
        }


    }
}