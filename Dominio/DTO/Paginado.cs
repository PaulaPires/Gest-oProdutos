using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class Paginado<T>
    {


        public Paginado() { }
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; } = 0;
        public int RegistroPorPagina { get; set; } = 100;

        public int TotalPaginas
        {
            get { return (int)Math.Ceiling(Convert.ToDouble(TotalRegistros) / RegistroPorPagina); }
        }

        public int GetSkip()
        {
            return (int)(Pagina) * RegistroPorPagina;
        }

        public List<T> Dados { get; set; }
    }
}
