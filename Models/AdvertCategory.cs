using System.ComponentModel.DataAnnotations;

namespace AdvAgency.Models
{
    public class AdvertCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
    }
} 