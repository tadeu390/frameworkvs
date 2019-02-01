using Dal.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic
{
    public class UsuarioBl
    {
        private UsuarioRepository UserRepo;
        public UsuarioBl()
        {
            UserRepo = new UsuarioRepository();
        }
    }
}
