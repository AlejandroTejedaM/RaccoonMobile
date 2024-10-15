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
            if (usuarios.Count == 0)
            {
                return null;
            }
            else
            {
                return usuarios.Find(u => u.Email == email && u.Password == password);
            }
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            if (usuarios.Any(u => u.Email == usuario.Email))
            {
                return false;
            }
            usuario.Id = usuarios.Count  + 1;
            usuarios.Add(usuario);
            return true;
        }

    }
}