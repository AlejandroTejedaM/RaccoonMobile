using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaccoonMobile.Models;

namespace RaccoonMobile.Services
{
    public interface IUsuarioServicio
    {
        Usuario IniciarSesion(String email, String password);
        bool RegistrarUsuario(Usuario usuario);
    }
}