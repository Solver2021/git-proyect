using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace NewApp2
{
    public class  Conexion
    {
        public SqlConnection cadena()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            if(cn.State == ConnectionState.Open)
            {
                Console.WriteLine("Cerrando");
                cn.Close();
            }
            else
            {
                Console.WriteLine("Abriendo");
                cn.Open();
            }
            return cn;
        }

    }
}
