﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.ObjectModel;

namespace CapaModelo.Repositorio
{
    interface IRepo<T> where T : class 
    {
       int Insertar(T i);
       int Actualizar(T a);
       int Borrar(int b);
       ObservableCollection <T> Buscar(string search);
    }
}
