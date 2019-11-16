using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class Publicos:Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Publicos()
        {
            this.con = getConexion();
        }

        public SqlDataReader getPublicoID(String ID)
        {
            Conectar();
            String sql = "SELECT ID,Usuario,Contraseña FROM Usuario_Publico WHERE Usuario='"+ID+"';";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getPublicos()
        {
            Conectar();
            String sql = "SELECT ID,Usuario,Contraseña FROM Usuario_Publico;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();            
            return this.registro;
        }

        public void CerrarConexion()
        {
            Cerrar();
        }

        public void Insertar(String Usuario, String Contraseña)
        {
            Conectar();
            String sql = "INSERT INTO Usuario_Publico (Usuario,Contraseña)" +
                         "VALUES ('" + Usuario + "','" + Contraseña + "')";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }

        public Boolean VerificarUsuario(String Usuario)
        {
            Conectar();
            String sql = "SELECT * FROM Usuario_Publico WHERE Usuario='" + Usuario + "';";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();            
            if (registro.HasRows)
            {
                Cerrar();
                return true;                
            }
            else
            {
                Cerrar();
                return false;
            }                   
        }

        public Boolean VerificarCredenciales(String Usuario, String Contraseña)
        {
            Conectar();
            String sql = "SELECT * FROM Usuario_Publico WHERE Usuario='"+Usuario+"' AND Contraseña='"+Contraseña+"';";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            if(registro.HasRows)
            {
                Cerrar();
                return true;
            }
            else
            {
                Cerrar();
                return false;
            }
        }
    }
}