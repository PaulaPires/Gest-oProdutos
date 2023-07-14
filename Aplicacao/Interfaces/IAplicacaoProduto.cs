using Aplicacao.Interfaces.Genericas;
using Dominio.DTO;
using Entidades.Entidades;
using Infraestrutura.Notificacoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoProduto : IGenericaAplicacao<Produto>
    {

        Task ExcluirLogico(int id);

        Task<Paginado<Produto>> ListarProdutoPaginado(int pagina, int? situacao, string descricao, int? codigoFornecedor);


    }

}
