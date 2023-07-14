using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace GestaoProdutos.Models
{
    public class ProdutoModel
    {
        public int CodigoProduto { get; set; }
        public string Produtos { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
       
        public DateTime DataValidade { get; set; }
      
        public int CodigoFornecedor { get; set; }
       
        public string Fornecedor { get; set; }
       
        public string CNPJ { get; set; }

        
    }
}
