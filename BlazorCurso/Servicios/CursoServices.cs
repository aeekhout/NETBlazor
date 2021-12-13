using BlazorCurso.Data;
using BlazorCurso.Interfaces;
using BlazorCurso.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Servicios
{
    public class CursoServices: ICursosServices
    {
        private ICursosRepositorio cursosRepositorio;
        private SqlConfiguracion configuration;

        public CursoServices(SqlConfiguracion config)
        {
            configuration = config;
            cursosRepositorio = new CursosRepositorio(configuration.ConnectionString);
        }
        public Task<bool> setCurso(Curso curso)
        {
            if (curso.Id == 0)
                return cursosRepositorio.createCurso(curso);
            else
                return cursosRepositorio.setCurso(curso);
        }

        public Task<IEnumerable<Curso>> getAllCursos()
        {
            return cursosRepositorio.getAllCursos();
        }

        public Task<Curso> getCurso(int id)
        {
            return cursosRepositorio.getCurso(id);
        }

        public Task<bool> delCurso(int id)
        {
            return cursosRepositorio.delCurso(id);
        }

        public Task<IEnumerable<Curso>> getCursosSearch(string search)
        {
            return cursosRepositorio.getCursosSearch(search);
        }

    }
}
