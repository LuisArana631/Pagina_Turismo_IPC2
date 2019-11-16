using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas.administrador
{
    internal class Noticia : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Noticia()
        {
            this.con = getConexion();
        }

        public SqlDataReader getNoticias()
        {
            Conectar();
            String sql = "SELECT ID,Titulo,Descripcion,Fecha,Noticia,Fotografia FROM Noticia;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getNoticiaID(String ID)
        {
            Conectar();
            String sql = "SELECT ID,Titulo,Descripcion,Fecha,Noticia,Fotografia FROM Noticia WHERE ID = '"+ID+"';";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

    }
}