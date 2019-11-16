using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turismo_Pagina.paginas.administrador;

namespace Turismo_Pagina.paginas
{
    public partial class Registro_Publico : System.Web.UI.Page
    {

        private Conexion con;
        private Publicos publicos;
        private Usuarios usuarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Conexion();
            con.Conectar();
            this.publicos = new Publicos();
            this.usuarios = new Usuarios();
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            if(clave.Text != "" && clave2.Text != "" && usuario.Text != "")
            {
                if (clave.Text == clave2.Text)
                {
                    if (this.publicos.VerificarUsuario(usuario.Text) == true)
                    {
                        mensaje.Text = "Usuario ya registrado.";
                        usuario.Text = "";
                    }
                    else if (this.usuarios.VerificarUsuario(usuario.Text) == true)
                    {
                        mensaje.Text = "Usuario ya registrado.";
                        usuario.Text = "";
                    }
                    else
                    {
                        this.publicos.Insertar(usuario.Text, clave.Text);
                        Response.Redirect("LogIn.aspx");
                    }
                }
                else
                {
                    mensaje.Text = "Contraseñas no concuerdan";
                }
            }
            else
            {
                mensaje.Text = "Ingresa todos los datos";
            }            
        }
    }
}