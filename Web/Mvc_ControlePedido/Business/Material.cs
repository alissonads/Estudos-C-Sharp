using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Business
{
    [OpcoesBase(NomeTabela = "Materiais")]
    public class Material : Base
    {
        [OpcoesBase(ChavePrimaria = true, UsarParaBuscar = true, 
                    UsarBancoDados = true, Max = 10)]
        public string Cd_material { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Descricao { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Unidade_medida { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public decimal Valor_unitario { get; set; }

        public Material() { }

        public Material(string codigo)
        {
            Cd_material = codigo;
        }

        public static List<Material> Todos()
        {
            //var aux = (new Material()).BuscarTodos();

            //if (aux.Count < 0) return null;

            //var materiais = new List<Material>();

            //foreach (var item in aux)
            //{
            //    materiais.Add((Material)item);
            //}

            //return materiais;

            return new GerenciadorDeDados<Material>().Buscar();
        }
    }
}
