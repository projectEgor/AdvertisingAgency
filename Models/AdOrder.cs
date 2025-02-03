namespace AdAgency.Models
{
    public class AdOrder
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderInfo { get; set; }
        public string OrderStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClientId { get; set; }
        public User Client { get; set; }
    }
}
