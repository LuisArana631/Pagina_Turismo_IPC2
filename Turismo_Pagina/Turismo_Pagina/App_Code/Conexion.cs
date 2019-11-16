using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Turismo_Pagina
{   

    public class Conexion
    {
        private SqlConnection conexion;

        public Conexion()
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conectar"].ConnectionString;
            this.conexion = new SqlConnection(s);
        }

        public void Conectar()        { 
            this.conexion.Open();
        }

        public void Cerrar()
        {
            this.conexion.Close();
        }

        public SqlConnection getConexion()
        {
            return this.conexion;
        }

    }
}