using HolidaysManagement_API.Dtos;
using HolidaysManagement_API.Services;
using HolidaysManagement_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolidaysManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;
       
      

        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        [HttpGet("{id}")]
        public IActionResult GetFunctionById(int id)
        {
            var function = _functionService.GetFunctionById(id);
            if (function == null)
            {
                return NotFound();
            }

            return Ok(function);
        }

        [HttpGet]
        public IActionResult GetAllFunctions()
        {
            var functions = _functionService.GetAllFunctions();
            return Ok(functions);
        }

        [HttpPost]
        public IActionResult CreateFunction(FunctionDto functionDTO)
        {
            _functionService.CreateFunction(functionDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFunction(int id, FunctionDto functionDTO)
        {
            try
            {
                _functionService.UpdateFunction(id, functionDTO);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFunction(int id)
        {
            try
            {
                _functionService.DeleteFunction(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }

}
