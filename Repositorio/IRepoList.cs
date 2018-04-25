using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Repositorio
{
    interface IRepoList<T> where T : class
    {
        int Insertar(T i);
        int Actualizar(T a);
        int Borrar(int b);
        List<T> Buscar(string search);
    }
}
