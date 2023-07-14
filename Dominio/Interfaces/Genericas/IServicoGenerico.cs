using Infraestrutura.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Genericas
{
    public interface IServicoGenerico<T> where T : class
    {

        Task<List<Notificacao>> Adicionar(T Objeto);
        Task<List<Notificacao>> Atualizar(T Objeto);
        Task Excluir(int id);
        Task<T> BuscarPorId(int id );
        Task <List<T>> ListarTodos();

    }
}
