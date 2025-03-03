using AdvAgency.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvAgency.Models
{
    public class AdOrder
    {
        
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("AdvertCategoryId")]
        public int AdvertCategoryId { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Сумма заказа")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
        
        [ForeignKey("AdvertCategoryId")]
        public virtual AdvertCategory AdvertCategory { get; set; }
    }
}