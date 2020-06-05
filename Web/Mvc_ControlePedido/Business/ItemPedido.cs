using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Business
{
    [OpcoesBase(NomeTabela = "Itens_Pedido")]
    public class ItemPedido : Base
    {
        private Material material;
        private Pedido pedido;

        [OpcoesBase(ChavePrimaria = true, AutoIncrementa = true)]
        public int Id { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public decimal Quantidade { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Situacao { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public decimal Valor_total { get; set; }
        [OpcoesBase(UsarBancoDados = true, UsarParaBuscar = true)]
        public string Cd_pedido { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Cd_material { get; set; }
        public Pedido Pedido
        {
            get
            {
                if (pedido == null && !string.IsNullOrEmpty(Cd_pedido))
                {
                    pedido = new Pedido(Cd_pedido);
                    pedido.Atualizar();
                }

                return pedido;
            }
        }
        public Material Material
        {
            get
            {
                if (material == null && !string.IsNullOrEmpty(Cd_material))
                {
                    material = new Material(Cd_material);
                    material.Atualizar();
                }

                return material;
            }

        }

        public ItemPedido() { }

        public ItemPedido(string codigoPedido)
        {
            Cd_pedido = codigoPedido;
        }
    }
}
