using Dominio.DTO;
using Dominio.Interfaces.Genericas;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfacesServicos
{
    public interface IServicoProduto : IServicoGenerico<Produto>
    {
        Task ExcluirLogico(int id);
        Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProdutos);
        Task<Paginado<Produto> > ListarProdutoPaginado(int pagina, int? situacao, string descricao, int? codigoFornecedor);


    }
}
