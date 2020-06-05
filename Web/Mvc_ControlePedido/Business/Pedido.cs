using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Business
{
    public class Pedido : Base
    {
        private Empresa cliente;
        private List<IBase> itens;

        [OpcoesBase(ChavePrimaria = true, UsarParaBuscar = true)]
        public string Cd_pedido { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public DateTime Dt_pedido { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Cd_cliente { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public decimal Valor_total { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public DateTime Dt_entrega { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public DateTime Dt_liberacao { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Situacao { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public int Total_itens { get; set; }
        public Empresa Cliente
        {
            get
            {
                if (cliente == null && !string.IsNullOrEmpty(Cd_cliente))
                {
                    cliente = new Empresa(Cd_cliente);
                    cliente.Buscar();
                }

                return cliente;
            }
        }
        public List<IBase> Itens
        {
            get
            {
                if (itens == null && string.IsNullOrEmpty(Cd_pedido))
                    itens = new List<IBase>();
                else if (itens == null)
                    itens = (new ItemPedido(Cd_pedido)).Buscar();

                return itens;
            }
        }

        public Pedido() { }

        public Pedido(string codigo)
        {
            Cd_pedido = codigo;
        }
    }
}
