namespace P01_BillsPaymentSystem.Data.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class NonUnicodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessages.nullValue);
            }

            string text = (string)value;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > 255)
                {
                    return new ValidationResult(ErrorMessages.unicodeError);
                }
            }

            return ValidationResult.Success;
        }
    }
}