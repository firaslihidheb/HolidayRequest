using HolidaysManagement_API.Dtos;
using HolidaysManagement_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HolidaysManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayRequestController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        public HolidayRequestController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet("{id}")]
        public IActionResult GetHolidayRequestById(int id)
        {
            try
            {
            HolidayRequestDTO request = _holidayService.GetHolidayRequestById(id);
                if (request == null)
                {
                    return NotFound();
                }

                return Ok(request);

            }
            catch (Exception ex )
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetAllHolidayRequests()
        {
            try
            {
                var requests = _holidayService.GetAllHolidayRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult CreateHolidayRequest(HolidayRequestDTO functionDTO)
        {
                
            _holidayService.CreateHolidayRequest(functionDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateHolidayRequest([FromBody] HolidayRequestDTO functionDTO)
        {
            try
            {
                _holidayService.UpdateHolidayRequest(functionDTO);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHolidayRequest(int id)
        {
            try
            {
                _holidayService.DeleteHolidayRequest(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
