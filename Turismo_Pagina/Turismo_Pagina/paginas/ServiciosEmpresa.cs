using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class ServiciosEmpresa : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public ServiciosEmpresa()
        {
            this.con = getConexion();
        }

        public SqlDataReader getServicios()
        {
            Conectar();
            String sql = "SELECT ID,Nombre,Descripcion FROM Servicio_Empresa;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }
        
    }
}