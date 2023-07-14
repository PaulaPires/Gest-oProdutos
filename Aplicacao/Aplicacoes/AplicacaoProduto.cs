using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Genericas;
using Dominio.DTO;
using Dominio.Interfaces.InterfacesServicos;
using Entidades.Entidades;
using Infraestrutura.Notificacoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoProduto : IAplicacaoProduto
    {
        IServicoProduto servicoProduto;
        public AplicacaoProduto(IServicoProduto IProduto) 
        {
            servicoProduto = IProduto;

        }


        public async Task<List<Notificacao>> Adicionar(Produto Objeto)
        {
            return await servicoProduto.Adicionar(Objeto);
        }

        public async Task<List<Notificacao>> Atualizar(Produto Objeto)
        {
            return await servicoProduto.Atualizar(Objeto);
        }

        public async Task<Produto> BuscarPorId(int Id)
        {
            return await servicoProduto.BuscarPorId(Id);
        }

        public Task Excluir(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task ExcluirLogico(int id)
        {
            await servicoProduto.ExcluirLogico(id);
        }
        

        public async Task<List<Produto>> Listar()
        {
            return await servicoProduto.ListarTodos();
        }


        public async Task<Paginado<Produto>> ListarProdutoPaginado(int pagina, int? situacao, string descricao, int? codigoFornecedor)
        {
            return await servicoProduto.ListarProdutoPaginado(pagina, situacao, descricao, codigoFornecedor);
        }
         
    }
}
