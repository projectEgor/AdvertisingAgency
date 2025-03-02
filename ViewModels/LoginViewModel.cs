using System.ComponentModel.DataAnnotations;

namespace AdvAgency.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите email")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

    }
}
