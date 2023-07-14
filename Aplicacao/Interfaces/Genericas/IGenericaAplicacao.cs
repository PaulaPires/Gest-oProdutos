using Infraestrutura.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Genericas
{
    public interface IGenericaAplicacao<T> where T : class
    {
        Task<List<Notificacao>> Adicionar(T Objeto);
        Task<List<Notificacao>> Atualizar(T Objeto);
        Task Excluir(int Id);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> Listar();
    }
}
