using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestrutura.Notificacoes
{
    public class Notificacao
    {

        public Notificacao()
        {
        }

         
        public string Propriedade { get; set; } 
        public string Mensagem { get; set; } 


        public static Notificacao ValidarPropriedadeTexto(string valor, string propriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(propriedade))
            {
                return new Notificacao
                {
                    Mensagem = "Campo Obrigatório.",
                    Propriedade = propriedade
                };
            }
            return null;
        }


        public static Notificacao ValidarPropriedadeDecimal(decimal valor, string propriedade)
        {
            if (valor<1 || string.IsNullOrWhiteSpace(propriedade))
            {
                return new Notificacao
                {
                    Mensagem = "Valor deve ser maior que 0.",
                    Propriedade = propriedade
                };
            }
            return null;
        }


    }






}
