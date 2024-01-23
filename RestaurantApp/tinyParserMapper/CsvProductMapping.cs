using RestaurantApp.BL.DTOs.Items;
using TinyCsvParser.Mapping;

namespace RestaurantApp.APIs.tinyParserMapper;

public class CsvProductMapping : CsvMapping<ItemAddDto>
{
    public CsvProductMapping() : base()
    {
        MapProperty(0, x => x.name);
        MapProperty(1, x => x.Description);
        MapProperty(2, x => x.brandId);
        MapProperty(3, x => x.QuantityInInventory);
        MapProperty(4, x => x.price);
    }
}
