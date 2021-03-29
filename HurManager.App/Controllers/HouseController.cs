using System.Threading.Tasks;

using HurManager.App.Common.Operation;
using HurManager.Core.Services;
using HurManager.Dto.Houses;

using Microsoft.AspNetCore.Mvc;

namespace HurManager.App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            this._houseService = houseService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HouseAdd dto)
        {
            var result = await this._houseService.AddAsync(dto).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this._houseService.RemoveAsync(id).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this._houseService.GetAsync(id).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HouseUpdate dto)
        {
            var result = await this._houseService.UpdateAsync(dto).AsOperationAsync();

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this._houseService.ListAsync().AsOperationAsync();

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxMeter()
        {
            var result = await this._houseService.GetMaxMeterAsync().AsOperationAsync();

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMinMeter()
        {
            var result = await this._houseService.GetMinMeterAsync().AsOperationAsync();

            return this.Ok(result);
        }
    }
}
