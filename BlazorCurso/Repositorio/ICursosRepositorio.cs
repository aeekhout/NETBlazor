using BlazorCurso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Repositorio
{
    interface ICursosRepositorio
    {

        Task<bool>createCurso(Curso curso);

        Task<IEnumerable<Curso>> getAllCursos();

        Task<Curso> getCurso(int id);

        Task<bool> setCurso(Curso curso);

        Task<bool> delCurso(int id);

        Task<IEnumerable<Curso>> getCursosSearch(String busqueda);

    }
}
