using System.ComponentModel.DataAnnotations;

namespace AdvAgency.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Укажите email")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
