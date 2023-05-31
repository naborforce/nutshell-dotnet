namespace Rosie.Nutshell.Types.Product;

public record NutshellPrice(string Currency, decimal Amount);

/*{
    "id": "1000",
    "entityType": "Products",
    "rev": "152",
    "name": "Mac Mini",
    "type": "0",                 // 0 = product, 1 = service
    "sku": "NS0012MM",           // present when type is product (0)
    "unit": "",                  // present when type is service (1)
    "prices": [ Product_Price, ... ]  // may only have one price per market
}*/
public class NutshellProduct
{
    public int Id { get; set; }
    public string EntityType { get; set; } = "Products";
    public string Rev { get; set; }= null!;
    public string Name { get; set; }= null!;
    public NutshellProductType Type { get; set; }
    public string Sku { get; set; } = null!;
    public string Unit { get; set; }= null!;
    public NutshellPrice[] Prices { get; set; } = Array.Empty<NutshellPrice>();
}