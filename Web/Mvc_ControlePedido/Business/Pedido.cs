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

        [OpcoesBase(ChavePrimaria = true, UsarParaBuscar = true, 
                    UsarBancoDados = true, Max = 7)]
        public string Cd_pedido { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public DateTime Dt_pedido { get; set; }
        [OpcoesBase(UsarBancoDados = true, UsarParaBuscar = true)]
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
                    cliente.Atualizar();
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

        public static List<Pedido> Todos()
        {
            var aux = (new Pedido()).BuscarTodos();

            if (aux.Count < 0) return null;

            var pedidos = new List<Pedido>();

            foreach (var item in aux)
            {
                pedidos.Add((Pedido)item);
            }

            return pedidos;

            //return (new GerenciadorDeDados<Pedido>()).Buscar();
        }

        public static List<Pedido> BuscarPorCliente(string cd_cliente)
        {
            var pedido = new Pedido() { Cd_cliente = cd_cliente };
            var aux = pedido.Buscar();

            if (aux.Count < 0) return null;

            var pedidos = new List<Pedido>();

            foreach (var item in aux)
            {
                pedidos.Add((Pedido)item);
            }

            return pedidos;
        }
    }
}
