namespace EZTix.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int NumTicketsOrdered { get; set; }
        public string CustFirstName { get; set; } = string.Empty;
        public string CustLastName { get; set; }= string.Empty;
        public string CustEmail { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CreditCardType { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        // foreign key 
        public int ShowId { get; set; }
        //Navigation property
        public Show? Show { get; set; }
     
    }
}
