using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class MuseoDatos : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public MuseoDatos()
        {
            this.con = getConexion();
        }

        public SqlDataReader getMuseo()
        {
            Conectar();
            String sql = "SELECT ID, Horario, Tarifa FROM Museo_Empresa;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

    }
}