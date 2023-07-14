using Dominio.DTO;
using Dominio.Interfaces.Genericas;
using Dominio.Interfaces.InterfacesServicos;
using Entidades.Entidades;
using Infraestrutura.Notificacoes;
using Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoProduto : IServicoProduto
    {

        private readonly RepositorioProduto repositorio;

        public ServicoProduto(RepositorioProduto IProduto)
        {
            repositorio = IProduto;
        }


        public async Task<List<Notificacao>> Adicionar(Produto produto)
        {
            List<Notificacao> retorno = new List<Notificacao> { };

            if (produto.Descricao == null)
            {
                retorno.Add(new Notificacao() {Mensagem = "Campo obrigatório", Propriedade="Descricao" }); 
            }

            if (produto.DataValidade != null  && produto.DataFabricacao != null &&
                produto.DataFabricacao>produto.DataValidade)
            {
                retorno.Add(new Notificacao() { Mensagem = "Data de fabricação não pode ser maior que data de validade", Propriedade = "Fabricação" });
            }


            if (retorno.Count== 0)
            {
                await repositorio.Adicionar(produto);
                return retorno;
            }
            else{
                return retorno;
            }
            
        }
        public async Task<List<Notificacao>> Atualizar(Produto produto)
        {
            List<Notificacao> retorno = new List<Notificacao> { };

            if (produto.Descricao == null)
            {
                retorno.Add(new Notificacao() { Mensagem = "Campo obrigatório", Propriedade = "Descricao" });
            }

            if (produto.DataValidade != null && produto.DataFabricacao != null &&
                produto.DataFabricacao > produto.DataValidade)
            {
                retorno.Add(new Notificacao() { Mensagem = "Data de fabricação não pode ser maior que data de validade", Propriedade = "Fabricação" });
            }


            if (retorno.Count == 0)
            {
                await repositorio.Atualizar(produto);

                return retorno;
            }
            else
            {
                return retorno;
            }

        }

        public async Task<List<Produto>> ListaProduto()
        {
           return await repositorio.ListarTodos();

        }


        public async Task<Produto> BuscarPorId(int id)
        {
            return await repositorio.BuscarPorId(id);
        }

        public Task Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task ExcluirLogico(int id)
        {
            repositorio.ExcluirLogico(id);
        }

        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProdutos)
        {
            throw new NotImplementedException();
        }

        public async Task<Paginado<Produto>> ListarProdutoPaginado(int pagina, int? situacao, string descricao, int? codigoFornecedor)
        {

            int total = repositorio.RecuperarTotal(situacao, descricao, codigoFornecedor);

            Paginado<Produto>   paginado = new Paginado<Produto>();

            paginado.RegistroPorPagina = 5;
            paginado.Pagina = pagina;
            paginado.TotalRegistros = total;
            paginado.Dados = repositorio.ListarPaginado(paginado.GetSkip(), paginado.RegistroPorPagina, situacao, descricao, codigoFornecedor);
            
            return paginado;
        }

        public async Task<List<Produto>>  ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
