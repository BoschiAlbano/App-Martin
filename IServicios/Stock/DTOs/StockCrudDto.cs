using IServicio.BaseDto;

namespace IServicios.Stock.DTOs
{
    public class StockCrudDto : DtoBase
    {
        // Propiedades
        public long ArticuloId { get; set; }

        public long DepositoId { get; set; }

        public decimal Cantidad { get; set; }
    }
}
