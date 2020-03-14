using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Domains
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        //OBS IMPORTANTE: Com tipo de variável do SQL "MONEY", código devera ser de tipo DECIMAL
        public decimal Valor { get; set; }
        public int EstudioId { get; set; }

        public Jogo()
        {

        }
    }
}
