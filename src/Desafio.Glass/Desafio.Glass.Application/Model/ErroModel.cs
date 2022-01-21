using System;

namespace Desafio.Glass.Application.Model
{
    public class ErroModel
    {
        public string Tipo { get; set; }
        public string Mensagem { get; set; }
        public string StackTrace { get; set; }
        public ErroModel(Exception ex)
        {
            Tipo = ex?.GetType().Name;
            Mensagem = ex?.Message;
            StackTrace = ex?.ToString();
        }
    }
}
