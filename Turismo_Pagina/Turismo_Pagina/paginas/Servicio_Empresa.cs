using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class Servicio_Empresa : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Servicio_Empresa()
        {
            this.con = getConexion();
        }

        public SqlDataReader getServicioID(String ID)
        {
            Conectar();
            String sql = "SELECT Servicio_Empresa.Nombre AS Servicio, ID_Empresa, Aceptar_Servicio FROM Empresa_Hotel LEFT JOIN Servicio_Empresa ON ID_Servicio = Servicio_Empresa.ID" +
                " WHERE ID_Empresa = "+ID;
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getServicio_Empresa()
        {
            Conectar();
            String sql = "SELECT ID_Servicio, ID_Empresa, Aceptar_Servicio FROM Empresa_Hotel;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void Insertar(int IDServicio, int IDEmpresa, Char Aceptar)
        {
            Conectar();
            String sql = "INSERT INTO Empresa_Hotel(ID_Servicio,ID_Empresa,Aceptar_Servicio) " +
                         "VALUES ("+IDServicio+","+IDEmpresa+",'"+Aceptar+"')";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }
    }
}