using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas.publico
{
    internal class MeGusta : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public MeGusta()
        {
            this.con = getConexion();
        }

        public SqlDataReader getLikes()
        {
            Conectar();
            String sql = "SELECT Empresa.Nombre AS NombreEmpresa, ID_Usuario FROM Gusta_Empresa LEFT JOIN Empresa ON ID_Empresa = Empresa.ID";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getTop()
        {
            Conectar();
            String sql = "SELECT TOP 10 Empresa.Nombre AS Nombre, COUNT(*) AS Likes FROM Gusta_Empresa LEFT JOIN Empresa ON ID_Empresa = Empresa.ID GROUP BY Empresa.Nombre ORDER BY Likes DESC;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void Insertar(int IDEMpresa, int  IDUsuario)
        {
            Conectar();
            String sql = "INSERT INTO Gusta_Empresa(ID_Empresa,ID_Usuario)"+
                         "VALUES ("+IDEMpresa+","+IDUsuario+")";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }

    }
}