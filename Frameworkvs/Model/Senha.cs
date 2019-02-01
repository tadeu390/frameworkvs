using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Senha
    {
        public int ID { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Ativo { get; set; }
        public int UsuarioID { get; set; }
        public string Valor { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
