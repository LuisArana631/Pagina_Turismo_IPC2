using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class PlatoRestaurante : Conexion
    {
        public SqlDataReader registro;
        public SqlConnection con;

        public PlatoRestaurante()
        {
            this.con = getConexion();
        }

        public SqlDataReader getPlato()
        {
            Conectar();
            String sql = "SELECT ID, Nombre, Descripcion FROM Especialidad_Plato;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

    }
}