using BaseRestApi.DTO;
using System.Collections.Generic;

namespace BaseRestApi.Services.Interface
{
    public interface IPointOfPurchaseService
    {
        Result<List<PointOfPurchaseDto>> GetPointOfPurchase();
    }
}