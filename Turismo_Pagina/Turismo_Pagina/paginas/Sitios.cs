using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class Sitios : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Sitios()
        {
            this.con = getConexion();
        }

        public SqlDataReader getSitioRegion(String Region)
        {
            Conectar();
            String sql = "SELECT Sitio_Turistico.ID,Sitio_Turistico.Nombre,Descripcion,Region.Nombre AS Region FROM Sitio_Turistico LEFT JOIN Region ON ID_Region= Region.ID WHERE Sitio_Turistico.ID_Region =" + Region;
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getSitioNombre(String Nombre)
        {
            Conectar();
            String sql = "SELECT Sitio_Turistico.ID,Sitio_Turistico.Nombre,Descripcion,Region.Nombre AS Region FROM Sitio_Turistico LEFT JOIN Region ON ID_Region= Region.ID WHERE Sitio_Turistico.Nombre ='" + Nombre+"'";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getSitioID(String ID)
        {
            Conectar();
            String sql = "SELECT Sitio_Turistico.ID,Sitio_Turistico.Nombre,Descripcion,Region.Nombre AS Region FROM Sitio_Turistico LEFT JOIN Region ON ID_Region= Region.ID WHERE Sitio_Turistico.ID ='"+ID+"'";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getSitios()
        {
            Conectar();
            String sql = "SELECT Sitio_Turistico.ID,Sitio_Turistico.Nombre,Descripcion,Region.Nombre AS Region FROM Sitio_Turistico LEFT JOIN Region ON ID_Region= Region.ID";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        

        public void CerrarConexion()
        {
            Cerrar();
        }

        public void Insertar(String Nombre, String Descripcion, int Region)
        {
            Conectar();
            String sql = "INSERT INTO Sitio_Turistico (Nombre,Descripcion,ID_Region)" +
                          "VALUES ('" + Nombre + "','" + Descripcion + "'," + Region + ")";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }
    }
}