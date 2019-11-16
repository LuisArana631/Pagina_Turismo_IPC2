using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turismo_Pagina.paginas
{
    public partial class Formulario_Empresa : System.Web.UI.Page
    {
        String valor;
        int IDEmpresa;
        int IDServicio;
        int IDPlatillo;

        //Para registrar la empresa
        private Conexion con;
        private Empresas empresas;
        private Servicio_Empresa servicioConEmpresa;
        private Platillo_Empresa platillo_Empresa;

        //Para mostrar opciones
        private ServiciosEmpresa serviciosEmpresa;
        private MuseoDatos museoDatos;
        private PlatoRestaurante platoRestaurante;

        private SqlDataReader registroServicios;
        private SqlDataReader registroMuseo;
        private SqlDataReader registroPlato;
        private SqlDataReader registroEmpresa;

        protected void Page_Load(object sender, EventArgs e)
        {            

            con = new Conexion();

            this.servicioConEmpresa = new Servicio_Empresa();
            this.platillo_Empresa = new Platillo_Empresa();

            this.serviciosEmpresa = new ServiciosEmpresa();
            this.museoDatos = new MuseoDatos();
            this.platoRestaurante = new PlatoRestaurante();
            this.empresas = new Empresas();

            this.registroServicios = this.serviciosEmpresa.getServicios();
            this.registroMuseo = this.museoDatos.getMuseo();
            this.registroPlato = this.platoRestaurante.getPlato();

            if (!Page.IsPostBack)
            {
                                
                //Cargar Datos del museo
                if (getMuseo().Read())
                {
                    String HorarioMuseo = getMuseo()["Horario"].ToString();
                    horario.Text = HorarioMuseo;
                    String TarifaMuseo = getMuseo()["Tarifa"].ToString();
                    tarifa.Text = TarifaMuseo;
                }

                //Cargando Servicios
                listServicios.Items.Clear();
                while (getServicio().Read())
                {
                    String NombreServicio = getServicio()["Nombre"].ToString();
                    listServicios.Items.Add(NombreServicio);
                }

                //Cargando Platos
                listEspecialidades.Items.Clear();
                while (getPlatos().Read())
                {
                    String NombrePlato = getPlatos()["Nombre"].ToString();
                    listEspecialidades.Items.Add(NombrePlato);
                }
            }

        }

        public void limpiarformularios()
        {
            tarifa.Text = "";
            horario.Text = "";
            nombre.Text = "";
            mensaje.Text = "Registro exitoso";
            direccion.Text = "";
            correo.Text = "";
            telefono.Text = "";
        }

        public SqlDataReader getEmpresas()
        {
            return this.registroEmpresa;
        }

        public SqlDataReader getServicio()
        {
            return this.registroServicios;
        }

        public SqlDataReader getPlatos()
        {
            return this.registroPlato;
        }

        public SqlDataReader getMuseo()
        {
            return this.registroMuseo;
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            con.Cerrar();
            valor = listTipo.SelectedValue;

            //Registro de Museos
            if (valor == "Museo")
            {
                if (nombre.Text == "")
                {
                    mensaje.Text = "No has ingresado el nombre.";
                }
                else if(direccion.Text  == "")
                {
                    mensaje.Text = "No has ingresado la dirección";
                }
                else
                {

                    int Region = listRegion.SelectedIndex + 1;

                    this.empresas.CerrarConexion();

                    //Registrar Empresa                    
                    this.empresas.Insertar(nombre.Text, direccion.Text, telefono.Text, correo.Text, 1, Region, 1, 1);

                    //Recuperar ID_Empresa
                    this.registroEmpresa = this.empresas.getEmpresas();
                    while (getEmpresas().Read())
                    {
                        Object Empresa = getEmpresas()["Nombre"];
                        String EmpresaComparar = Empresa.ToString();
                        if (EmpresaComparar == nombre.Text)
                        {
                            Object IDato = getEmpresas()["ID"];
                            IDEmpresa = Int32.Parse(IDato.ToString());
                        }
                    }

                    //Registrar Foto
                    int tamaño = cargaFoto.PostedFile.ContentLength;
                    byte[] imagenOrigen = new Byte[tamaño];
                    cargaFoto.PostedFile.InputStream.Read(imagenOrigen, 0, tamaño);
                    Bitmap imagenBinaria = new Bitmap(cargaFoto.PostedFile.InputStream);

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
                    cmd.CommandText = "INSERT INTO Foto_Empresa(Fotografia, ID_Empresa) VALUES (@Foto,@IDEmpresa)";
                    cmd.Parameters.Add("@Foto", SqlDbType.Image).Value = ImagenRedimencionada;
                    cmd.Parameters.Add("@IDEmpresa", SqlDbType.Int).Value = IDEmpresa;

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexionImagen;
                    conexionImagen.Open();
                    cmd.ExecuteNonQuery();
                    conexionImagen.Close();

                    mensaje.Text = "Formulario Enviado";
                    limpiarformularios();
                }
            }
            //Registro de Hoteles
            else if (valor == "Hotel")
            {
                if (nombre.Text == "")
                {
                    mensaje.Text = "No has ingresado el nombre.";
                }
                else if (direccion.Text == "")
                {
                    mensaje.Text = "No has ingresado la dirección";
                }
                else if (cargaFoto.HasFile==false)
                {
                    mensaje.Text = "Debes cargar una foto.";
                }
                else
                {
                    int Region = listRegion.SelectedIndex + 1;

                    this.empresas.CerrarConexion();

                    //Registrar Empresa
                    this.empresas.Insertar(nombre.Text, direccion.Text, telefono.Text, correo.Text, 1, Region, 3, 1);

                    //Recuperar ID_Empresa
                    this.registroEmpresa = this.empresas.getEmpresas();
                    while (getEmpresas().Read())
                    {
                        Object Empresa = getEmpresas()["Nombre"];
                        String EmpresaComparar = Empresa.ToString();
                        if (EmpresaComparar == nombre.Text)
                        {
                            Object IDato = getEmpresas()["ID"];
                            IDEmpresa = Int32.Parse(IDato.ToString());
                        }
                    }

                    Boolean Agregar = false;                    

                    //Agregar servicios Seleccionados                    
                    for (int i = 0; i < listServicios.Items.Count; i++)
                    {
                        if (listServicios.Items[i].Selected == true)
                        {
                            //Alguna accion al encontrar un check seleccionado                            
                            string NombreCasilla = listServicios.Items[i].Text;

                            //Recuperar ID Servicio
                            while (getServicio().Read())
                            {
                                Object ServicioObtenido = getServicio()["Nombre"];
                                String ServicioComparar = ServicioObtenido.ToString();
                                if (ServicioComparar == NombreCasilla)
                                {
                                    Object IDato = getServicio()["ID"];
                                    IDServicio = Int32.Parse(IDato.ToString());
                                    Agregar = true;
                                    break;
                                }
                            }
                            if (Agregar)
                            {
                                //Añadir Servicio                            
                                this.servicioConEmpresa.Insertar(IDServicio, IDEmpresa, 'N');
                                Agregar = false;
                            }
                            
                        }                        
                    }                   
                    
                    //Registrar Foto
                    int tamaño = cargaFoto.PostedFile.ContentLength;
                    byte[] imagenOrigen = new Byte[tamaño];
                    cargaFoto.PostedFile.InputStream.Read(imagenOrigen, 0, tamaño);
                    Bitmap imagenBinaria = new Bitmap(cargaFoto.PostedFile.InputStream);

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
                    cmd.CommandText = "INSERT INTO Foto_Empresa(Fotografia, ID_Empresa) VALUES (@Foto,@IDEmpresa)";
                    cmd.Parameters.Add("@Foto", SqlDbType.Image).Value = ImagenRedimencionada;
                    cmd.Parameters.Add("@IDEmpresa", SqlDbType.Int).Value = IDEmpresa;

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexionImagen;
                    conexionImagen.Open();
                    cmd.ExecuteNonQuery();
                    conexionImagen.Close();

                    mensaje.Text = "Formulario Enviado";
                    limpiarformularios();
                }
                // Registro de Restaurante
            }
            else if (valor == "Restaurante")
            {
                if (nombre.Text == "")
                {
                    mensaje.Text = "No has ingresado el nombre.";
                }
                else if (direccion.Text == "")
                {
                    mensaje.Text = "No has ingresado la dirección";
                }
                else if (cargaFoto.HasFile == false)
                {
                    mensaje.Text = "Debes cargar una foto.";
                }
                else
                {
                    int Region = listRegion.SelectedIndex + 1;

                    this.empresas.CerrarConexion();

                    //Registrar Empresa
                    this.empresas.Insertar(nombre.Text, direccion.Text, telefono.Text, correo.Text, 1, Region, 2, 1);

                    //Recuperar ID_Empresa
                    this.registroEmpresa = this.empresas.getEmpresas();
                    while (getEmpresas().Read())
                    {
                        Object Empresa = getEmpresas()["Nombre"];
                        String EmpresaComparar = Empresa.ToString();
                        if (EmpresaComparar == nombre.Text)
                        {
                            Object IDato = getEmpresas()["ID"];
                            IDEmpresa = Int32.Parse(IDato.ToString());
                        }
                    }

                    Boolean Agregar = false;

                    //Añadir Platillos Restaurante
                    for (int i = 0; i < listEspecialidades.Items.Count; i++)
                    {
                        if (listEspecialidades.Items[i].Selected == true)
                        {
                            //Alguna accion al encontrar un check seleccionado                            
                            string NombreCasilla = listEspecialidades.Items[i].Text;

                            //Recuperar ID Servicio
                            while (getPlatos().Read())
                            {
                                Object PlatoObtenido = getPlatos()["Nombre"];
                                String PlatoComparar = PlatoObtenido.ToString();
                                if (PlatoComparar == NombreCasilla)
                                {
                                    Object IDato = getPlatos()["ID"];
                                    IDPlatillo = Int32.Parse(IDato.ToString());
                                    Agregar = true;
                                    break;
                                }
                            }
                            if (Agregar)
                            {
                                //Añadir Servicio                            
                                this.platillo_Empresa.Insertar(IDPlatillo, IDEmpresa, 'N');
                                Agregar = false;
                            }

                        }
                    }
                    //Registrar Foto
                    int tamaño = cargaFoto.PostedFile.ContentLength;
                    byte[] imagenOrigen = new Byte[tamaño];
                    cargaFoto.PostedFile.InputStream.Read(imagenOrigen, 0, tamaño);
                    Bitmap imagenBinaria = new Bitmap(cargaFoto.PostedFile.InputStream);

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
                    cmd.CommandText = "INSERT INTO Foto_Empresa(Fotografia, ID_Empresa) VALUES (@Foto,@IDEmpresa)";
                    cmd.Parameters.Add("@Foto", SqlDbType.Image).Value = ImagenRedimencionada;
                    cmd.Parameters.Add("@IDEmpresa", SqlDbType.Int).Value = IDEmpresa;

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexionImagen;
                    conexionImagen.Open();
                    cmd.ExecuteNonQuery();
                    conexionImagen.Close();

                    mensaje.Text = "Formulario Enviado";
                    limpiarformularios();
                }
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

        protected void listTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTipo.SelectedIndex==0)
            {
                horario.Visible = true;
                tarifa.Visible = true;

                listServicios.Visible = false;
                listEspecialidades.Visible = false;
            }
            else if (listTipo.SelectedIndex==2)
            {
                listServicios.Visible = true;

                listEspecialidades.Visible = false;
                horario.Visible = false;
                tarifa.Visible = false;
            }
            else
            {
                listEspecialidades.Visible = true;

                listServicios.Visible = false;
                horario.Visible = false;
                tarifa.Visible = false;
            }
        }
    }
}