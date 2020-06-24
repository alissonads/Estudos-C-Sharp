using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Business
{
    public class Empresa : Base
    {
        [OpcoesBase(ChavePrimaria = true, UsarBancoDados = true, 
                    UsarParaBuscar = true, Max = 7)]
        public string Cd_empresa { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Cnpj { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Nome { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Contato { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Fantasia { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Fone { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Email { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Endereco { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Bairro { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Municipio { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Uf { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public int Cep { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Numero { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public int Ativo { get; set; }

        public Empresa() {}

        public Empresa(string codigo)
        {
            Cd_empresa = codigo;
        }

        public static List<Empresa> Todos()
        {
            var aux = (new Empresa()).BuscarTodos();

            if (aux.Count < 0) return null;

            var pedidos = new List<Empresa>();

            foreach (var item in aux)
            {
                pedidos.Add((Empresa)item);
            }

            return pedidos;
        }
    }
}
