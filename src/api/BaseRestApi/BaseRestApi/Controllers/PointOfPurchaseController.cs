using BaseRestApi.DTO;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BaseRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PointOfPurchaseController : ControllerBase
    {
        private IPointOfPurchaseService PointOfPurchaseService { get; }
        private ILogger<PointOfPurchaseController> Logger { get; }
        private AppSettings AppSettings { get; }
        private ITrace Trace { get; }

        public PointOfPurchaseController(IPointOfPurchaseService PointOfPurchaseService, ILogger<PointOfPurchaseController> Logger, IOptions<AppSettings> AppSettings, ITrace Trace)
        {
            this.PointOfPurchaseService = PointOfPurchaseService;
            this.Logger = Logger;
            this.AppSettings = AppSettings.Value;
            this.Trace = Trace;
        }

        [HttpGet]
        public Result<List<PointOfPurchaseDto>> GetPointOfPurchase()
        {
            Result<List<PointOfPurchaseDto>> result = new Result<List<PointOfPurchaseDto>>(Trace);
            result = PointOfPurchaseService.GetPointOfPurchase();
            return result;
        }
    }
}