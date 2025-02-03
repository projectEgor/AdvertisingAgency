namespace AdAgency.Models
{
    public class OrderRequest
    {
        public int RequestId { get; set; }
        public string RequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public int ClientId { get; set; }

    }
}
