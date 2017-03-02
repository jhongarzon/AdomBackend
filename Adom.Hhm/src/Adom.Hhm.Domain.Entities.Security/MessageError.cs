using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class MessageError
    {
        public static string UserInsert = "Error al guardar el usuario";
        public static string UserUpdate = "Error al guardar el usuario";
        public static string EmailExists = "El correo electrónico ya existe";
        public static string RoleInsert = "Error al guardar el rol";
        public static string NameRoleExists = "El nombre del rol ya existe";
        public static string RoleUpdate = "Error al guardar el usuario";
        public static string InvalidCredentials = "La credenciales son inválidas";
        public static string UserNotExist = "El usuario no existe o no está activo";
    }
}
