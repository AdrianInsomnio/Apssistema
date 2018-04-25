using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Modelo
{
   public class ItemPermiso : Repositorio.BindableBase
    {
        #region atributos
        private int m_CodigoItemPermiso;

        public int CodigoItemPermiso
        {
            get { return m_CodigoItemPermiso; }
            set
            {
                SetProperty(ref  m_CodigoItemPermiso , value);

            }
        }

        private string m_DescripcionItemPermiso;

        public string DescripcionItemPermiso
        {
            get { return m_DescripcionItemPermiso; }
            set { SetProperty(ref m_DescripcionItemPermiso ,value); }
        }
        private int m_ValorPermiso;

        public int ValorPermiso
        {
            get { return m_ValorPermiso; }
            set { SetProperty(ref m_ValorPermiso , value); }
        }

        #region
        public ItemPermiso(int codigo,string descrpcion,int valor)
        {
            CodigoItemPermiso = codigo;DescripcionItemPermiso = descrpcion;ValorPermiso = valor;

        }
        public override string ToString()
        {
            return String.Format("Codigo {0} descrpcion {1} valor {2} ", CodigoItemPermiso,DescripcionItemPermiso,ValorPermiso);
        }
    }
}
