using System.Threading.Tasks;

using HurManager.App.Common.Operation;
using HurManager.Core.Services;
using HurManager.Dto.WaterMeters;

using Microsoft.AspNetCore.Mvc;

namespace HurManager.App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class WaterMeterController : ControllerBase
    {
        private readonly IWaterMeterService _waterMeterService;

        public WaterMeterController(IWaterMeterService waterMeterService)
        {
            this._waterMeterService = waterMeterService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WaterMeterAdd dto)
        {
            var result = await this._waterMeterService.AddAsync(dto).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this._waterMeterService.RemoveAsync(id).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this._waterMeterService.GetAsync(id).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WaterMeterUpdate dto)
        {
            var result = await this._waterMeterService.UpdateAsync(dto).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddReadingByHouseId([FromBody] WaterMeterReadingHouseIdAdd dto)
        {
            var result = await this._waterMeterService.AddReadingByHouseIdAsync(dto).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddReadingByFactoryNumber([FromBody] WaterMeterReadingFactoryNbrAdd dto)
        {
            var result = await this._waterMeterService.AddReadingByFactoryNumberAsync(dto).AsOperationAsync();

            return this.Ok(result);
        }
    }
}
