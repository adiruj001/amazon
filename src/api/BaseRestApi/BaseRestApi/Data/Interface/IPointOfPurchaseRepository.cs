using BaseRestApi.DTO;

namespace BaseRestApi.Data.Interface
{
    public interface IPointOfPurchaseRepository
    {
        List<PointOfPurchaseDto> GetPointOfPurchases();
    }
}