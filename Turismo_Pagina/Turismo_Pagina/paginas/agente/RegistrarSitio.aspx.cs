using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas.agente
{
    public partial class RegistrarSitio : System.Web.UI.Page
    {

        private Conexion con;
        private Sitios sitios;
        private Foto_Sitio fotoSitio;
        private SqlDataReader registro;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Conexion();
            con.Conectar();
            this.sitios = new Sitios();
            this.fotoSitio = new Foto_Sitio();
        }

        protected void boton_Click(object sender, EventArgs e)
        {                
            if (cargafoto.HasFile==false || nombre.Text=="")
            {
                mensaje.Text = "No has llenado todos los datos";
            }
            else
            {

                int IDSitio = 0;

                String RegionSeleccionado = listRegion.Text;
                String textoDescripcion = Request.Form["txtdescripcion"];
                String textoPie = Request.Form["piefoto"];

                if (RegionSeleccionado == "Norte")
                {
                    this.sitios.Insertar(nombre.Text, textoDescripcion, 1);
                    mensaje.Text = "Registro completo";

                    //Obtener ID Sitio                    
                    this.registro = this.sitios.getSitios();
                    while (getDatos().Read())
                    {
                        Object Sitio = getDatos()["Nombre"];
                        String SitioComparar = Sitio.ToString();
                        if(SitioComparar==nombre.Text)
                        {
                            Object IDato = getDatos()["ID"];
                            IDSitio = Int32.Parse(IDato.ToString());
                        }
                    }                                                                        

                }
                else if (RegionSeleccionado == "Sur")
                {
                    this.sitios.Insertar(nombre.Text, textoDescripcion, 2);
                    mensaje.Text = "Registro completo";

                    //Obtener ID Sitio                    
                    this.registro = this.sitios.getSitios();
                    while (getDatos().Read())
                    {
                        Object Sitio = getDatos()["Nombre"];
                        String SitioComparar = Sitio.ToString();
                        if (SitioComparar == nombre.Text)
                        {
                            Object IDato = getDatos()["ID"];
                            IDSitio = Int32.Parse(IDato.ToString());
                        }
                    }
                }
                else if (RegionSeleccionado == "Este")
                {
                    this.sitios.Insertar(nombre.Text, textoDescripcion, 3);
                    mensaje.Text = "Registro completo";

                    //Obtener ID Sitio                    
                    this.registro = this.sitios.getSitios();
                    while (getDatos().Read())
                    {
                        Object Sitio = getDatos()["Nombre"];
                        String SitioComparar = Sitio.ToString();
                        if (SitioComparar == nombre.Text)
                        {
                            Object IDato = getDatos()["ID"];
                            IDSitio = Int32.Parse(IDato.ToString());
                        }
                    }
                }
                else if (RegionSeleccionado == "Oeste")
                {
                    this.sitios.Insertar(nombre.Text, textoDescripcion, 4);
                    mensaje.Text = "Registro completo";

                    //Obtener ID Sitio                    
                    this.registro = this.sitios.getSitios();
                    while (getDatos().Read())
                    {
                        Object Sitio = getDatos()["Nombre"];
                        String SitioComparar = Sitio.ToString();
                        if (SitioComparar == nombre.Text)
                        {
                            Object IDato = getDatos()["ID"];
                            IDSitio = Int32.Parse(IDato.ToString());
                        }
                    }
                }

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
                cmd.CommandText = "INSERT INTO Foto_Sitio(Fotografia, Pie, ID_Sitio_Turistico) VALUES (@Foto,@Pie,@IDSitio)";
                cmd.Parameters.Add("@Foto", SqlDbType.Image).Value = ImagenRedimencionada;
                cmd.Parameters.Add("@Pie", SqlDbType.VarChar).Value = textoPie;
                cmd.Parameters.Add("@IDSitio", SqlDbType.Int).Value = IDSitio;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexionImagen;
                conexionImagen.Open();
                cmd.ExecuteNonQuery();
                conexionImagen.Close();
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

        public SqlDataReader getDatos()
        {
            return this.registro;
        }        
        
    }
}