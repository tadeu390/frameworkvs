using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model
{
    public class Endereco
    {
        public int ID { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Ativo { get; set; }
        public int EstadoID { get; set; }
        public int UsuarioID { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}