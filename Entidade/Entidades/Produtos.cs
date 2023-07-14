
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entidades.Entidades
{
    [Table("PRODUTO")]
    public class Produto 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CODIGO_PRODUTO")]
        public int CodigoProduto { get; set; }
        [Required]
        [Column ("DESCRICAO")]
        public string Descricao { get; set; }            
        [Column ("SITUACAO")]
        public int? Situacao { get; set; }       
        [Column("DATA_FABRICACAO")]
        public DateTime? DataFabricacao { get; set; }
        [Column("DATA_VALIDADE")]
        public DateTime? DataValidade { get; set; }

        [ForeignKey("Fornecedor"), Column("CODIGO_FORNECEDOR")]
        public int? CodigoFornecedor { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }

    }
}
