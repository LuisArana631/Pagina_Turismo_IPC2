using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class Empresas : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Empresas()
        {
            this.con = getConexion();
        }

        public void CerrarConexion()
        {
            Cerrar();
        }

        public void AbrirConexion()
        {
            Conectar();
        }

        public SqlDataReader getEmpresaRegion(String Region)
        {
            Conectar();
            String sql = "SELECT Empresa.ID,Empresa.Nombre,Direccion,Empresa.Telefono,Empresa.Correo,ID_Museo,Region.Nombre AS Region,Tipo_Empresa.Nombre AS Tipo,Estado.Nombre AS Estado,Usuario.Nombre AS Agente FROM Empresa LEFT JOIN Region ON ID_Region = Region.ID LEFT JOIN Tipo_Empresa ON ID_Tipo_Empresa = Tipo_Empresa.ID LEFT JOIN Estado ON ID_Estado = Estado.ID LEFT JOIN Usuario ON DPI_Usuario = Usuario.DPI WHERE  Empresa.ID_Region =" + Region;
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getEmpresaNombre(String Nombre)
        {
            Conectar();
            String sql = "SELECT Empresa.ID,Empresa.Nombre,Direccion,Empresa.Telefono,Empresa.Correo,ID_Museo,Region.Nombre AS Region,Tipo_Empresa.Nombre AS Tipo,Estado.Nombre AS Estado,Usuario.Nombre AS Agente FROM Empresa LEFT JOIN Region ON ID_Region = Region.ID LEFT JOIN Tipo_Empresa ON ID_Tipo_Empresa = Tipo_Empresa.ID LEFT JOIN Estado ON ID_Estado = Estado.ID LEFT JOIN Usuario ON DPI_Usuario = Usuario.DPI WHERE  Empresa.Nombre ='" + Nombre  +"'";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getEmpresaID(String ID)
        {
            Conectar();
            String sql = "SELECT Empresa.ID,Empresa.Nombre,Direccion,Empresa.Telefono,Empresa.Correo,ID_Museo,Region.Nombre AS Region,Tipo_Empresa.Nombre AS Tipo,Estado.Nombre AS Estado,Usuario.Nombre AS Agente FROM Empresa LEFT JOIN Region ON ID_Region = Region.ID LEFT JOIN Tipo_Empresa ON ID_Tipo_Empresa = Tipo_Empresa.ID LEFT JOIN Estado ON ID_Estado = Estado.ID LEFT JOIN Usuario ON DPI_Usuario = Usuario.DPI WHERE Empresa.ID ='"+ID+"'";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getEmpresas()
        {
            Conectar();
            String sql = "SELECT Empresa.ID,Empresa.Nombre,Direccion,Empresa.Telefono,Empresa.Correo,ID_Museo,Region.Nombre AS Region,Tipo_Empresa.Nombre AS Tipo,Estado.Nombre AS Estado,Usuario.Nombre AS Agente FROM Empresa LEFT JOIN Region ON ID_Region = Region.ID LEFT JOIN Tipo_Empresa ON ID_Tipo_Empresa = Tipo_Empresa.ID LEFT JOIN Estado ON ID_Estado = Estado.ID LEFT JOIN Usuario ON DPI_Usuario = Usuario.DPI ";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void Insertar(String Nombre, String Direccion, String Telefono, String Correo, int IDMuseo, int IDRegion, int  IDTipo, int ID_Estado)
        {
            Conectar();
            String sql = "INSERT INTO Empresa(Nombre,Direccion,Telefono,Correo,ID_Museo,ID_Region,ID_Tipo_Empresa,ID_Estado)" +
                         "VALUES ('"+Nombre+"','"+Direccion+"','"+Telefono+"','"+Correo+"',"+IDMuseo+","+IDRegion+","+IDTipo+","+ID_Estado+")";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }
    }
}