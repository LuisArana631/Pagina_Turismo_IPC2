using System;
using System.Data.SqlClient;

namespace Turismo_Pagina.paginas
{
    internal class Platillo_Empresa : Conexion
    {
        private SqlDataReader registro;
        private SqlConnection con;

        public Platillo_Empresa()
        {
            this.con = getConexion();
        }

        public SqlDataReader getPlatillos()
        {
            Conectar();
            String sql = "SELECT ID_Especialidad,ID_Empresa,Aceptar_Especialidad FROM Empresa_Especialidad";
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public SqlDataReader getPlatilloID(String ID)
        {
            Conectar();
            String sql = "SELECT Especialidad_Plato.Nombre AS Plato ,ID_Empresa,Aceptar_Especialidad FROM Empresa_Especialidad LEFT JOIN Especialidad_Plato ON ID_Especialidad = Especialidad_Plato.ID WHERE ID_Empresa=" + ID;
            SqlCommand comando = new SqlCommand(sql, this.con);
            this.registro = comando.ExecuteReader();
            return this.registro;
        }

        public void Insertar(int ID_Especialidad, int ID_Empresa, Char Aceptar)
        {
            Conectar();
            String sql = "INSERT INTO Empresa_Especialidad(ID_Especialidad,ID_Empresa,Aceptar_Especialidad)" +
                         "VALUES (" + ID_Especialidad + "," + ID_Empresa + ",'" + Aceptar + "')";
            SqlCommand comando = new SqlCommand(sql, this.con);
            comando.ExecuteNonQuery();
            Cerrar();
        }
    }
}