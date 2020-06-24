using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class OpcoesBase : Attribute
    {
        public bool ChavePrimaria { get; set; }
        public bool UsarBancoDados { get; set; }
        public bool UsarParaBuscar { get; set; }
        public bool AutoIncrementa { get; set; }
        public string NomeTabela { get; set; }
        public int Max { get; set; }
        public int Min { get { return 1; } }
    }
}
