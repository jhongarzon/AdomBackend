using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class MessageValidator
    {
        public static string typePatientRequired { get; set; } = "El tipo de paciente es requerido";

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
        public static string NamePlanRateRequired { get; set; } = "El nombre del plan y tarifa es requerido";
        public static string EntityIdEntityRequired { get; set; } = "La entidad es requerida";
        public static string ServiceRequired { get; set; } = "El servicio es requerido";
        public static string RateRequired { get; set; } = "La tarifa es requerida";
        public static string ValidityRequired { get; set; } = "La vigencia es requerido";
        public static string NameCoPaymentFrecuencyRequired { get; set; } = "El nombre es requerido";
        public static string NameServiceFrecuencyRequired { get; set; } = "El nombre es requerido";
        public static string AuthorizationNumberAssignServiceRequired { get; set; } = "El número de autorización es requerido";
        public static string ValidityAssignServiceRequired { get; set; } = "La vigencia es requerida";
        public static string ApplicantNameAssignServiceRequired { get; set; } = "El nombre del solicitante es requerido";
        public static string ServiceIdAssignServiceRequired { get; set; } = "El servicio es requerido";
        public static string QuantityAssignServiceRequired { get; set; } = "La cantidad es requerida";
        public static string InitialDateAssignServiceRequired { get; set; } = "La fecha de inicio es requerida";
        public static string FinalDateAssignServiceRequired { get; set; } = "La fecha final es requerida";
        public static string ServiceFrecuencyIdAssignServiceRequired { get; set; } = "La frecuencia del servicio es requerido";
        public static string ProfessionalIdAssignServiceRequired { get; set; } = "El profesional es requerido";
        public static string CoPaymentAmountAssignServiceRequired { get; set; } = "El valor de copago es requerido";
        public static string ConsultationAssignServiceRequired { get; set; } = "La consulta es requerida";
        public static string ExternalAssignServiceRequired { get; set; } = "El externo es requerido";
        public static string ContractAssignServiceRequired { get; set; } = "El numero de contrato es requerido";
        public static string Cie10AssignServiceRequired { get; set; } = "El cie10 es requerido";
        public static string EntityAssignServiceRequired { get; set; } = "La entidad es requerida";
        public static string PlanAssignServiceRequired { get; set; } = "El plan es requerido";
        public static string ServiceAssignServiceRequired { get; set; } = "El servicio es requerido";
        public static string IdDetailAssignServiceDetailRequired { get; set; } = "El id detalle es requerido";
        public static string IdAssignServiceDetailRequired { get; set; } = "El id es requerido";
        public static string ConsecutiveAssignServiceDetailRequired { get; set; } = "El consecutivo es requerido";
        public static string DateVisitAssignServiceDetailRequired { get; set; } = "La fecha de vigencia es requerido";
        public static string ProfessionalIdAssignServiceDetailRequired { get; set; } = "El profesional es requerido";
        public static string IdSupplyAssignServiceSupplyRequired { get; set; } = "El id de insumo es requerido";
        public static string IdAssignServiceSupplyRequired { get; set; } = "El insumo es requerido";
        public static string BilledIdAssignServiceSupplyRequired { get; set; } = "El facturado a es requerido";
        public static string QuantityAssignServiceSupplyRequired { get; set; } = "La cantidad es requerido";
        public static string SupplyIdAssignServiceSupplyRequired { get; set; } = "El insumo es requerido";
        public static string IdSuAssignServiceSupplyRequired { get; set; } = "El id es requerido";

        public static string NoticeTittleRequired { get; set; } = "El titulo del anuncio es requerido";
        public static string NoticeTextRequired { get; set; } = "El cuerpo del anuncio es requerido";
    }
}
