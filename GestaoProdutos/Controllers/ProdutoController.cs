using Aplicacao.Interfaces;
using Dominio.DTO;
using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Notificacoes;
using GestaoProdutos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoProdutos.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IAplicacaoProduto _IAplicacaoProduto;
        public ProdutoController(IAplicacaoProduto IAplicacaoProduto) 
        {
            _IAplicacaoProduto = IAplicacaoProduto;
        }



        //[Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaProduto")]
        public async Task<List<Notificacao>> AdicionarProduto(Produto produto)
        { 

            List<Notificacao> lstRetorno = await _IAplicacaoProduto.Adicionar(produto);
            return lstRetorno;

        }

        //[Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AtualizarProduto")]
        public async Task<List<Notificacao>> AtualizarProduto(Produto produto)
        {

            List<Notificacao> lstRetorno = await _IAplicacaoProduto.Atualizar(produto);
            return lstRetorno;
        }

            // [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/RecuperarProduto")]
        public async Task<Produto> RecuperarProduto(int codigoProduto)
        {
            var produto = await _IAplicacaoProduto.BuscarPorId(codigoProduto);
                
            return produto;
        }

        // [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListarProduto")]
        public async Task<Paginado<Produto> > ListarProduto(int pagina, int? situacao, string descricao, int? codigoFornecedor )
        {
            var lst = await _IAplicacaoProduto.ListarProdutoPaginado(pagina, situacao, descricao, codigoFornecedor);

            return lst;
        }


        //[Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ExcluirProduto")]
        public async Task<string> ExcluirProduto(int codigoProduto)
        {


            await _IAplicacaoProduto.ExcluirLogico(codigoProduto);

            return "Ok";

        }



    }
}
