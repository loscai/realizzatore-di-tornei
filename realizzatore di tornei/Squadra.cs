using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realizzatore_di_tornei
{
    public class Squadra
    {
        private String nome;
        public string Nome { get => nome; set => nome = value; }

        public Squadra(string nome)
        {
            this.nome = nome;
        }

        public override string ToString()
        {
            return nome;
        }

    }
}
