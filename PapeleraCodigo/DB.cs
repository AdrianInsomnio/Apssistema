using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApplication2.CapaDatos
{
    public  class DB
    {
        private static MySqlConnection conexion;
        private string server = "server=127.0.0.1;";
        private string database ="database=pruebaadrian;";
        private string uid="Uid = root;";
        private string password =" pwd = dev1234;" ;

        private string cadena;

        public DB() {
            cadena = server+database+uid+password;
            conexion =new MySqlConnection(cadena); 
        }

        public static MySqlConnection ObtenerConexion()
        {
           // MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=pruebaadrian; Uid=root; pwd=dev1234;");
            conexion.Open();
           // conectar.Open();

            return conexion;
        }

        public static MySqlConnection conectar()
        {

            try
            {  
                if ( conexion.State != ConnectionState.Open )
                {
                conexion.Open();
                }
            }catch (Exception s) 
            {
                Console.WriteLine(s.Message);
            }
            
            return conexion;
           
        }
        public static bool cerrarConexion() 
        {


            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkDB_Conn()
        {
            var conn_info = "server=127.0.0.1; database=pruebaadrian; Uid=root; pwd=dev1234;";
            bool isConn = false;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(conn_info);
                conn.Open();
                isConn = true;
            }
            catch (ArgumentException a_ex)
            {
                /*
                Console.WriteLine("Check the Connection String.");
                Console.WriteLine(a_ex.Message);
                Console.WriteLine(a_ex.ToString());
                */
            }
            catch (MySqlException ex)
            {
                /*string sqlErrorMessage = "Message: " + ex.Message + "\n" +
                "Source: " + ex.Source + "\n" +
                "Number: " + ex.Number;
                Console.WriteLine(sqlErrorMessage);
                */
                isConn = false;
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042: // Unable to connect to any of the specified MySQL hosts (Check Server,Port)
                        break;
                    case 0: // Access denied (Check DB name,username,password)
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                //var cx = conexion.State;
                //if (cx == ConnectionState.Open)
                //{
                //    conexion.Close();
                //    isConn = false;
                //}
            }
            return isConn;
        }
       
    }
    }
