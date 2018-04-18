using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Repositorio
{
    interface IDataBase
    {
        bool Estado();
        bool AbrirConexion( string abrCon);

        bool CerrarConexion(string cerCon);
    }
}
