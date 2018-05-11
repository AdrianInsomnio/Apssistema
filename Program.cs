using CapaModelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;

using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using MySql.Data.MySqlClient;

namespace ConsoleTest
{
    class Program
    {
       static SqlCeConnection m_conexion;

        private static bool ConectarBD(string cadena)
        {
            bool exito = false;
            m_conexion = new SqlCeConnection(cadena);
            try
            {
                m_conexion.Open();
                exito = true;
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;
        }

        static void Main(string[] args)
        {
            //("server=DIEGO-PC\\SQLEXPRESS ; database=base1 ; integrated security = true");
            //string conexionString = @"Data Source=C:\Users\Usuario\Documents\Visual Studio 2017\Projects\WpfApp1\test01.sdf;Password=dev1234";

            //DB db = new DB(conexionString);

            //db.Consulta("select * from  usuario where 1=1;");

            //        var connection =
            //System.Configuration.ConfigurationManager.
            //ConnectionStrings["Test"].ConnectionString;
            //var connection = @"Data Source=C: \Users\Usuario\Documents\Visual Studio 2017\Projects\WpfApp1\test01.sdf;Password=dev1234";



            //if (ConectarBD(connection))
            //{ Console.WriteLine("Conecto"); }
            //else { Console.WriteLine("NO Conecto"); }


            using (SqlCeConnection connection = new SqlCeConnection(@"Data Source=C:\data\test01.sdf;Password=dev1234;"))
            {
                connection.Open();
                Console.WriteLine(connection);
                Console.WriteLine("Conecto");
                connection.Close();
            }
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = @"Server=localhost;Database=appsisv1;UID=root;Password=dev1234";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM appsisv1.persona;", conn))
                { 

                    MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine("item {0} {1} " , dr.GetInt32(0) , dr.GetString(1));
                }
                }
                conn.Close();
            }

                //RepoItemConfiguracion ttt;
                //ttt = new RepoItemConfiguracion(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C: \Users\Usuario\Documents\Visual Studio 2017\Projects\WpfApp1\CapaModelo\BD\Sistema.mdf"";Integrated Security=True");
                //Console.WriteLine(ttt.BuscarPorCodigo(1));
                Console.ReadKey();
        }
    }
}
