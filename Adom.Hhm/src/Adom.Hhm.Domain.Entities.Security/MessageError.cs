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
        public static string DocumentExists = "El documento ya existe.";
        public static string NameEntityExists = "El nombre de la entidad ya existe.";
        public static string NameSupplyExists = "El nombre del insumo ya existe.";
        public static string NameServiceExists = "El nombre del servicio ya existe.";
        public static string NameCoPaymentFrecuencyExists = "La frecuencia del copago ya existe.";

        public static string NameServiceFrecuencyExists = "La frecuencia del servicio ya existe.";

        public static string NamePlanRateExists = "El plan y tarifa ya existe.";

        public static string NamePlanEntityExists = "El nombre del plan ya existe.";
        public static string UserDisabled = "El usuario está inactivo";
    }
}
