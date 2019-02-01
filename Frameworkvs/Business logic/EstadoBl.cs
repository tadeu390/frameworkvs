using Dal.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic
{
    public class EstadoBl
    {
        EstadoRepository EstadoRepo;
        public EstadoBl()
        {
            EstadoRepo = new EstadoRepository();
        }

        public void cadastra()
        {
            Estado Estado = new Estado();
            Estado.Nome = "Minas Gerais";
            Estado.Abreviacao = "MG";
            Estado.DataRegistro = DateTime.Now;

            EstadoRepo.Adicionar(Estado);
        }
    }
}
