using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.Data.Enums
{
    public class EnumMessage
    {
        public enum ValidationStatus
        {
         All,
         Name,
         LastName,
         IdentityNumber,
         Phone,
         Email,   
         Description ,
         Stock,
         Illness,
         Diagnosis,
         Policlinic,
         Personell,
         Title,
         Departman,
         Success,
         Update,
         Invalid,
         Delete,
         AreYouSure,
         Dublicate,

        }

        public static string GetMessageEn(ValidationStatus status)
        {
            return status switch
            {
                ValidationStatus.All => "Columns cannot be left empty",
                ValidationStatus.Name => "Name field cannot be left empty",
                ValidationStatus.LastName => "Last Name field cannot be left empty",
                ValidationStatus.IdentityNumber => "Identity Number field cannot be left empty",
                ValidationStatus.Phone => "Phone field cannot be left empty",
                ValidationStatus.Email => "Email field cannot be left empty",
                ValidationStatus.Description => "Description field cannot be left empty",
                ValidationStatus.Stock => "Stock field cannot be left empty",
                ValidationStatus.Illness => "Illness field cannot be left empty",
                ValidationStatus.Diagnosis => "Diagnosis field cannot be left empty",
                ValidationStatus.Policlinic => "Policlinic field cannot be left empty",
                ValidationStatus.Personell => "Personell field cannot be left empty",
                ValidationStatus.Title => "Title field cannot be left empty",
                ValidationStatus.Departman => "Departman field cannot be left empty",
                ValidationStatus.Success => "Registration successful",
                ValidationStatus.Update => "Update operation successful",
                ValidationStatus.Invalid => "You have entered an invalid value.",
                ValidationStatus.Delete => "Record Is Deleted",
                ValidationStatus.AreYouSure => "Are you sure you want to delete ?",
                ValidationStatus.Dublicate => "This Identity Number already used",
                _ => "Unknown status"
            }; 
        }

       
    
    }
}
