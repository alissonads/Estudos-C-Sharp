using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IBase
    {
        string Key { get; }
        void Atualizar();
        void Excluir();
        void Salvar();
        List<IBase> BuscarTodos();
        List<IBase> Buscar();
    }
}
