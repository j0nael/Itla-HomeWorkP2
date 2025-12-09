using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tallermecanico.infretruture.Model;

public class SaleModel
{
    [Key]
    public int SaleId { get; set; }

    // FK: Una venta pertenece a un cliente
    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual CustomerModel Customer { get; set; }

    // FK: Una venta es realizada por un vendedor
    [Required]
    public int SellerId { get; set; }

    [ForeignKey(nameof(SellerId))]
    public virtual SellerModel Seller { get; set; }

    // FK: Una venta puede estar en una factura (opcional)
    public int? InvoiceId { get; set; }

    [ForeignKey(nameof(InvoiceId))]
    public virtual InvoiceModel Invoice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    // Navegación: Una venta tiene múltiples detalles
    public virtual ICollection<SaleDetailModel> SaleDetails { get; set; } = new List<SaleDetailModel>();

    public SaleModel() { }

    public SaleModel(int customerId, int sellerId)
    {
        CustomerId = customerId;
        SellerId = sellerId;
    }
}