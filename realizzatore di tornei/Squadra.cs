using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realizzatore_di_tornei
{
    public class Squadra
    {
        String nome;
        int nMembri;
        public string Nome { get => nome; set => nome = value; }
        public int NMembri { get => nMembri; set => nMembri = value; }

        public Squadra(string nome, int nMembri)
        {
            this.nome = nome;
            this.nMembri = nMembri;
        }

    }
}
