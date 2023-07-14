using System;
using System.ComponentModel.DataAnnotations.Schema;


public class Notifica
{
	public Notifica()
	{
        [NotMapped]
        public string Propriedade { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }

}
}
