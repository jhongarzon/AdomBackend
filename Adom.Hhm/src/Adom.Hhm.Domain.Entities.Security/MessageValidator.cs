using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class MessageValidator
    {

        public static string EmailRequired { get; set; } = "El email es requerido";
        public static string FirstNameRequired { get; set; } = "El primer nombre es requerido";
        public static string NameRoleRequired { get; set; } = "El nombre del rol es requerido";
        public static string PasswordRequired { get; set; } = "El password es requerido";
        public static string SurnameRequired { get; set; } = "El primer apellido es requerido";
        public static string UserIdRequired { get; set; } = "El id del usuario es requerido";
        public static string ActionIdRequired { get; set; } = "El id de la acción es requerida";
        public static string ResourceIdRequired { get; set; } = "El id del recurso es requerido";
        public static string RoleIdRequired { get; set; } = "El id del rol es requerido";
        public static string HasRoleIdRequired { get; set; } = "La bandera del rol es requerido";
    }
}
