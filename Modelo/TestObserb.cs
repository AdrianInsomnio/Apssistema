using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo.Repositorio;
using CapaModelo.Modulos;
using System.Collections.ObjectModel;

namespace CapaModelo.Modelo
{
    public class TestObserb //: BindableBase, IRepoList<ModuloItemConfiguracion> ,IDataBase       
    {
        private string cadenaConexion;
        

        #region atributos de interfaces

        public bool AbrirConexion(string abrCon)
        {
            throw new NotImplementedException();
        }

        public int Actualizar(ModuloItemConfiguracion a)
        {
            throw new NotImplementedException();
        }

        public int Borrar(int b)
        {
            throw new NotImplementedException();
        }

        public List<ModuloItemConfiguracion> Buscar(string search)
        {
            return new List<ModuloItemConfiguracion>() {  };
        }

        public bool CerrarConexion(string cerCon)
        {
            throw new NotImplementedException();
        }

        public bool Estado()
        {
            throw new NotImplementedException();
        }

        public int Insertar(ModuloItemConfiguracion i)
        {
            throw new NotImplementedException();
        }
        public TestObserb( string cadena)
        {
            cadenaConexion = cadena;
        }
        #endregion


        void inicializar()
        {
            List<ModuloItemConfiguracion> lista = new List<ModuloItemConfiguracion>();

            lista = Buscar("Buscando");

        }
    }
}
