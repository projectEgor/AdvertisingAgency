using System.ComponentModel.DataAnnotations;

namespace AdvAgency.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Имя пользователя обязательно")]
        public string UserName { get; set; }
    }
} 