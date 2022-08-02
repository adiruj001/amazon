using BaseRestApi.Data.Interface;
using BaseRestApi.DTO;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseRestApi.Services
{
    public class PointOfPurchaseService : IPointOfPurchaseService
    {
        private AppSettings AppSettings { get; }
        private ITrace Trace { get; }
        private ILogger<PointOfPurchaseService> Logger { get; }
        private IPointOfPurchaseRepository PointOfPurchaseRepository { get; }

        public PointOfPurchaseService(IOptions<AppSettings> appSettingsAccessor, ITrace trace, ILogger<PointOfPurchaseService> logger, IPointOfPurchaseRepository PointOfPurchaseRepository)
        {
            this.AppSettings = appSettingsAccessor.Value;
            this.Trace = trace;
            this.Logger = logger;
            this.PointOfPurchaseRepository = PointOfPurchaseRepository;
        }

        public Result<List<PointOfPurchaseDto>> GetPointOfPurchase()
        {
            Result<List<PointOfPurchaseDto>> result = new Result<List<PointOfPurchaseDto>>(Trace);
            List<PointOfPurchaseDto> createResult = PointOfPurchaseRepository.GetPointOfPurchase();
            result.Success = true;
            result.Message = AppSettings.SuccessMessage.GetSuccess;
            result.Data = createResult;
            return result;
        }
    }
}