using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class MessageValidator
    {
        public static string GenderRequired { get; set; } = "El género es requerido";

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
        public static string DocumentTypeIdRequired { get; set; } = "El tipo de documento es requerido";
        public static string DocumentRequired { get; set; } = "El documento es requerido";
        public static string SpecialtyRequired { get; set; } = "La especialidad es requerido";
        public static string Telephone1Required { get; set; } = "El celular es requerido";
        public static string BankRequired { get; set; } = "El banco es requerido";
        public static string AccountRequired { get; set; } = "La cuenta es requerida";
        public static string AccountTypeRequired { get; set; } = "El tipo de cuenta es requerido";
        public static string BirthDateRequired { get; set; } = "La fecha de nacimiento es requerido";
        public static string NameEntityRequired { get; set; } = "El nombre de la entidad es requerido";
        public static string BusinessEntityRequired { get; set; } = "La razón social es requerido";
        public static string CodeEntityRequired { get; set; } = "El código es requerido";
        public static string NitEntityRequired { get; set; } = "El nit es requerido";
        public static string NameSupplyRequired { get; set; } = "El nombre del insumo es requerido";
        public static string PresentationSupplyRequired { get; set; } = "La presentación del insumo es requerido";
        public static string CodeSupplyRequired { get; set; } = "El código del insumo es requerido";
        public static string NameServiceRequired { get; set; } = "El nombre del servicio es requerido";
        public static string ValueServiceRequired { get; set; } = "El valor del servicio es requerido";
        public static string ValueGreaterServiceRequired { get; set; } = "El valor del servicio debe ser mayor a 0";
        public static string CodeServiceRequired { get; set; } = "El código del s eervicios requerido";
        public static string ClassificationServiceRequired { get; set; } = "La clasificación del servicio es requerido";
        public static string ServiceTypeServiceRequired { get; set; } = "El tipo de servicio es requerido";
    }
}
