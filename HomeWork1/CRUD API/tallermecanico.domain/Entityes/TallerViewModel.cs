namespace tallermecanico.domain.Entityes
{
    public class TallerViewModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();
        public List<SparePart> SpareParts { get; set; } = new List<SparePart>();
    }
}
