using System.ComponentModel.DataAnnotations;

namespace AdvAgency.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Укажите email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Пароль должен содержать от {1} до {0} символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Пароли не совпадают")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Подтвердите новый пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение нового пароля")]
        public string ConfirmNewPassword { get; set; }
    }
}
