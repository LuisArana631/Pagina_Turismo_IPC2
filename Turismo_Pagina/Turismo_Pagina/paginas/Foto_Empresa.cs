using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class Foto_Empresa : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Foto_Empresa()
        {
            this.con = getConexion();
        }

        public SqlDataReader getFotoEmpresa()
        {
            Conectar();
            String sql = "SELECT ID, ID_Empresa, Fotografia FROM Foto_Empresa;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }        

        public SqlDataReader getFotoEmpresaID(String ID)
        {
            Conectar();
            String sql = "SELECT ID, ID_Empresa, Fotografia FROM Foto_Empresa WHERE ID_Empresa='"+ID+"';";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void CerrarConexion()
        {
            Cerrar();
        }

        public void AbirConexion()
        {
            Conectar();
        }

    }
}