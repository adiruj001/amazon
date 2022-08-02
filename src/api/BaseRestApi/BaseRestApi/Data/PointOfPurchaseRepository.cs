using BaseRestApi.Data.Interface;
using BaseRestApi.DTO;

namespace BaseRestApi.Data
{
    public class PointOfPurchaseRepository : IPointOfPurchaseRepository
    {
        private BaseRestApiContext Context { get; }

        public PointOfPurchaseRepository(BaseRestApiContext Context)
        {
            this.Context = Context;
        }

        public List<PointOfPurchaseDto> GetPointOfPurchase()
        {
            List<PointOfPurchaseDto> pointOfPurchasesLis = Context.PointOfPurchases
                .Select((p) =>
                    new PointOfPurchaseDto
                    {
                        ID = p.ID,
                        Name = p.Name,
                        Address = p.Address,
                        Status = p.Status
                    }
                ).ToList();
            return pointOfPurchasesLis;
        }

        // public List<PointOfPurchaseDto> GetPointOfPurchases()
        // {
        //     throw new NotImplementedException();
        // }
    }
}