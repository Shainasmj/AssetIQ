namespace AssetIQ.Models.Domain
{
    public class Asset
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal Price { get; set; }

        public bool IsAssigned { get; set; }
    }
}