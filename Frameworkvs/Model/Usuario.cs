using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {
        public int ID { get; set; }
        public DateTime ? DataRegistro { get; set; }
        public bool Ativo { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string NomeDeUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Sexo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Senha> Senhas { get; set; }
    }
}
