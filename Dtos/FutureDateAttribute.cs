using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos
{
    public class FutureDateAttribute : ValidationAttribute
    {
        // Check that the date is not in the past
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date <= DateTime.Now)
                {
                    return new ValidationResult("Date must be in the future.");
                }
            }
            return ValidationResult.Success;
        }
    }
}