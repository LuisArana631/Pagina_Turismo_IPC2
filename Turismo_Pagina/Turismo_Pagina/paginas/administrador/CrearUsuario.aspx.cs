using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.administrador
{
    public partial class CrearUsuario : System.Web.UI.Page
    {

        private Conexion con;
        private Usuarios usuarios;
        private Publicos publicos;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Conexion();
            con.Cerrar();
            con.Conectar();
            this.usuarios = new Usuarios();
            this.publicos = new Publicos();
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dpi.Text == "" || nombre.Text == "")
                {
                    mensaje.Text = "No has ingresado todos los datos";
                }
                else
                {

                    if (this.usuarios.VerificarUsuario(usuario.Text) == true)
                    {
                        mensaje.Text = "Usuario ya existe, ingresa otro usuario.";
                        usuario.Text = "";
                    }
                    else if (this.publicos.VerificarUsuario(usuario.Text) == true)
                    {
                        mensaje.Text = "Usuario ya existe, ingresa otro usuario.";
                        usuario.Text = "";
                    }
                    else
                    {
                        if (clave.Text == clave2.Text)
                        {
                            String tipoSeleccionado = listTipo.Text;
                            if (tipoSeleccionado == "Agente")
                            {
                                this.usuarios.Insertar(dpi.Text, nombre.Text, correo.Text, telefono1.Text, usuario.Text, clave.Text, 1);
                                mensaje.Text = "Registro exitoso";
                            }
                            else if (tipoSeleccionado == "Técnico")
                            {
                                this.usuarios.Insertar(dpi.Text, nombre.Text, correo.Text, telefono1.Text, usuario.Text, clave.Text, 2);
                                mensaje.Text = "Registro exitoso";
                            }
                            else
                            {
                                this.usuarios.Insertar(dpi.Text, nombre.Text, correo.Text, telefono1.Text, usuario.Text, clave.Text, 3);
                                mensaje.Text = "Registro exitoso";
                            }

                        }
                        else
                        {
                            mensaje.Text = "Contraseñas no concuerdan.";
                        }

                    }
                }
            }
            catch
            {
                mensaje.Text = "Error al registrar, ponerse en contacto con desarrollador.";
            }                           
            
        }
    }
}