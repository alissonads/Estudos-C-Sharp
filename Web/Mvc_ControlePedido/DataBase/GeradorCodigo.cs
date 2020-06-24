using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public sealed class GeradorCodigo
    {
        private string ultimoCodigo;

        public GeradorCodigo(string ultimoCodigo)
        {
            this.ultimoCodigo = ultimoCodigo;
        }

        public string Gerar(int digitos)
        {
            string res = ultimoCodigo.Substring(ultimoCodigo.LastIndexOf('0') + 1);
            res = (int.Parse(res) + 1).ToString();
            
            return Repeat('0', digitos - res.Length) + res;
        }

        private string Repeat(char c, int r)
        {
            string res = "";
            for (int i = 0; i < r; i++)
                res += c;
            return res;
        }
    }
}
