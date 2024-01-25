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

        private int puntiFatti;
        public string Nome { get => nome; set => nome = value; }
        public int PuntiFatti { get => puntiFatti; set => puntiFatti = value; }

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
