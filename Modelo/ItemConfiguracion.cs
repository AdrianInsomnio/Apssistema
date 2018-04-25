using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CapaModelo.Modelo
{
    public class ItemConfiguracion : Repositorio.BindableBase
    {


        #region Atributos
        private int m_Id;

        public int CodigoItemConfiguracion
        {
            get { return m_Id; }
            set
            {
                SetProperty(ref this.m_Id, value);
            }
        }



        private string m_Nombre;

        public string Nombre
        {
            get { return m_Nombre; }
            set
            {
                SetProperty(ref this.m_Nombre, value);
            }

        }



        private string m_Valor;

        public string Valor
        {
            get { return m_Valor; }
            set
            {
                SetProperty(ref this.m_Valor, value);
            }
        }



        private string m_Configuracion;

        public string Configuracion
        {
            get { return m_Configuracion; }
            set
            {
                SetProperty(ref m_Configuracion, value);
            }
        }





        #endregion


        #region Constructores
        public ItemConfiguracion(int codigo, string nombre, string valor, string configuracion)
        {
            CodigoItemConfiguracion = codigo;Nombre = nombre;Valor = valor;Configuracion = configuracion;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Codigo {0} -Nombre {1} -Valor {2}",CodigoItemConfiguracion,Nombre,Valor);
        }

        #region Interfaz




        #endregion



    }   
}
