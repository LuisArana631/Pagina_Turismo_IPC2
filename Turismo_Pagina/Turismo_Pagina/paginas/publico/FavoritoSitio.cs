using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas.publico
{
    internal class FavoritoSitio : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public FavoritoSitio()
        {
            this.con = getConexion();
        }

        public SqlDataReader getFavoritosUsuario(String ID)
        {
            Conectar();
            String sql = "SELECT Sitio_Turistico.Nombre AS Nombre, ID_Usuario FROM Favorito_Sitio LEFT JOIN Sitio_Turistico ON ID_Sitio = Sitio_Turistico.ID WHERE ID_Usuario="+ID;
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getFavoritos()
        {
            Conectar();
            String sql = "SELECT ID_Sitio, ID_Usuario FROM Favorito_Sitio;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getTopSitios()
        {
            Conectar();
            String sql = "SELECT TOP 10 Sitio_Turistico.Nombre AS Nombre, COUNT(*) AS Favoritos FROM Favorito_Sitio LEFT JOIN Sitio_Turistico ON ID_Sitio = Sitio_Turistico.ID GROUP BY Sitio_Turistico.Nombre ORDER BY Favoritos DESC;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void Insertar(int ID_Sitio, int ID_Usuario)
        {
            Conectar();
            String sql = "INSERT INTO Favorito_Sitio(ID_Sitio,ID_Usuario)" +
                         "VALUES (" + ID_Sitio + "," + ID_Usuario + ")";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }
    }
}