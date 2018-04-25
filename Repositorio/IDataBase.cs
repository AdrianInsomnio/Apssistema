using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Repositorio
{
    interface IDataBase
    {
        /// <summary>
        /// retorna si la conexion estra Abierta = true o cerrada=False
        /// </summary>
        /// <returns></returns>
        bool Estado();

        /// <summary>
        /// pre-Condicion la conexion esta Cerrada 
        /// true si abre sastifactorio false si hubo algun error 
        /// </summary>
        /// <param name="abrCon"></param>
        /// <returns></returns>
        bool AbrirConexion( string abrCon);

        /// <summary>
        /// true cierra la conexion si esta cerrada ya true 
        /// false si la conexion queda abierta
        /// </summary>
        /// <param name="cerCon"></param>
        /// <returns></returns>
        bool CerrarConexion(string cerCon);
    }
}
