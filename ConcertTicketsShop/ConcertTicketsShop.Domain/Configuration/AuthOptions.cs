namespace ConcertTicketsShop.Domain.Configuration
{
    public class AuthOptions
    {
        public string EncryptionKey { get; set; }
        public string Issuer { get; set; }
        public int TokenLifetimeInDays { get; set; }
    }
}
