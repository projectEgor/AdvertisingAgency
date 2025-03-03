using System;
using System.ComponentModel.DataAnnotations;

namespace AdvAgency.ViewModels
{
    public class NewOrderViewModel
    {
        [Required(ErrorMessage = "Выберите категорию рекламы")]
        [Display(Name = "Категория рекламы")]
        public int AdvertCategoryId { get; set; }

        [Required(ErrorMessage = "Описание обязательно")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Дата начала обязательна")]
        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Дата окончания обязательна")]
        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
} 