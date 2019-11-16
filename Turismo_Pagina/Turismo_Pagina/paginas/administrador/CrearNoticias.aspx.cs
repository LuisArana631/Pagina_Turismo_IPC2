using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.administrador
{
    public partial class CrearNoticias : System.Web.UI.Page
    {
                     

        protected void Page_Load(object sender, EventArgs e)
        {
                     
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            if( cargafoto.HasFile==false || txtTitulo.Text == "" || txtFecha.Text == "")
            {

            }
            else
            {
                String textoNoticia = Request.Form["txtNoticia"];
                String textoDescripcion = Request.Form["txtDescripcion"];

                //Obtener imagen y mostrar
                int tamaño = cargafoto.PostedFile.ContentLength;
                byte[] imagenOrigen = new Byte[tamaño];
                cargafoto.PostedFile.InputStream.Read(imagenOrigen, 0, tamaño);
                Bitmap imagenBinaria = new Bitmap(cargafoto.PostedFile.InputStream);

                //Crear imagen nueva
                System.Drawing.Image imtNueva;
                int tamañoNueva = 200;
                imtNueva = redimencionar(imagenBinaria, tamañoNueva);
                byte[] ImagenRedimencionada = new byte[tamañoNueva];

                ImageConverter convertir = new ImageConverter();
                ImagenRedimencionada = (byte[])convertir.ConvertTo(imtNueva, typeof(byte[]));

                //Insertar Imagen
                SqlConnection conexionImagen = new SqlConnection("Data Source=LUIS\\SQLEXPRESS;Initial Catalog=Proyecto_201700988;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Noticia(Titulo, Descripcion, Fecha, Noticia, Fotografia) VALUES (@Titulo,@Descripcion,@Fecha,@Noticia,@Fotografia)";
                cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = txtTitulo.Text;
                cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = textoDescripcion;
                cmd.Parameters.Add("@Fecha", SqlDbType.NVarChar).Value = txtFecha.Text;
                cmd.Parameters.Add("@Noticia", SqlDbType.Text).Value = textoNoticia;
                cmd.Parameters.Add("@Fotografia", SqlDbType.Image).Value = ImagenRedimencionada;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexionImagen;
                conexionImagen.Open();
                cmd.ExecuteNonQuery();
                conexionImagen.Close();

                mensaje.Text = "Noticia Creada";
            }
        }

        public System.Drawing.Image redimencionar(System.Drawing.Image ImagenOriginal, int Alto)
        {
            var radio = (double)Alto / ImagenOriginal.Height;
            var NuevoAncho = (int)(ImagenOriginal.Width * radio);
            var NuevoAlto = (int)(ImagenOriginal.Height * radio);
            var nuevaImagen = new Bitmap(NuevoAncho, NuevoAlto);
            var graficos = Graphics.FromImage(nuevaImagen);
            graficos.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return nuevaImagen;
        }
        

    }
}