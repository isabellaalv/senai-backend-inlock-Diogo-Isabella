using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.ViewModels
{
    public class JogosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public double Valor { get; set; }
        public Estudio Estudio { get; set; }

        public JogosViewModel()
        {

        }
    }
}
