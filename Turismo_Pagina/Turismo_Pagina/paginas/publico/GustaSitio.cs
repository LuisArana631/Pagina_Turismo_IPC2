using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas.publico
{
    internal class GustaSitio : Conexion      
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public GustaSitio()
        {
            this.con = getConexion();
        }

        public SqlDataReader getLikes()
        {
            Conectar();
            String sql = "SELECT Sitio.Nombre AS NombreSitio, ID_Usuario FROM Gusta_Sitio LEFT JOIN Sitio_Turistico ON ID_Sitio = Sitio_Turistico.ID";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getTop()
        {
            Conectar();
            String sql = "SELECT TOP 10 Sitio_Turistico.Nombre AS Nombre, COUNT(*) AS Likes FROM Gusta_Sitio LEFT JOIN Sitio_Turistico ON ID_Sitio = Sitio_Turistico.ID GROUP BY Sitio_Turistico.Nombre ORDER BY Likes DESC;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void Insertar(int IDSitio, int IDUsuario)
        {
            Conectar();
            String sql = "INSERT INTO Gusta_Sitio(ID_Sitio,ID_Usuario)" +
                         "VALUES (" + IDSitio + "," + IDUsuario + ")";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }

    }
}