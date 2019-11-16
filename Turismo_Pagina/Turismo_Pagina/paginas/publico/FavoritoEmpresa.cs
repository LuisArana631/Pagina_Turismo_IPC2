using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas.publico
{
    internal class FavoritoEmpresa : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public FavoritoEmpresa()
        {
            this.con = getConexion();
        }

        public SqlDataReader getFavoritosUsuario(String ID)
        {
            Conectar();
            String sql = "SELECT Empresa.Nombre AS Nombre, ID_Usuario FROM Favorito_Empresa LEFT JOIN Empresa ON ID_Empresa = Empresa.ID WHERE ID_Usuario ="+ID;
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getFavoritos()
        {
            Conectar();
            String sql = "SELECT ID_Empresa, ID_Usuario FROM Favorito_Empresa;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getTopEmpresa()
        {
            Conectar();
            String sql = "SELECT TOP 10 Empresa.Nombre, COUNT(*) AS Favoritos FROM Favorito_Empresa LEFT JOIN Empresa ON ID_Empresa = Empresa.ID GROUP BY Empresa.Nombre ORDER BY Favoritos DESC;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void Insertar(int ID_Empresa,int ID_Usuario)
        {
            Conectar();
            String sql = "INSERT INTO Favorito_Empresa(ID_Empresa,ID_Usuario)" +
                         "VALUES (" + ID_Empresa + "," + ID_Usuario + ")";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }

    }
}