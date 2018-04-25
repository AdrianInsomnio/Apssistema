using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo.Modelo;

namespace CapaModelo.Repositorio
{
   public class RepoItemConfiguracion : IDataBase ,IRepo<Modelo.ItemConfiguracion>
    {
        private string m_Conexion = null;
        public RepoItemConfiguracion(string conn)
        {
            m_Conexion = conn;
        }




        public bool AbrirConexion(string abrCon)
        {
            throw new NotImplementedException();
        }

        public int Actualizar(ItemConfiguracion a)
        {
            throw new NotImplementedException();
        }

        public int Borrar(int b)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ItemConfiguracion> Buscar(string search)
        {
            throw new NotImplementedException();
        }

        public bool CerrarConexion(string cerCon)
        {
            throw new NotImplementedException();
        }

        public bool Estado()
        {
            throw new NotImplementedException();
        }

        public int Insertar(ItemConfiguracion i)
        {
            throw new NotImplementedException();
        }
    }
}
