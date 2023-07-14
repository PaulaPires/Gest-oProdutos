using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("FORNECEDOR")]
    public class Fornecedor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CODIGO_FORNECEDOR")]
        public int CodigoFornecedor { get; set; }
        [Column("DESCRICAO")]
        public string? Descricao { get; set; }
        [Column("CNPJ")]
        public string? CNPJ { get; set; }
    }
}
