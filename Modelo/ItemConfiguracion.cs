using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CapaModelo.Modelo
{
   public class ItemConfiguracion :INotifyPropertyChanged       
    {


        #region Atributos
        private int m_Id;

        public int CodigoItemConfiguracion
        {
            get { return m_Id; }
            set
            {
                if (value != this.m_Id)
                {
                    this.m_Id = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string m_Nombre;
                
        public string Nombre
        {
            get { return m_Nombre; }
            set
            {
                if (value != this.m_Nombre)
                {
                    this.m_Nombre = value;
                    NotifyPropertyChanged();
                }
            }
        }



        private string m_Valor;

        public string Valor
        {
            get { return m_Valor; }
            set
            {
                if (value != this.m_Valor)
                {
                    this.m_Valor = value;
                    NotifyPropertyChanged();
                }
            }
        }



        private string  m_Configuracion;

        public string  Configuracion
        {
            get { return m_Configuracion; }
            set
            {if (m_Configuracion != value)
                {
                    m_Configuracion = value;
                    NotifyPropertyChanged();
                }
        }
        }




        #endregion


        #region Constructores

        #endregion

        #region Interfaz


        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
