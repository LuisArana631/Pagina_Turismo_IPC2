using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas.administrador
{
    internal class Usuarios : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Usuarios()
        {
            this.con = getConexion();
        }

        public SqlDataReader getUsuarios()
        {
            Conectar();
            String sql = "SELECT DPI,Usuario.Nombre,Correo,Telefono,Usuario,Contraseña,Tipo_Usuario.Nombre AS Tipo FROM Usuario LEFT JOIN Tipo_Usuario ON ID_Tipo_Usuario = Tipo_Usuario.ID;";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();            
            return this.registro;          
        }

        public void Insertar(String DPI, String Nombre, String Correo, String Telefono, String Usuario, String Contraseña, int Tipo)
        {
            Conectar();
            String sql = "INSERT INTO Usuario(DPI,Nombre,Correo,Telefono,Usuario,Contraseña,ID_Tipo_Usuario)" +
                         "VALUES ('" + DPI + "','" + Nombre + "','" + Correo + "','" + Telefono + "','" + Usuario + "','" + Contraseña + "'," + Tipo +")";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }

        public void CerrarConexion()
        {
            Cerrar();
        }

        public Boolean VerificarUsuario(String Usuario)
        {
            Conectar();
            String sql = "SELECT * FROM Usuario WHERE Usuario='" + Usuario + "';";
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
            String sql = "SELECT * FROM Usuario WHERE Usuario='"+Usuario+"' AND Contraseña='"+Contraseña+"';";
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