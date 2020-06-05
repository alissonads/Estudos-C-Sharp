using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Business
{
    public class Acesso : Base
    {
        private Empresa empresa;

        [OpcoesBase(AutoIncrementa = true)]
        public int Id { get; set; }
        [OpcoesBase(ChavePrimaria = true, UsarParaBuscar = true, UsarBancoDados = true)]
        public string Login { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Senha { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Nivel { get; set; }
        [OpcoesBase(UsarBancoDados = true)]
        public string Cd_empresa { get; set; }
        public Empresa Empresa
        {
            get
            {
                if (empresa == null && !string.IsNullOrEmpty(Cd_empresa))
                {
                    empresa = new Empresa(Cd_empresa);
                    empresa.Atualizar();
                }
                return empresa;
            }
        }

        public Acesso() { }

        public Acesso(string login)
        {
            Login = login;
        }

        public override void Excluir()
        {
            base.Excluir();
            Empresa.Excluir();
        }
    }
}
