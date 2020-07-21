using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class OpcoesBase : Attribute
    {
        private int max = 1;

        public bool ChavePrimaria { get; set; }
        public bool UsarBancoDados { get; set; }
        public bool UsarParaBuscar { get; set; }
        public bool AutoIncrementa { get; set; }
        public bool ChaveUnica { get; set; }
        public string NomeTabela { get; set; }
        public int Max
        {
            get { return max; }
            set { max = value; }
        }
        public int Min { get { return 1; } }
    }
}
