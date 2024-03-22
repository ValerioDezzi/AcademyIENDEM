﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGestionePrestitiLibri.DAL
{
    internal interface IDal <T>
    {
        T? GetById(int id);
        List<T> GetAll();
        bool Insert(T t);
        bool Update(T t);
        bool Delete(T t);
    }
}
