namespace AdAgency.Models
{
    public class OrderRequest
    {
        public int RequestId { get; set; }
        public string RequestStatus { get; set; }
        public string ClientMessage { get; set; }
        public DateTime RequestDate { get; set; }

    }
}
