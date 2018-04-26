using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo.Modelo;

namespace CapaModelo.Repositorio
{
   public class RepoItemConfiguracion  
    {
        private string m_CadenaConexion = null;
        public RepoItemConfiguracion(string conn)
        {
            m_CadenaConexion = conn;
        }

        //-------Conexion---------

        private IDbConnection m_conexion;

        private bool ConectarBD(string cadena)
        {
            bool exito = false;
            m_conexion = new SqlConnection(cadena);
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
        private void DesconectarBD()
        {
            if (m_conexion.State == ConnectionState.Open)
            {
                m_conexion.Close();
            }
        }

        //-------End Conexion---------
        private System.Data.IDataReader EjecutarComando(IDbCommand cmd)
        {
            IDataReader datos = null;
            if (m_conexion.State == ConnectionState.Open)
            {
                datos = cmd.ExecuteReader();
            }

            return datos;
        }
        private ItemConfiguracion CrearDelReader(IDataReader datos)
        {
            int codigo = datos.GetInt32(0);
            string nombre = datos.GetString(1);
            string valor = datos.GetString(2);
            string configuracion = datos.GetString(3);
            return new ItemConfiguracion(codigo, nombre, valor, configuracion);
        }
        private IEnumerable<ItemConfiguracion> Find(string sqlComando)
        {
            ConectarBD(m_CadenaConexion);
            IDbCommand buscarPorComando = new SqlCommand(sqlComando, (SqlConnection)m_conexion);
            IDataReader datos = EjecutarComando(buscarPorComando);
            ICollection<ItemConfiguracion> listado = new List<ItemConfiguracion>();
            while (datos.Read())
            {
                listado.Add(CrearDelReader(datos));
            }
            DesconectarBD();
            return listado;
        }
        //---------------Predicados-----------------------------------------------------------
        public ItemConfiguracion BuscarPorCodigo(int codigo)
        {
            IEnumerable<ItemConfiguracion> item = Find(string.Format("SELECT * FROM itemConfiguracion WHERE codigo ={0}", codigo));
            return item.SingleOrDefault();
        }





    }
}
