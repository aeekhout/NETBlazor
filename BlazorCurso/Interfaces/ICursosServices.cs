using BlazorCurso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Interfaces
{
    interface ICursosServices
    {
        Task<IEnumerable<Curso>> getAllCursos();
        
        Task<bool> setCurso(Curso curso);

        Task<Curso> getCurso(int id);

        Task<bool> delCurso(int id);

        Task<IEnumerable<Curso>> getCursosSearch(string search);
    }
}
