
using Entidades.Entidades;
using Entidades.Enuns;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioProduto : RepositorioGenerico<Produto>
    {
        private readonly DbContextOptions<Contexto> _optionsbuilder;
        public RepositorioProduto()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }

        public async Task ExcluirLogico(int id)
        {  
            using (var data = new Contexto(_optionsbuilder))
            {
                var obj = await data.Produto.FindAsync(id);
                obj.Situacao = 0;
                await data.SaveChangesAsync();
            }
        }

        public  int RecuperarTotal(int? situacao, string? descricao, int? codigoFornecedor)
        {
            using (var data = new Contexto(_optionsbuilder))
            {
                return data.Produto.Where(t =>  
                    (!situacao.HasValue || situacao.Value == t.Situacao) &&
                    (descricao == null || t.Descricao.Contains(descricao)) &&
                    (!codigoFornecedor.HasValue || codigoFornecedor.Value == t.CodigoFornecedor)
                ).Count();
            }
        }

        public  List<Produto> ListarPaginado(int inicio, int tamanhoPagina,  int? situacao, string? descricao, int? codigoFornecedor)
        {
                using (var data = new Contexto(_optionsbuilder))
                {
                 return data.Produto.Where(t =>
                    (!situacao.HasValue || situacao.Value == t.Situacao) &&
                    (descricao == null || t.Descricao.Contains(descricao)) &&
                    (!codigoFornecedor.HasValue || codigoFornecedor.Value == t.CodigoFornecedor)
                    ).OrderBy(t => t.CodigoProduto).Skip(inicio).Take(tamanhoPagina).ToList();
                }
            }

        /*
        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var banco = new Contexto(_optionsbuilder))
            {
                return await banco.Produto.Where(exProduto).AsNoTracking().ToListAsync();
            }
        }
        */

    }
}
