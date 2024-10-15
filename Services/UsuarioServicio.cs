using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaccoonMobile.Models;

namespace RaccoonMobile.Services
{
    public class UsuarioServicio : IUsuarioServicio
    {
        List<Usuario> usuarios;

        public UsuarioServicio()
        {
            usuarios = new List<Usuario>();
        }
        public Usuario IniciarSesion(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}