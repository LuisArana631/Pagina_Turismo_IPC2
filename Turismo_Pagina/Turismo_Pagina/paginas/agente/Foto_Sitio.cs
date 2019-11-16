 using System.Data.SqlClient;
using System;
using System.Data;

namespace Turismo_Pagina.paginas.agente
{
    internal class Foto_Sitio : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Foto_Sitio()
        {
            this.con = getConexion();
        }

        public SqlDataReader getFotoSitio()
        {
            Conectar();
            String sql = "SELECT ID, Fotografia, Pie, ID_Sitio_Turistico FROM Foto_Sitio;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getFotoSitioID(String ID)
        {
            Conectar();
            String sql = "SELECT ID, Fotografia, Pie, ID_Sitio_Turistico FROM Foto_Sitio WHERE ID_Sitio_Turistico ='"+ID+"';";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void CerrarConexion()
        {
            Cerrar();
        }

        public void AbrirConexion()
        {
            Conectar();
        }       

    }
}